<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JayCutExample.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Editor of My Cute Dog Video Site!</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="jaycut-editor"><!-- The Flash Mixer will go here. The div must be named 'jaycut-editor'. --></div>
    </form>
    
    <!-- Include the JS SDK, it will work best if it is placed just before the closing </body> tag. -->
    <script src="http://api.jaycut.com/assets/javascripts/sdk.0.3.1.js" type="text/javascript"></script> 
    <script type="text/javascript">
        JC.init(
            '<%= JayCutAuthority %>',
            '<%= JayCutLoginUri %>'
        );
    </script>
</body>
</html>
