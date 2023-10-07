<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="AddInsurerPolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddInsurerPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-center"><b>ADD POLICY FOR INSURER</b></h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="txtInsID" style="font-size: 20px; font-weight: 600">Insurer ID: </label>
                <asp:TextBox ID="txtInsID" runat="server" CssClass="form-control" placeholder="Enter Insurer ID"
                    required></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnGetBen" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Get Available Options" OnClick="btnGetBen_Click" />
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

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="benIDItems" style="font-size: 20px; font-weight: 600">
                    Benefactor ID:
                </label>
                <asp:DropDownList ID="benIDItems" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>


        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label for="polIDItems" style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:DropDownList ID="polIDItems" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Add Policy For Insurer" OnClick="btnAdd_Click" OnClientClick="javascript:return   validatePage();" />
            </div>
        </div>

    </div>
    </div>

</asp:Content>
