<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication5.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="imgs/adminuser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>User Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr>
                                </center>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <div class="m-3">
                                <label class="form-label">User Email</label>
                                <asp:TextBox CssClass="form-control" ID="mail" required="true" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="Red" ErrorMessage="Please Enter Valid Email Address"></asp:RegularExpressionValidator>
                                
                            </div>
                            <div class="m-3">
                                <label class="form-label">User Password</label>
                                <asp:TextBox CssClass="form-control" required="true" ID="password" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                
                            </div>
                            <div class="m-3">
                                <asp:Button class="btn btn-success w-100 btn-lg" ID="LoginCompanyBtn" runat="server" Text="Login As Company" OnClick="LoginCompanyBtn_Click"/>
                            </div>
                            <div class="m-3">
                                <asp:Button class="btn btn-success w-100 btn-lg" ID="LoginJobApplicantBtn" runat="server" Text="Login As Job Applicant" OnClick="LoginJobApplicantBtn_Click"/>
                            </div>
                            <div class="m-3">
                                <asp:Button class="btn btn-success w-100 btn-lg" ID="LoginAdminBtn" runat="server" Text="Login As Admin" OnClick="LoginAdminBtn_Click"/>
                            </div>
                            
                        </div>
                    </div>

                </div>

                <%--<a href="#"> <span><<</span> Back to Home</a> <br \><br \>--%>
            </div>
        </div>
    </div>
</asp:Content>
