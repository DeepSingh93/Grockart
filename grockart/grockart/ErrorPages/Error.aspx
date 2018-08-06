<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="ErrorPages_Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error occured</title>
    <!-- Latest compiled and minified CSS for bootstrap-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="../assets/css/Grockart.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script>
        try {
            $.getJSON("../assets/database/exceptionList.json", function (data) {
                var e = getParameterByName("e");
                if (e != null) {
                    $('#headerText').text((data.exceptionList[0][e])[0]);
                    $('#sub-headerText').text((data.exceptionList[0][e])[1]);
                } else {
                    $('#headerText').text("An error occured, please try again later");
                    $('#sub-headerText').text("This event has been logged.")
                }
            });
        } catch (Exception) {
            $('#headerText').text("An error occured, please try again later");
            $('#sub-headerText').text("This event has been logged.");
        }

        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return '';
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container " style="text-align:center;">
            <div class="text-center exception-image">
                <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
            </div>
            <div class="text-center">
                <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
            </div>
            <div class="exception-header text-center" id="headerText">
            </div>
            <div class="exception-subheader text-center" id="sub-headerText">
            </div>
            <div class="text-center">
                Please click <a class="primary-color" href="/">HERE</a> to redirect to home page.
            </div>
        </div>
    </form>
</body>
</html>
