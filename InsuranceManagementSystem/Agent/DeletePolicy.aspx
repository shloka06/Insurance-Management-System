<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="DeletePolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.DeletePolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-center"><b>DELETE POLICY</b></h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5 align-content-center justify-content-center">
            <div class="col-md-6">
                <label style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:DropDownList ID="policyIDItems" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 text-center align-content-center justify-content-center">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnDel" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Delete Policy" OnClick="btnDel_Click" />
            </div>
        </div>

    </div>
    </div>

</asp:Content>