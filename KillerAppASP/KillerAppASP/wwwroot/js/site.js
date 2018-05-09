function ToggleRememberMe() {
    var AutoLogin = document.getElementById("autologin");
    var RememberMe = document.getElementById("rememberme");
    if (AutoLogin.checked === true) {
        RememberMe.style.display = "block";
    } else {
        RememberMe.style.display = "none";
    }
}

function GetPreview(mapname) {
    $('#preview').attr('src', '/MapCreator/GetMapPreview?Mapname=' + mapname);
}

function Login() {
    $.ajax({
        url: $("#loginform").attr('action'),
        data: $("#loginform").serialize(),
        type: 'POST',
        success: function (data) {
            if (data.success === true) {
                window.location.href = data.url;
            }
            else {
                $("#registerresult").empty();
                $("#loginresult").html(data.message);
            }
        },
        error: function () {
            $("#loginresult").text("Something Went Wrong");
        }
    });
}

function Register() {
    $.ajax({
        url: $("#registerform").attr('action'),
        data: $("#registerform").serialize(),
        type: 'POST',
        success: function (data) {
            if (data.success === true) {
                if (data.login === true) {
                    window.location.href = data.url;
                }
                else {
                    $("#registerform").trigger("reset");
                }    
            }
            else {
                $("#loginresult").empty();
            }
            $("#registerresult").html(data.message);
        },
        error: function () {
            $("#registerresult").text("Something Went Wrong");
        }
    });
}

function ChangePassword() {
    $.ajax({
        url: $("form").attr('action'),
        data: $("form").serialize(),
        type: 'POST',
        success: function (data) {
            if (data.success === true) {
                $("#passwordform").trigger("reset");
            }
            else {
                $("#oldpassword").trigger("reset");
            }
            $("#result").html(data.message);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
}

function GenerateMap() {
    var Result = document.getElementById("result");
    var SaveButton = document.getElementById("savemap");
    $.ajax({
        url: $("form").attr('action'),
        data: $("form").serialize(),
        type: 'POST',
        success: function (data) {
            if (data.success === true) {
                Result.classList.remove('text-danger');
                Result.classList.add('text-success');
                SaveButton.removeAttribute('disabled');
            }
            else {
                Result.classList.add('text-danger');
                Result.classList.remove('text-success');
            }
            $("#result").html(data.message);
        },
        error: function (data) {
            $("#result").text("Something Went Wrong");
        }
    });
}

function SaveMap() {
    $.ajax({
        type: 'GET',
        url: 'MapCreator/SaveMap',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            $("#result").html(data.message);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
    setTimeout(GetUserMapsWithDelete, 500);
}

function DeleteMap(mapname) {
    var r = confirm("Are you sure you want to delete this map?");
    if (r == true) {
        $.ajax({
            type: 'DELETE',
            url: 'MapCreator/DeleteMap?Mapname=' + mapname,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $('#preview').attr('src', '/images/preview.gif');
                $("#result").html(data.message);
            },
            error: function () {
                $("#result").text("Something Went Wrong");
            }
        });
        setTimeout(GetUserMapsWithDelete, 500);
    }
}

function GetUserMaps() {
    $.ajax({
        url: "/MapCreator/GetUserMaps",
        type: 'GET',
        success: function (data) {
            $("#MapList").html(data);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
}

function GetUserMapsWithDelete() {
    $.ajax({
        url: "/MapCreator/GetUserMapsWithDelete",
        type: 'GET',
        success: function (data) {
            $("#MapListWithDelete").html(data);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
}

function GetOnlineUsers() {
    $.ajax({
        url: "/Multiplayer/GetOnlineUsers",
        type: 'GET',
        success: function (data) {
            $("#OnlineUserList").html(data);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
}

function GetAllUsers() {
    $.ajax({
        url: "/Multiplayer/GetAllUsers",
        type: 'GET',
        success: function (data) {
            $("#AllUserList").html(data);
        },
        error: function () {
            $("#result").text("Something Went Wrong");
        }
    });
}

$(function () {
    $('body').on('click', '.list-group-item', function () {
        $('.list-group-item').removeClass('active');
        $(this).closest('.list-group-item').addClass('active');
    });
});