//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Posts/Index",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.PostId + '</td>';
                html += '<td>' + item.Title + '</td>';
                html += '<td>' + item.UserName + '</td>';
                html += '<td>' + item.Created + '</td>';
                html += '<td>' + item.CommentCount + '</td>';
                html += '</tr>';

                if (item.Comments !== null || item.Comments.length > 0 || item.Comments !== undefined) {
                    $.each(item, function (key, item2) {
                        html += '<tr>';
                        html += '<td>' + item2.Comments.CommentId + '</td>';
                        html += '<td>' + item2.Comments.Text + '</td>';
                        html += '<td>' + item2.Comments.UserName + '</td>';
                        html += '<td>' + item2.Comments.Created + '</td>';
                        html += '<td>' + item2.Comments.Like + '</td>';
                        html += '<td><a href="#" onclick="LikeComment(' + item2.Comments.CommentId + ')">Like</a></td>';
                        html += '<td>' + item2.Comments.Dislike + '</td>';
                        html += '<td><a href="#" onclick="DislikeComment(' + item2.Comments.CommentId + ')">Dislike</a></td>';
                        html += '</tr>';
                    }
                })
            });
            $('.tbody').html(html));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Like Comment
function LikeComment(commentId) {

    $.ajax({
        url: "/Comments/LikeCommect" + commentId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Disike Comment
function DislikeComment(commentId) {

    $.ajax({
        url: "/Comments/DislikeCommect" + commentId,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  