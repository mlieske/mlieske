$(document).ready(function () {
    $('.center').click({
        centerMode: true,
        centerPadding: '60px',
        slidesToShow: 3,
        responsive: [
            {
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '40px',
                    slidesToShow: 1
                }
            }
        ]
    });
    $('#searchButton').click(function (event) {
        var searchType = $('#searchType').val();
        var searchTerm = $('#searchBox').val();
        if (searchType === "post") {
            loadPostsByTitle(searchTerm);
        }
        else if (searchType === "tags") {
            loadPostsByTag(searchTerm);
        }
        else if (searchType === "username") {
            loadPostsByUser(searchTerm);
        }
        return false;
    });

    $('#addTag').click(function (event) {
        var tagName = $('#newTag').val();
        addNewTag(tagName);
        return false;
    });
});

function addNewTag(tagName) {
    $.ajax({
        type: 'POST',
        url: 'http://localhost:51620/api/addTag/%23' + tagName,
        success: function (tagArray) {
            var count = tagArray.length - 1;
            var tag = tagArray[count].TagName;
            var tagId = tagArray[count].TagId;
            var posts = tagArray[count].Posts;


            $('#allTags').append(' <input data-val="true" data-val-number="The field TagId must be a number." data-val-required="The TagId field is required." id="AllTags_' +
                count + '__TagId" name="AllTags[' + count + '].TagId" type="hidden" value="' + tagId + '">');
            $('#allTags').append('<input checked="checked" data-val="true" data-val-required="The IsChecked field is required." id="AllTags_' +
                count + '__IsChecked" name="AllTags[' + count + '].IsChecked" type="checkbox" value="true">');
            $('#allTags').append('<input name="AllTags[' + count + '].IsChecked" type="hidden" value="false">');
            $('#allTags').append('<label for="AllTags_' + count + '__IsChecked">' + tag + '</label><br />');
            
        }
    });
}
function loadPostsByTag(tagName) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51620/api/getPostsByTag/%23' + tagName,
        success: function (postArray) {

            $('#searchTable tbody').empty();
            $.each(postArray, function (index, data) {
                var title = data.PostTitle;
                var date = data.CreationDate;
                var formattedDate = date.substr(5, 2) + '/' + date.substr(8, 2) + '/' + date.substr(0, 4);
                var body = data.PostBody.substr(0, 10);
                var postId = data.PostId;

                $('#searchTable tbody').append('<tr><td><a href="Post/Index/' + postId + '">' + title + '</a></td>' +
                    '<td>' + formattedDate + '</td><td>' + body + '...</td>');
            });


        },
        error: function () {
            $('#searchTable tbody').empty();
            $('#errorMessage')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text("Unable to get any posts, try again later.");
        }
    });

}

function loadPostsByUser(userId) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51620/api/getPostsByUser/' + userId,
        success: function (postArray) {

            $('#searchTable tbody').empty();

            $.each(postArray, function (index, data) {
                var title = data.PostTitle;
                var date = data.CreationDate;
                var formattedDate = date.substr(5, 2) + '/' + date.substr(8, 2) + '/' + date.substr(0, 4);
                var body = data.PostBody.substr(0, 10);
                var postId = data.PostId;

                $('#searchTable tbody').append('<tr><td><a href="Post/Index/' + postId + '">' + title + '</a></td>' +
                    '<td>' + formattedDate + '</td><td>' + body + '...</td>');
            });


        },
        error: function () {
            $('#searchTable tbody').empty();
            $('#errorMessage')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text("Unable to get any posts, try again later.");
        }
    });

}
function loadPostsByTitle(postTitle) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:51620/api/getPostsByTitle/' + postTitle,
        success: function (postArray) {

            $('#searchTable tbody').empty();
            $.each(postArray, function (index, data) {
                var title = data.PostTitle;
                var date = data.CreationDate;
                var formattedDate = date.substr(5, 2) + '/' + date.substr(8, 2) + '/' + date.substr(0, 4);
                var body = data.PostBody.substr(0, 10);
                var postId = data.PostId;

                $('#searchTable tbody').append('<tr><td><a href="Post/Index/' + postId + '">' + title + '</a></td>' +
                    '<td>' + formattedDate + '</td><td>' + body + '...</td>');
            });


        },
        error: function () {
            $('#searchTable tbody').empty();
            $('#errorMessage')
                .append($('<li>'))
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text("Unable to get any posts, try again later.");
        }
    });

}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
        });

        return true;
    } else {
        return false;
    }
}

