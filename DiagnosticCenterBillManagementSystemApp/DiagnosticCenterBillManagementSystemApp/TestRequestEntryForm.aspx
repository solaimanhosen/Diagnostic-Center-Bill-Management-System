<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntryForm.aspx.cs" Inherits="DiagnosticCenterBillManagementSystemApp.TestRequestEntryForm" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8">
    <title>Diagnostic Center Management</title>
    <!-- Stylesheets -->
    <link rel="shortcut icon" type="image/png" href="images/favicon.png" />
    <link href="CSS/bootstrap.css" rel="stylesheet">
    <link href="CSS/style.css" rel="stylesheet">    
    <!-- Responsive -->
    <link href="CSS/responsive.css" rel="stylesheet"> 
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">

    <style type="text/css">
        .auto-style1 {
            width: 172px;
        }
        .auto-style2 {
            width: 172px;
            height: 47px;
        }
        .auto-style3 {
            height: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" GroupingText="Test Request Entry" Width ="600px" Height="200px">
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Name of the Patient"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="patientNameTextBox" runat="server" Width="143px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Date of Birth"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="patientBirthDateTextBox" runat="server" Width="143px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label3" runat="server" Text="Mobile No"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="patientMobileNoTextBox" runat="server" Width="143px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label4" runat="server" Text="Select Test"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="selectTestDropDownList" runat="server" Width="147px" AutoPostBack="True" onselectedindexchanged="itemSelected" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Fee"></asp:Label>
                        <asp:TextBox ID="testFeeTextBox" runat="server" style="margin-left: 18px" Width="99px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="addButton" runat="server" Text="ADD" OnClick="addButton_Click" />
                    </td>
                </tr>
            </table>
            
        </asp:Panel>
        <br/>
        <asp:GridView ID="selectedTestGridView" runat="server">
           
        </asp:GridView>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Total"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="totalAmountTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
