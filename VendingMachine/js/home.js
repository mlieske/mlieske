$(document).ready(function() {
var total = 0;
var itemNumber;
loadItems();

$('#dollar').click(function(){
    total += 100;
    $('#totalIn').val((total/100).toFixed(2));
});

$('#quarter').click(function(){
    total += 25;
    $('#totalIn').val((total/100).toFixed(2));
});

$('#dime').click(function(){
    total += 10;
    $('#totalIn').val((total/100).toFixed(2));
});

$('#nickel').click(function(){
    total += 5;
    $('#totalIn').val((total/100).toFixed(2));
});

$('#allRows').on('click', '.itemclick', function(){
    itemNumber = $(this).attr('data-item');
    $('#item-added').val(itemNumber);
})

$('#change-return').click(function(){
    $('#totalIn').val('');
    total=0;
    itemNumber=0;
    $('#return-message').val('');
    $('#item-added').val('');
    $('#change-returned').val('');
    $('#allRows').empty();
    document.getElementById('dollar').disabled = false;
    document.getElementById('quarter').disabled = false;
    document.getElementById('dime').disabled = false;
    document.getElementById('nickel').disabled = false;
    document.getElementById('purchase').disabled = false;

    loadItems();
})

$('#purchase').click(function(){
    var newTotal=$('#totalIn').val();
    itemNumber=$('#item-added').val();
    var changeMessage = '';
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + newTotal + '/item/' + itemNumber,
        success: function(changeReturned){
            console.log(changeReturned);

            if (changeReturned.quarters == 1){
                changeMessage += changeReturned.quarters + ' Quarter ';
            }
            else if (changeReturned.quarters > 1){
                changeMessage += changeReturned.quarters + ' Quarters ';
            }
            if (changeReturned.dimes == 1){
                changeMessage += changeReturned.dimes + ' Dime ';
            }
            else if (changeReturned.dimes > 1){
                changeMessage += changeReturned.dimes + ' Dimes ';
            }
            if (changeReturned.nickels == 1){
                changeMessage += changeReturned.nickels + ' Nickel ';
            }
            else if (changeReturned.nickels > 1){
                changeMessage += changeReturned.nickels + ' Nickels ';
            }
            if (changeReturned.pennies == 1){
                changeMessage += changeReturned.pennies + ' Penny';
            }
            else if (changeReturned.pennies > 1){
                changeMessage += changeReturned.pennies + ' Pennies';
            }
            $('#return-message').val('Thank you!!!');
            $('#change-returned').val(changeMessage);
            document.getElementById('dollar').disabled = true;
            document.getElementById('quarter').disabled = true;
            document.getElementById('dime').disabled = true;
            document.getElementById('nickel').disabled = true;
            document.getElementById('purchase').disabled = true;
            
        },
        error: function(xhr,error,result) {
            var err = JSON.parse(xhr.responseText);
            $('#return-message').val(err.message);
        }
    });
});

});

function loadItems() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(itemArray){
                var allRows = $('#allRows');
            $.each(itemArray,function(index,item){
                var row = '';
                row += '<div class="col-xs-4">';
                row += '<div class="items itemclick" data-item="' + item.id + '">';
                row += '<div id="item-index-' + item.id + '" class="item-index">' + item.id + '</div>';
                row += '<div id="item-name-' + item.id + '">' + item.name + '</div><br/>';
                row += '<div id="item-cost-' + item.id + '">$' + item.price.toFixed(2) + '</div><br/>';
                row += '<div id="item-inventory-' + item.id + '">Quantity Left: ' + item.quantity + '</div><br/>';
                row += '</div>';
                row += '</div>';

                allRows.append(row);
            });
        },
        error: function(){
            alert('no items returned');
        }
    });
}


