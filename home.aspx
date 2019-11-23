<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta charset="utf-8">
    <meta name="keywords" 
    <meta http-equiv="refresh" content="3600"/>
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Index-Page-CSS -->
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all"/>
    <!-- //Custom-Stylesheet-Links -->
    <!--fonts -->
    <!-- //fonts -->
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" media="all"/>
    <!-- //Font-Awesome-File-Links -->
    <!-- Google fonts -->
    <link href="//fonts.googleapis.com/css?family=Quattrocento+Sans:400,400i,700,700i" rel="stylesheet"/>
    <link href="//fonts.googleapis.com/css?family=Mukta:200,300,400,500,600,700,800" rel="stylesheet"/>
    <!-- Google fonts -->
     <meta http-equiv="refresh" content="3600"/>
</head>
<body>
<form id="form1" runat="server">
       <section class="main">
        <div class="layer">

            <div class="bottom-grid">
                <div class="logo">
                    <h1> <a href="index"> Integration App</a></h1>
                </div>
                <div class="links">
                    <ul class="links-unordered-list">
                        <li class="">
                            <a href="settings.aspx" class="">Settings</a>
                        </li>
                       </ul>
                </div>
            </div>
           
           
        </div>
           <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Gadugi" ForeColor="White"></asp:Label>
    </section>
    </form>
</body>
</html>
