// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function changePage(number) {
 
    let keyword = $('#current-keyword').val();
    let criteria = $('#current-criteria').val();
    let page = parseInt($('#current-page').val()) + number;
    let pageSize = 10;
    if (criteria === "Movie") {
        $('#search-results').load('/bar/barsearchresults', { keyword: keyword, page: page,pageSize: pageSize });
    }
    else {
        $('#search-results').load('/bar/barsearchresults', { keyword: keyword,page: page,pageSize: pageSize });
    }

}
function searchEventHandler() {

    let keyword = $('#keyword').val();
    let criteria = $('#criteria').val();
    let page = 1;
    let pageSize = 10;
    if (criteria === "Movie") {
        $('#search-results').load('/movie/moviesearchresults', { keyword: keyword, page: page, pageSize: pageSize });
    }
    else {
        $('#search-results').load('/actor/actorsearchresults', { keyword: keyword, page: page, pageSize: pageSize });
    }
}
