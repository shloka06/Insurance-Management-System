<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true" CodeBehind="AddPolicy.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddPolicy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height=100%; background-repeat: repeat; background-size: cover; background-attachment: fixed">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center"><b>ADD NEW POLICY</b></h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPolicy" style="font-size: 20px; font-weight: 600">Policy Name: </label>
                    <asp:TextBox ID="txtPolicy" runat="server" CssClass="form-control" placeholder="Enter Policy Name" required></asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label style="font-size: 20px; font-weight: 600">Policy Type: </label>
                    <div class="dropdown" data-toggle="dropdown">
                        <select id="policyTypeItems" name="policyTypeItems" class="form-control">
                            <option selected>Term Policy</option>
                            <option>Whole Life Policy</option>
                            <option>Endowment Policy</option>
                        </select>
                    </div>   
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtInsuredAmt" style="font-size: 20px; font-weight: 600">Insured Amount: </label>
                    <asp:TextBox ID="txtInsuredAmt" runat="server" CssClass="form-control" placeholder="Enter Insured Amount" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="txtInsuredAmt" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label style="font-size: 20px; font-weight: 600">Payment Schedule: </label>
                    <div class="dropdown" data-toggle="dropdown">
                        <select id="paymentSchedItems" name="paymentSchedItems" class="form-control" required>
                            <option selected>Monthly</option>
                            <option>Quarterly</option>
                            <option>Semi-Annual</option>
                            <option>Annual</option>
                        </select>
                    </div>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPaymentAmount" style="font-size: 20px; font-weight: 600">Payment Amount: </label>
                    <asp:TextBox ID="txtPaymentAmount" runat="server" CssClass="form-control" placeholder="Enter Payment Amount" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        ControlToValidate="txtPaymentAmount" runat="server"
                        ErrorMessage="Only Numbers allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPaymentDuration" style="font-size: 20px; font-weight: 600">Payment Duration [Years]: </label>
                    <asp:TextBox ID="txtPaymentDuration" runat="server" CssClass="form-control" placeholder="Enter Payment Duration in Years" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        ControlToValidate="txtPaymentDuration" runat="server"
                        ErrorMessage="Only Numbers Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtCoverDuration" style="font-size: 20px; font-weight: 600">Cover Duration [Years]: </label>
                    <asp:TextBox ID="txtCoverDuration" runat="server" CssClass="form-control" placeholder="Enter Cover Duration in Years" required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        ControlToValidate="txtCoverDuration" runat="server"
                        ErrorMessage="Only Numbers Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Add Policy" OnClick="btnAdd_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
