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

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPayID" style="font-size: 20px; font-weight: 600">Payment ID:
                    </label>
                    <asp:TextBox ID="txtPayID" runat="server" CssClass="form-control" placeholder="Enter Payment ID"
                        required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="txtPayID" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                        Text="Approve Payment Request" OnClick="btnApprove_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
