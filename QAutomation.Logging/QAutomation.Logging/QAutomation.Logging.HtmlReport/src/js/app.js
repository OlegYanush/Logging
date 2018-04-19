const dictionary = { 0:"TRACE", 1:"DEBUG", 2:"INFO", 3:"WARN", 4:"ERROR" };

$(document).foundation()

$('.slider').on('changed.zf.slider', function() {
    let value = $(this).children("input").val();
    let array = [];

    for(let i = 0; i< Object.keys(dictionary).length;i++)
        if(i >= value) array.push(dictionary[i]);

    var items = $(this).closest('div .log-aggregation').find('.log-item');

    let hide;
    for(let i = 0; i < items.length; i++)
    {
        hide = true;
        var attr = $(items[i]).attr('class');

        for(let j = 0; j < array.length; j++)
        {
            if(attr.includes(array[j]))
            {
                hide = false;
                break;
            }
        }

        hide ? $(items[i]).hide(250) : $(items[i]).show(250);
    }
});