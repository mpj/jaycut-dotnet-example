<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JayCut.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body><a href="<%= JayCutLoginUri %>&_method=POST">HLLOE!</a>
    <form id="form1" runat="server">
    <!-- This is where the editor will be inserted, you can place it anywhere you need it.  -->
    <div id="jaycut-editor"></div>

    <!-- Include the SDK, just before the closing </body> tag.-->

    <script src="http://api.jaycut.com/assets/javascripts/sdk.0.3.1.js" type="text/javascript"></script> 
    <script type="text/javascript">
        JC.init(
            '<%= JayCutAuthority %>',
            '<%= JayCutLoginUri %>'
        );
    </script>
    </form>
</body>
</html>
