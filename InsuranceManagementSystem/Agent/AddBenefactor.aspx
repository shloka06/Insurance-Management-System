<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="AddBenefactor.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddBenefactor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container p-md-4 p-sm-4">
        <div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
        <h2 class="text-center"><b>ADD NEW BENEFACTOR</b></h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtInsID" style="font-size: 20px; font-weight: 600">INSURER ID: </label>
                <asp:TextBox ID="txtInsID" runat="server" CssClass="form-control" placeholder="Enter Insurer ID"
                    required>
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtBenefactorFName" style="font-size: 20px; font-weight: 600">
                    Benefactor First Name:
                </label>
                <asp:TextBox ID="txtBenefactorFName" runat="server" CssClass="form-control" placeholder="Enter Benefactor's First Name"
                    required>
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtBenefactorLName" style="font-size: 20px; font-weight: 600">
                    Benefactor Last Name:
                </label>
                <asp:TextBox ID="txtBenefactorLName" runat="server" CssClass="form-control" placeholder="Enter Benefactor's Last Name"
                    required>
                </asp:TextBox>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label for="txtBenefactorDOB" style="font-size: 20px; font-weight: 600">
                    Date of Birth of Benefactor:
                </label>
                <input name="txtBenefactorDOB" type="date" class="form-control"></input>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
            <div class="col-md-6">
                <label style="font-size: 20px; font-weight: 600">
                    Relationship of Benefactor with Insurer:
                </label>
                <div class="dropdown" data-toggle="dropdown">
                    <select id="relationshipItems" name="relationshipItems" class="form-control" required>
                        <option selected>Child</option>
                        <option>Spouse</option>
                        <option>Mother</option>
                        <option>Father</option>
                        <option>Mother-In-Law</option>
                        <option>Father-In-Law</option>
                    </select>
                </div>
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-3 col-md-offset-2 mb-3">
                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9"
                    Text="Add Benefactor" OnClick="btnAdd_Click" />
            </div>
        </div>

    </div>
</div>

</asp:Content>
