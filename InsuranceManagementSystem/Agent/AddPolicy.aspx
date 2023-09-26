<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="AddPolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddPolicy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 720px; background-repeat: no-repeat; background-size: cover; background-attachment: fixed">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h3 class="text-center">ADD NEW POLICY</h3>
            
            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPolicy" style="font-size:20px">Policy Name: </label>
                    <asp:TextBox ID="txtPolicy" runat="server" CssClass="form-control" placeholder="Enter Policy Name" required></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPolicy" style="font-size: 20px">Policy Type: </label>
                    <div class="dropdown">
                        <button class="btn btn-info dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Select Policy Type
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                            <a class="dropdown-item" href="#">Term Policy</a>
                            <a class="dropdown-item" href="#">Whole Life Policy</a>
                            <a class="dropdown-item" href="#">Endowment Policy</a>
                        </div>
                    </div>
                    <%--<asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="value" Selected="True">Select Policy Type</asp:ListItem>
                        <asp:ListItem Value="value">Term Policy</asp:ListItem>
                        <asp:ListItem Value="value">Whole Life Policy</asp:ListItem>
                        <asp:ListItem Value="value">Endowment Policy</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter Policy Name" required></asp:TextBox>--%>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Policy" OnClick="btnAdd_Click" />
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered"></asp:GridView>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
