namespace QAutomation.Logging.HtmlReport
{
    using QAutomation.Logging.HtmlReport.Info;
    using QAutomation.Logging.LogItems;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public class HtmlReportGenerator
    {
        private string _rootDir;

        private string _seachLogItemPattern;
        private string _searchLogFolderPattern;

        private string _attachmentsFolder = "Files";

        public HtmlReportGenerator(string rootDir, string attachmentsFolder = "Files", string searchFolderPattern = "Logs", string searchLogPattern = "*.log.bin")
        {
            _rootDir = rootDir;

            _seachLogItemPattern = searchLogPattern;
            _searchLogFolderPattern = searchFolderPattern;

            _attachmentsFolder = attachmentsFolder;

            LogAttachmentInfo.RootDirectory = _attachmentsFolder;
        }


        private List<Tab> Magic(IEnumerable<LogTestAggregation> items, Tab parent = null)
        {
            var list = new List<Tab>();

            Func<LogTestAggregation, string> func = parent != null
                ? new Func<LogTestAggregation, string>(log => log.TestName.Replace(parent.Namespace, string.Empty).Trim('.'))
                : new Func<LogTestAggregation, string>(log => log.TestName);

            var parts = items.Select(i => func(i).Split('.')).OrderBy(a => a.Length).Last();

            string prev = null;
            string space = parent?.Namespace;

            int index = 0;

            while (true)
            {
                prev = space;
                space = space != null ? string.Join(".", space, parts[index++]) : parts[index++];

                if (items.Count() > 1)
                {
                    var coinciding = items.Where(i => i.TestName.StartsWith(space));
                    var diff = items.Except(coinciding);

                    if (diff.Any())
                    {
                        var tab = new Tab { Parent = parent, Namespace = space };
                        tab.Tabs.AddRange(Magic(coinciding, tab));

                        list.Add(tab);
                        break;
                    }
                    else
                        continue;
                }
                else
                {
                    list.Add(new Tab { Namespace = prev, Parent = parent, Items = items.ToList() });
                    break;
                }
            }

            return list;
        }

        public void GenerateReport(string destinationPath)
        {
            var deserialized = GetLogs(_rootDir, searchFolderPattern: _searchLogFolderPattern);

            var nmspc = Magic(deserialized.OfType<LogTestAggregation>());
            var attachments = deserialized.SelectMany(d => GetAttachments(d));

            CopyAttachmentsToWorkingDirectory(attachments, _rootDir, destinationPath, searchFolderPattern: _searchLogFolderPattern);

            deserialized.ForEach(x => Generate(x as LogTestAggregation));
        }

        public static List<LogAggregation> GetLogs(string rootDir, string searchLogPatttern = "*.log.bin", string searchFolderPattern = "Logs")
        {
            var formatter = new BinaryFormatter();
            var list = new List<LogAggregation>();

            var rootDirInfo = new DirectoryInfo(rootDir);

            if (!rootDirInfo.Exists)
                throw new DirectoryNotFoundException($"Root directory with logs '{rootDirInfo}' isn't exist.");

            foreach (var dir in rootDirInfo.GetDirectories(searchFolderPattern, SearchOption.AllDirectories))
            {
                var logs = dir.GetFiles(searchLogPatttern);

                if (logs != null && logs.Any())
                {
                    foreach (var log in logs)
                    {
                        using (var stream = new FileStream(log.FullName, FileMode.Open))
                        {
                            list.Add((LogAggregation)formatter.Deserialize(stream));
                        }
                    }
                }
            }

            return list;
        }
        public void CopyAttachmentsToWorkingDirectory(IEnumerable<LogAttachment> attachments, string rootDir, string workingDir, string searchFolderPattern = "Logs")
        {
            HashSet<string> set = new HashSet<string>(attachments.Select(a => a.GetFolder()));
            List<FileInfo> attachmentFiles = new List<FileInfo>();

            var rootDirInfo = new DirectoryInfo(rootDir);
            var workingDirInfo = new DirectoryInfo(Path.Combine(workingDir, _attachmentsFolder));

            if (!rootDirInfo.Exists)
                throw new DirectoryNotFoundException($"Root directory with logs '{rootDirInfo}' isn't exist.");

            if (workingDirInfo.Exists)
                workingDirInfo.Delete(true);

            workingDirInfo.Create();

            foreach (var dir in rootDirInfo.GetDirectories(searchFolderPattern, SearchOption.AllDirectories))
            {
                foreach (var folder in set)
                {
                    var files = dir.GetDirectories(folder, SearchOption.TopDirectoryOnly).FirstOrDefault()?.GetFiles();

                    if (files != null)
                        attachmentFiles.AddRange(files);
                }
            }
            attachmentFiles.ForEach(f => f.CopyTo(Path.Combine(workingDirInfo.FullName, f.Name), true));
        }


        public void Generate(LogTestAggregation log) => new Document(new LogTestAggregationInfo(log)).Build();

        private List<LogAttachment> GetAttachments(LogAggregation aggregation)
        {
            var list = new List<LogAttachment>();

            foreach (var item in aggregation.Items)
            {
                switch (item)
                {
                    case LogAggregation logAggregation:
                        list.AddRange(GetAttachments(logAggregation));
                        continue;
                    case LogAttachment logAttachment:
                        list.Add(logAttachment);
                        continue;
                }
            }

            return list;
        }
    }
}
