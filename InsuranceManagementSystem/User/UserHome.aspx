<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true"
    CodeBehind="UserHome.aspx.cs" Inherits="InsuranceManagementSystem.User.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h1 style=" text-align: center; font-family: 'Lucida Calligraphy'; font-weight: bold; font-size: 50px;">Welcome to Guardian Life Insurance!</h1>
            <image src="../Images/background.jpg" style="margin-inline: 200px">
        </image>
        </div>


</asp:Content>
