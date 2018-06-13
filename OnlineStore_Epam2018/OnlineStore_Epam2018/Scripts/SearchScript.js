$("#buttonSearchId").on('click', function () {
    GetPageData();
});


function GetPageData() {
    $("#searchResult").empty();

    var a = $("#searchName").val();
    var b = $("select[name='CategoryName'] option:checked").val();
    var x = $("#minValue").val();
    var d = $("#maxValue").val();



    if (b == null || b == "") {
        b = 0;
    }
    if (x == null || x == "") {
        x = 1;
    }

    if (d == null || d == "") {
        d = 100;
    }
   

    $.ajax({
        url: "/Search/OrdersData",
        type: "GET",
        data: {
            searchName: a,
            category: b,
            minValue: x,
            maxValue: d
        },
        success: function (response) {
            $('#searchResult').append(response);
        }
    });
}