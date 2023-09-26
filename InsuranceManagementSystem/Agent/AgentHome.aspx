<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="AgentHome.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AgentHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url('../Images/bgimg.jpg'); width=100%; height:720px; background-repeat: no-repeat; background-size: cover; background-attachment:fixed">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center">AGENT HOME PAGE</h2>
        </div>
    </div>

</asp:Content>
