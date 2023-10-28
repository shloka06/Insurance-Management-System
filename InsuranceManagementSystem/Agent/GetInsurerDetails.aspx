<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="GetInsurerDetails.aspx.cs" Inherits="InsuranceManagementSystem.Agent.GetInsurerDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h3 class="text-center fw-bold">GET INSURER DETAILS</h3>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="searchInsID" style="font-size: 20px; font-weight: 600">Insurer ID: </label>
                <asp:TextBox ID="searchInsID" runat="server" CssClass="form-control" placeholder="Enter Insurer ID"
                    required></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnGet" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Get Insurer Details" OnClick="btnGet_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="txtInsID" style="font-size: 20px; font-weight: 600">Insurer ID: </label>
                <asp:TextBox ID="txtInsID" runat="server" CssClass="form-control" ReadOnly="true"
                    placeholder="Insurer ID">
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="txtInsName" style="font-size: 20px; font-weight: 600">
                    Insurer Name:
                </label>
                <asp:TextBox ID="txtInsName" runat="server" CssClass="form-control" ReadOnly="true"
                    placeholder="Insurer Name">
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="txtDOB" style="font-size: 20px; font-weight: 600">Date of Birth: </label>
                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" ReadOnly="true" placeholder="Insurer DOB">
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-5 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="txtAddr" style="font-size: 20px; font-weight: 600">Address: </label>
                <asp:TextBox ID="txtAddr" runat="server" CssClass="form-control" ReadOnly="true"
                    placeholder="Insurer Address">
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <asp:GridView ID="PhoneNumGridView" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 align-content-center justify-content-center">
            <div>
                <asp:GridView ID="BenefactorGridView" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 align-content-center justify-content-center">
            <div>
                <asp:GridView ID="PolicyGridView" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>


    </div>

</asp:Content>