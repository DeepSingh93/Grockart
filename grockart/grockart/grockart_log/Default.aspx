<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" ClientIDMode="Static" Inherits="grockart_log_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grockart Log</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <link href="../assets/css/Grockart.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <!--include the Roboto font-->
    <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700" rel="stylesheet" />
    <link href="../assets/css/grockart.css" rel="stylesheet" />
    <!-- Latest compiled and minified CSS for bootstrap-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

</head>
<body>
    <form id="form1" runat="server">

        <div class="container pb10px" style="overflow:hidden;">
            <div class="col-lg-4">
                <div class="text-center exception-image">
                    <img src="../assets/images/logoWithoutText.png" class="exception-image-inner" />
                </div>
                <div class="text-center">
                    <img class="exception-Grockart-image" src="../assets/images/Grockart_text.PNG" />
                </div>
                <div class="exception-header text-center" id="headerText">
                    Log
                </div>
                <div class="text-center p10px exception-subheader" id="PreviousLog" runat="server" visible="false">
                    Fetch Previous Logs
            <asp:DropDownList ID="PreviousLogList" OnSelectedIndexChanged="PreviousLogList_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                </div>

                <div class="text-center p10px exception-subheader" id="exportDivID" runat="server" visible="false">
                    Export this log
            <asp:Button ID="ExportLogButton" CssClass="primary-background-color ExportLogButton" runat="server" OnClick="ExportLogButton_Click" Text="Click here to export" />
                </div>
            </div>
            <div class="col-lg-6">

                <%--region for charts--%>

                <div id="piechart" style="width: 900px; height: 500px; margin: 0 auto;"></div>

                <%--end region for charts--%>
            </div>
        </div>
        <div class="text-center p10px exception-subheader bold" runat="server" visible="false" id="exportResult">
            Log Successfully Exported at 
        </div>
        <div class="row grockart-row-log grockart-row-header">
            <div class="col-lg-1">Log Type</div>
            <div class="col-lg-1">Date</div>
            <div class="col-lg-1">Exception Type</div>
            <div class="col-lg-1">Function Name</div>
            <div class="col-lg-2">File Location</div>
            <div class="col-lg-1">Line Number</div>
            <div class="col-lg-2">Message</div>
            <div class="col-lg-3">Stack Trace</div>
        </div>
        <div class="row grockart-row-log text-center" runat="server" visible="false" id="nologsfoundID">
            No Logs found
        </div>
        <div id="logResults" runat="server">
        </div>
        <script>
            google.charts.load('current', { 'packages': ['corechart'] });


            function drawGrockartLogChart(data) {
                console.log(JSON.stringify(data));
                var data = google.visualization.arrayToDataTable(data);

                var options = {
                    title: 'Log Activities for given time frame'
                };

                // create color map
                var colors = {
                    'INFO': '#64FFDA',
                    'WARN': '#FBC02D',
                    'DEBUG': '#40C4FF',
                    'FATAL': '#FF6E6E'
                };

                // build slices
                var slices = [];
                for (var i = 0; i < data.getNumberOfRows(); i++) {
                    slices.push({
                        color: colors[data.getValue(i, 0)]
                    });
                }

                options.slices = slices;

                var chart = new google.visualization.PieChart(document.getElementById('piechart'));

                chart.draw(data, options);
            }

        </script>
    </form>

</body>
</html>
