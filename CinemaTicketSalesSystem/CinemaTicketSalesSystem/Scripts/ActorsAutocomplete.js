$("#searchInput").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "/EditMovie/GetSearchValue",
            dataType: "json",
            data: { search: $("#searchInput").val() },
            success: function (data) {
                response($.map(data, function (item) {
                    return { label: item.FirstName + ' ' + item.LastName, value: item.FirstName };
                }))
            },
            error: function (xhr, status, error) {
                alert("Error");
            }
        })
    }
});