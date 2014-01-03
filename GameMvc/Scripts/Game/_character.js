$(document).ready(function () {
    alert($('a.test').length);
    $('a.test').cluetip();
    $('div.charEquipCellContent').cluetip({ local: true, attribute: 'data-tip', hoverClass: 'highlight' });
});