<%@ Page Title="" Language="C#" MasterPageFile="~/Agent/AgentMst.Master" AutoEventWireup="true"
    CodeBehind="AddInsurer.aspx.cs" Inherits="InsuranceManagementSystem.Agent.AddInsurer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image: url('../Images/bgimg.jpg'); width=100%; height: 1400px;
        background-repeat: repeat; background-size: cover; background-attachment: fixed">
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center"><b>ADD NEW INSURER</b></h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtInsurerFName" style="font-size: 20px; font-weight: 600">
                        Insurer First
                        Name:
                    </label>
                    <asp:TextBox ID="txtInsurerFName" runat="server" CssClass="form-control" placeholder="Enter Insurer First Name"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtInsurerLName" style="font-size: 20px; font-weight: 600">
                        Insurer Last
                        Name:
                    </label>
                    <asp:TextBox ID="txtInsurerLName" runat="server" CssClass="form-control" placeholder="Enter Insurer Last Name"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtInsurerDOB" style="font-size: 20px; font-weight: 600">
                        Date of Birth:
                    </label>
                    <input name="txtInsurerDOB" type="date" class="form-control"></input>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPhNo1" style="font-size: 20px; font-weight: 600">
                        Primary Phone Number:
                    </label>
                    <asp:TextBox ID="txtPhNo1" runat="server" CssClass="form-control" placeholder="Enter Primary Phone Number"
                        required>
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                        ControlToValidate="txtPhNo1" runat="server"
                        ErrorMessage="Min 7, Max 10 Digits Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="^[0-9]{7,10}$" />
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPhNo2" style="font-size: 20px; font-weight: 600">
                        Alternate Phone Number
                        1:
                    </label>
                    <asp:TextBox ID="txtPhNo2" runat="server" CssClass="form-control" placeholder="Enter Alternate Phone Number 1 (Optional)">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                        ControlToValidate="txtPhNo2" runat="server"
                        ErrorMessage="Min 7, Max 10 Digits Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="^[0-9]{7,10}$" />
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPhNo3" style="font-size: 20px; font-weight: 600">
                        Alternate Phone Number
                        2:
                    </label>
                    <asp:TextBox ID="txtPhNo3" runat="server" CssClass="form-control" placeholder="Enter Alternate Phone Number 2 (Optional)">
                    </asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                        ControlToValidate="txtPhNo3" runat="server"
                        ErrorMessage="Min 7, Max 10 Digits Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="^[0-9]{7,10}$" />
                    </asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtHouseNum" style="font-size: 20px; font-weight: 600">
                        House Number:
                    </label>
                    <asp:TextBox ID="txtHouseNum" runat="server" CssClass="form-control" placeholder="Enter House/Building Number"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtStreet" style="font-size: 20px; font-weight: 600">
                        Street Name:
                    </label>
                    <asp:TextBox ID="txtStreet" runat="server" CssClass="form-control" placeholder="Enter Street Name"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtArea" style="font-size: 20px; font-weight: 600">
                        Area:
                    </label>
                    <asp:TextBox ID="txtArea" runat="server" CssClass="form-control" placeholder="Enter Area Name"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtCity" style="font-size: 20px; font-weight: 600">
                        City:
                    </label>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" placeholder="Enter City Name"
                        required>
                    </asp:TextBox>
                </div>
            </div>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-6">
                    <label for="txtPincode" style="font-size: 20px; font-weight: 600">
                        Pincode: 
                    </label>
                    <asp:TextBox ID="txtPincode" runat="server" CssClass="form-control" placeholder="Enter Pin Code"
                        required></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                        ControlToValidate="txtPincode" runat="server"
                        ErrorMessage="Only Numbers Allowed"
                        ForeColor="White"
                        BackColor="Red"
                        ValidationExpression="\d+">
                    </asp:RegularExpressionValidator>
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
                        Text="Add Insurer" OnClick="btnAdd_Click" />
                </div>
            </div>

        </div>
    </div>

</asp:Content>
