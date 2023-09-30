<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true"
    CodeBehind="ViewUpcomingPayments.aspx.cs" Inherits="InsuranceManagementSystem.User.ViewUpcomingPayments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center">VIEW SCHEDULE FOR UPCOMING PAYMENTS</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtPolID" style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:TextBox ID="txtPolID" runat="server" CssClass="form-control" placeholder="Enter Policy ID"
                    required></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnGetPayments" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="View Upcoming Payments" OnClick="btnGetPayments_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:GridView ID="PaymentsGridView" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

    </div>
    </div>

</asp:Content>
