<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="ViewClaimRequests.aspx.cs" Inherits="InsuranceManagementSystem.Agent.ViewClaimRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 1080px;
    background-repeat: no-repeat; background-size: cover; background-attachment: fixed">
    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center">VIEW PENDING CLAIM REQUESTS</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnView" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="View Claim Requests" OnClick="btnView_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

    </div>
</div>

</asp:Content>
