<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="DeletePolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.DeletePolicy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 1080px; background-repeat: repeat; background-size: cover; background-attachment: fixed">
    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-center"><b>DELETE POLICY</b></h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtPolID" style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:TextBox ID="txtPolID" runat="server" CssClass="form-control" placeholder="Enter ID of Policy to be Deleted" required></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnDel" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Delete Policy" OnClick="btnDel_Click" />
            </div>
        </div>

    </div>
</div>

</asp:Content>
