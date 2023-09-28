<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="UpdateClaimStatus.aspx.cs" Inherits="InsuranceManagementSystem.Agent.UpdateClaimStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 1080px;
        background-repeat: repeat; background-size: cover; background-attachment: fixed">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center"><b>UPDATE CLAIM STATUS</b></h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtClaimID" style="font-size: 20px; font-weight: 600">
                        Claim ID:
                    </label>
                    <asp:TextBox ID="txtClaimID" runat="server" CssClass="form-control" placeholder="Enter Claim ID"
                        required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="txtClaimID" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                        Text="Get Claim Status" OnClick="btnGet_Click" />
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <label for="ClaimGridView" style="font-size: 20px; font-weight: 600">Benefactors:
                    </label>
                    <asp:GridView ID="ClaimGridView" runat="server" CssClass="table table-hover table-bordered">
                    </asp:GridView>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label style="font-size: 20px; font-weight: 600">Update Claim Status: </label>
                    <div class="dropdown" data-toggle="dropdown">
                        <select id="claimStatusItems" name="claimStatusItems" class="form-control">
                            <option selected>Submitted</option>
                            <option>Pending</option>
                            <option>Under Review</option>
                            <option>Approved</option>
                            <option>Paid Out</option>
                            <option>Closed</option>
                            <option>Rejected</option>
                        </select>
                    </div>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                        Text="Update Claim Status" OnClick="btnUpdate_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
