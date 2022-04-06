<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddJobCategory.aspx.cs" Inherits="WebApplication5.AddJobCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <center>
                            <img width="100" src="imgs/generaluser.png" class="auto-style2" />
                        </center>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <center>
                            <h4>Job Category</h4>
                        </center>
                    </div>
                </div>
                <hr class="mx-auto">
                <div class="row">
                    <div class="col-md-6 mx-auto">
                        <div class="card">
                            <div class="card-body">
                                
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Job Catgeory</label>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="This field is required" ControlToValidate="JobCategory" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="JobCategory" runat="server" placeholder="Name" CausesValidation="True" TextMode="SingleLine"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col mx-auto">
                                        <center>
                                            <div class="form-group">
                                                <asp:Button class="btn btn-primary btn-block btn-md" ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Add Category"></asp:Button>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                     <div class="col-md-6">
                        <asp:GridView ID="GridView1" runat="server" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" Width="369px">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
                <br />
                
            </div>
        </div>
    </div>
    <br />

    <br />

</asp:Content>
