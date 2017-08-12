$(document).ready(function () {

    $('#search').click(function () {
        var userName = $('#user').val();
        var startDate = $('#startDate').val();
        var endDate = $('#endDate').val();
        if (endDate == '') {
            endDate = '2050-12-31';
        }
        loadSales(userName, startDate, endDate);
    });

    $('#searchButton').click(function () {
        console.log($('#searchType').html());
        //var type = $('#searchType').html();
        //if (type == "New") {
        //    searchType = "New";
        //}
        //else { searchType = "Used"; }
        var searchType = $('#searchType').html();
        var searchString = $('#searchString').val();
        if (searchString == "") {
            searchString = "none";
        }
        var minPrice = $('#minPrice').val();
        var maxPrice = $('#maxPrice').val();
        var minYear = $('#minYear').val();
        var maxYear = $('#maxYear').val();
        console.log(searchType, searchString, minPrice, maxPrice, minYear, maxYear);
        loadItems(searchType, searchString, minPrice, maxPrice, minYear, maxYear);
    });

    $('#makeList').change(function () {
        var value = $('#makeList').val();
        $.ajax({
            url: 'http://localhost:54826/api/getmodels/' + value,
            type: 'GET',
            success: function (result) {
                var selectedDeviceModel = $('#vmodelId');
                selectedDeviceModel.empty();
                $.each(result, function (index, vmodel) {
                    $("#vmodelId").append(
                        $('<option></option>').val(vmodel.VModelId).html(vmodel.ModelType));
                });
                //$.each(result, function (index, item) {
                //    selectedDeviceModel.append(
                //        $('<option/>', {
                //            value: item.value,
                //            text: item.text
                //        })
                //    );
                //});
            },
            error: function () {
                alert('no items returned');
            }
        });
    });

});



function loadItems(searchType, searchString, minPrice, maxPrice, minYear, maxYear) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:54826/api/vehicles/' + searchType + '/' + searchString + '/' + minPrice + '/' + maxPrice + '/' + minYear + '/' + maxYear,
            //data: JSON.stringify(
            //    {
            //        searchString, minPrice, maxPrice, minYear, maxYear
            //    }),
            success: function (itemArray) {
                $('#searchResults').empty();
                var allRows = $('#searchResults');
                $.each(itemArray, function (index, item) {
                    var row = '';
                    row += '<div class="row" style="border: solid">';
                    row += '<div class="col-xs-3">' + item.Year + ' ' + item.VehicleModelId.ModelMake.MakeType;
                    row += ' ' + item.VehicleModelId.ModelType + '</div>';
                    row += '<div class="col-xs-3">' + '<div>Body Style: ' + item.VehicleBodyStyle.BodyStyleType + '</div><div>Transmission: ' + item.VehicleTrans.TransTypeName + '</div>';
                    row += '<div>Color: ' + item.VehicleExtColor.ExtColorName + '</div></div>';
                    row += '<div class="col-xs-3">' + '<div>Interior: ' + item.VehicleIntColor.IntColorName + '</div><div>Mileage: ';
                    row += item.Mileage + '</div><div>VIN: ' + item.VIN + '</div></div>';
                    row += '<div class="col-xs-3"><div>Sale Price: ' + item.Price + '</div><div>MSRP: ' + item.MSRP + '</div></div>';
                    if ($('#buttonType').html() == "Admin") {
                        console.log($('#buttonType').html());
                        row += '<a href = /Admin/EditVehicle/' + item.VehicleId + '>Edit</a>';
                    }
                    else if ($('#buttonType').html() == "Sales") {
                        row += '<a href = /Sales/Purchase/' + item.VehicleId + '>Purchase</a>';
                    }
                    else {
                        row += '<a href = /Inventory/Details/' + item.VehicleId + '>Details</a>';
                    }
                    row += '</div><br />';

                    allRows.append(row);
                });
            },
            error: function () {
                alert('no items returned');
            }
        });
}

function loadSales(userName,startDate,endDate) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:54826/api/salesreport/' + userName + '/' + startDate + '/' + endDate,
        success: function (itemArray) {
            $('#results').empty();
            var allRows = $('#results');
            $.each(itemArray, function (index, item) {
                var row = '';
                row += '<tr><td>' + item.Name + '</td>';
                row += '<td>' + item.TotalSales + '</td>';
                row += '<td>' + item.TotalVehicles + '</td></tr>'

                allRows.append(row);
            });
        },
        error: function () {
            alert('no items returned');
        }
    });
}
