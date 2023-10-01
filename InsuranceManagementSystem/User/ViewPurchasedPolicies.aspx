<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true"
    CodeBehind="ViewPurchasedPolicies.aspx.cs" Inherits="InsuranceManagementSystem.User.ViewPurchasedPolicies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center fw-bold">PURCHASED POLICIES</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-3">
            <div class="col-md-6">
                <asp:GridView ID="purchasedPolicyData" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

    </div>
    </div>

</asp:Content>
