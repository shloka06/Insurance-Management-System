﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="AddInsurerPolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddInsurerPolicy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 1080px; background-repeat: repeat; background-size: cover; background-attachment: fixed">
    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-center"><b>ADD POLICY FOR INSURER</b></h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtInsID" style="font-size: 20px; font-weight: 600">Insurer ID: </label>
                <asp:TextBox ID="txtInsID" runat="server" CssClass="form-control" placeholder="Enter Insurer ID"
                    required></asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="btnGetBen" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Get Benefactors" OnClick="btnGetBen_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:GridView ID="BenefactorGridView" runat="server" CssClass="table table-hover table-bordered">
                </asp:GridView>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtBenID" style="font-size: 20px; font-weight: 600">Benefactor ID: </label>
                <asp:TextBox ID="txtBenID" runat="server" CssClass="form-control" placeholder="Enter Benefactor ID"
                    ValidationGroup="valAddGroup"></asp:TextBox>
                <asp:RequiredFieldValidator runat = "server" 
            ErrorMessage = "Field cannot be empty."
            ValidationGroup="valAddGroup"
            ControlToValidate = "txtBenID"/>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtPolID" style="font-size: 20px; font-weight: 600">Policy ID: </label>
                <asp:TextBox ID="txtPolID" runat="server" CssClass="form-control" placeholder="Enter Policy ID"
                   ValidationGroup="valAddGroup"></asp:TextBox>
                <asp:RequiredFieldValidator runat = "server" 
            ErrorMessage = "Field cannot be empty."
            ValidationGroup="valAddGroup"
            ControlToValidate = "txtPolID"/>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Policy For Insurer" OnClick="btnAdd_Click" OnClientClick="javascript:return   validatePage();"/>
            </div>
        </div>

    </div>
</div>

</asp:Content>