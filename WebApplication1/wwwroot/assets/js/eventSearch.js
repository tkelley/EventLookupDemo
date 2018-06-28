$(function () {
    $("#keywordSearchBtn").click(doSearch);
    $("#keyword").keyup(function (e) {
        let code = e.which;
        if (code == 13) e.preventDefault();
        if (code == 32 || code == 13 || code == 188 || code186) doSearch();
    });
});

// Make ajax call to do a keyword search
function doSearch() {
    clearResults();
    var keyword = $("#keyword").val();

    if (keyword.length) {
        var request = $.ajax({
            url: "/api/GetEventsByKeyword/" + keyword,
            method: "GET"
        });

        request.done(function (data) {
            populateResults(data);
        });

        request.fail(function () {
            //displayFailMessage();
        });
    }
}

// Empty out the search results
function clearResults() {
    $(".search-results tbody").empty();
}

// Display the search results
function populateResults(data) {
    let resultTable = $(".search-results tbody");
    let searchResults = $(".search-results");
    searchResults.show();

    if (data.length) {
        let rows = data.reduce(function (rowString, item) {
            return rowString += "<tr><td>" + item.id + "</td><td>" + item.description + "</td></tr>";

        }, "");

        resultTable.append(rows);
    } else {
        searchResults.hide();
        let searchResultsEmpty = $(".search-results-empty");
        searchResultsEmpty.html("No results found.  Please try another string.");
        searchResultsEmpty.show();
    }
}