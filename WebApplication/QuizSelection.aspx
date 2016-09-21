<%@ Page Language="C#" MasterPageFile="~/Site-quix.Master" AutoEventWireup="true"
    CodeBehind="QuizSelection.aspx.cs" Inherits="WebApplication.QuizSelection" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
 
    <br />
    &nbsp;
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
                      <asp:CompareValidator ID="CompareValidatorQuizeType" runat="server" ErrorMessage="Please select a Quize Type" ControlToValidate="drpQuizeType"
                          ForeColor="Red"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSelect" runat="server" Text="Select" Width="84px" OnClick="btnSelect_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
