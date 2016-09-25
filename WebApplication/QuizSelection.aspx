<%@ Page Language="C#" MasterPageFile="~/Site-quix.Master" AutoEventWireup="true"
    CodeBehind="QuizSelection.aspx.cs" Inherits="WebApplication.QuizSelection" %>
<asp:Content ID="HeaderContent" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    &nbsp;
    <div class="centered">
        <table>
            <tr>
                <td colspan="2">Select Any Quize Type. (*) marked data is mandatory
                </td>
            </tr>
            <tr>
                <td colspan="2">Quize Type* :
                    <asp:DropDownList ID="drpQuizeType" runat="server" EnableViewState="true">
                    </asp:DropDownList>&nbsp;
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorDrpQuize"  runat="server" InitialValue="0"  ValidationGroup="chk" 
                         ControlToValidate="drpQuizeType" ForeColor="Red"
                             ErrorMessage="Please select a Quize Type"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSelect" runat="server" Text="Select" Width="84px" OnClick="btnSelect_Click" ValidationGroup="chk"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
