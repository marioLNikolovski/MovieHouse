// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function changePage(number) {
 
    let keyword = $('#current-keyword').val();
    let criteria = $('#criteria').val();
    let pageSize = 5;
    if (criteria === "Movie") {
        $('#search-results').load('/movie/moviesearchresults', { keyword: keyword, page: number,pageSize: pageSize });
    }
    else {
        $('#search-results').load('/actor/actorsearchresults', { keyword: keyword,page: number,pageSize: pageSize });
    }

}
function searchEventHandler() {
    
    let keyword = $('#keyword').val();
    let criteria = $('#criteria').val();
    let page = 1;
    let pageSize = 5;
    if (criteria === "Movie") {
        $('#search-results').load('/movie/moviesearchresults', { keyword: keyword, page: page, pageSize: pageSize });
       
    }
    else {
        $('#search-results').load('/actor/actorsearchresults', { keyword: keyword, page: page, pageSize: pageSize });
    }
}

function createPagination() {

    let page = parseInt($('#current-page').val());
    let container = $('#pagination-container');
    let moviesCount = parseInt($('#current-moviesCount').val());
    let lastPage = $('#last-page').val();
    if (moviesCount != 0) {
        if (page != 1) {
            for (let i = page; i >= 1; i--) {
                if (i === page) {
                    $("#pagination-container").append('<li class="active"><a onclick="changePage(' + i + ')">'+ i + '</a></li>');
                }
                else {
                    $("#pagination-container").append('<li onclick="changePage(' + i + ')"><a onclick="changePage(' + i + ')">' + i + '</a></li>');
                }
            }
        }
        else {
            $("#pagination-container").append('<li class="active"><a onclick="changePage(' + 1 + ')">' + 1 + '</a></li>');
        }

        if (lastPage === "False") {
            let nextPage = page + 1;
            $("#pagination-container").append('<li onclick="changePage(' + nextPage + ')"><a>' + nextPage + '</a></li>');
        }
    }
}
const timeOut = function () {
    setTimeout(createPagination, 1000);
}



