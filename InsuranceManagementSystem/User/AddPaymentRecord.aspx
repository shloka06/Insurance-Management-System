<%@ Page Title="" Language="C#" MasterPageFile="~/User/UserMst.Master" AutoEventWireup="true"
    CodeBehind="AddPaymentRecord.aspx.cs" Inherits="InsuranceManagementSystem.User.AddPaymentRecord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center">ADD PAYMENT RECORD</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:DropDownList ID="policyIDItems" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnView" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="View Next Payment" OnClick="btnView_Click" />
            </div>
        </div>


        <div class="container">
            <div class="row">

                <div class="col mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
                    <div class="col-md-6">
                        <asp:GridView ID="PaymentGrid" runat="server" CssClass="table table-hover table-bordered">
                        </asp:GridView>
                    </div>
                </div>

                <div class="col mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
                    <div class="col-md-3 col-md-offset-2 mb-3 ">
                        <asp:Button ID="btnPay" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                            Text="Pay Now" OnClick="btnPay_Click" />
                    </div>
                </div>


            </div>
        </div>






    </div>
    </div>

</asp:Content>
