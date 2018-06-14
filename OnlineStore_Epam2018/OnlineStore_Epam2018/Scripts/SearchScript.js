$("#buttonSearchId").on('click', function () {
    GetPageData();
});


function GetPageData() {
    $("#searchResult").empty();

    var nameProduct = $("#searchName").val();
    var categoryId = $("select[name='CategoryName'] option:checked").val();
    var priceMin = $("#minValue").val();
    var priceMax = $("#maxValue").val();



    if (categoryId == null || categoryId  == "") {
        categoryId  = 0;
    }
    if (priceMin == null || priceMin == "") {
        priceMin= 1;
    }

    if (priceMax == null || priceMax == "") {
        priceMax = 10000;
    }
   

    $.ajax({
        url: "/Search/OrdersData",
        type: "GET",
        data: {
            searchName: nameProduct,
            category: categoryId ,
            minValue: priceMin,
            maxValue: priceMax
        },
        success: function (response) {
            $('#searchResult').append(response);
        }
    });
}