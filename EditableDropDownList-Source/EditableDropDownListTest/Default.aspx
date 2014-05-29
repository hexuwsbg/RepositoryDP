<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EditableDropDownListTest.Default" %>

<%@ Register TagPrefix="uc" TagName="WebUserControl" Src="~/WebUserControl1.ascx" %>

<%@ Register Assembly="EditableDropDownList" Namespace="EditableControls" TagPrefix="editable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.core.js" type="text/javascript"></script>
    <script src="js/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="js/jquery.ui.button.js" type="text/javascript"></script>
    <script src="js/jquery.ui.position.js" type="text/javascript"></script>
    <script src="js/jquery.ui.autocomplete.js" type="text/javascript"></script>
    <script src="js/jquery.ui.combobox.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Example 1 - Manual Items
        <br />
        <uc:WebUserControl id="WebUserControl1" runat="server" />
        <br /><br /><br />
        Example 2 - Standard Datasource
        <br />
        Greetings <editable:EditableDropDownList ID="EditableDropDownList2" runat="server" Sorted="true" AutoselectFirstItem="true">
        </editable:EditableDropDownList>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
            ControlToValidate="EditableDropDownList2" ErrorMessage="Greeting is Required" 
            ForeColor="Red">Greeting is Required</asp:RequiredFieldValidator>
        <br /><br />
        Example 3 - Custom Datasource
        &nbsp; <small><a href="#" onclick="javascript:$('#EditableDropDownList3_list').toggle(); $('#EditableDropDownList3_list_button').toggle(); return false;" >Toggle Me</a></small>
        <br />
        Web Controls <editable:EditableDropDownList ID="EditableDropDownList3" runat="server" ClientIDMode="Static" Width="250" Sorted="true">
        </editable:EditableDropDownList>
        <br /><br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
        <br /><br />
        <asp:GridView ID="grdResults" runat="server" CellSpacing="3" CellPadding="1">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
