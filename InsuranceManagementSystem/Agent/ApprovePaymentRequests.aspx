<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="ApprovePaymentRequests.aspx.cs" Inherits="InsuranceManagementSystem.Agent.ApprovePaymentRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center"><b>APPROVE PENDING PAYMENT REQUESTS</b></h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
                <div class="col-md-6">
                    <label for="payIDItems" style="font-size: 20px; font-weight: 600">Payment ID: </label>
                    <asp:DropDownList ID="payIDItems" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                        Text="Approve Payment Request" OnClick="btnApprove_Click" />
                </div>
            </div>
        </div>
</asp:Content>
