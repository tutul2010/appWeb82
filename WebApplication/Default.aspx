<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="centered">
        <table>
            <tr>
                <td colspan="2">Please Fill the below Form. (*) marked data is mandatory
                </td>
            </tr>
            <tr>
                <td>First Name: *
                </td>
                <td>
                    <asp:TextBox ID="txtFNm" runat="server">Joe</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorfNm" runat="server"
                        ErrorMessage="Please enter First name" ControlToValidate="txtFNm" ValidationGroup="chk" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Last Name: *
                </td>
                <td>
                    <asp:TextBox ID="txtLNm" runat="server">nash</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLnm" runat="server"
                        ErrorMessage="Please enter last name" ControlToValidate="txtLNm" ValidationGroup="chk" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Education Level : *
                </td>
                <td>
                    <asp:TextBox ID="txtEduLvl" runat="server">B.Tech</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEdulv" runat="server"
                        ErrorMessage="Please enter Education level" ControlToValidate="txtEduLvl" ValidationGroup="chk" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Skill Type: *
                </td>
                <td>
                    <asp:DropDownList ID="drpSkill" runat="server">
                        <asp:ListItem Text="Select Skill" Value="0"></asp:ListItem>
                        <asp:ListItem Text="DotNet" Value="DotNet"></asp:ListItem>
                        <asp:ListItem Text="java" Value="java"></asp:ListItem>
                        <asp:ListItem Text="PlSql" Value="PlSql"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Email :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server">someone@domain.com</asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server"
                        ErrorMessage="Please enter Email" ControlToValidate="txtEmail" ValidationGroup="chk" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="Please enter proper format email" 
                    ForeColor="Red" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="chk"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>Contact No : *
                </td>
                <td>
                    <asp:TextBox ID="txtContNo" runat="server">9748809314</asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorcont" runat="server"
                        ErrorMessage="Please enter contact no" ControlToValidate="txtContNo" ValidationGroup="chk" ForeColor="Red"></asp:RequiredFieldValidator>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidatorConctNo" runat="server" ErrorMessage="Please enter 10 digit contact no" 
                    ForeColor="Red" ControlToValidate="txtContNo" ValidationExpression="[0-9]{10}" ValidationGroup="chk"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="align-items:center">
                    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="chk" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="" EnableViewState="false"></asp:Label>
                  
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
