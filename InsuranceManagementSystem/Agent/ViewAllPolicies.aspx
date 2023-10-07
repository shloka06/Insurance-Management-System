<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="ViewAllPolicies.aspx.cs" Inherits="InsuranceManagementSystem.Agent.ViewAllPolicies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center fw-bold">POLICY LIST</h3>

            <div class="row mb-3 align-content-center justify-content-center">
                <div class="mt-3">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"></asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
