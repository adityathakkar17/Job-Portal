<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManagePost.aspx.cs" Inherits="WebApplication5.ManagePost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            margin-left: 85px;
        }
    </style>
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
                            <h4>Post Section</h4>
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
                                        <label>Post Name</label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Duration</label>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="This field is required" ControlToValidate="Duration" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="Duration" runat="server" placeholder="Number of Years" CausesValidation="True" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Vacancy</label>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required" ControlToValidate="Vacancy" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="Vacancy" runat="server" placeholder="Number of Posts" CausesValidation="True" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label>Salary</label>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This field is required" ControlToValidate="Salary" ForeColor="Red"></asp:RequiredFieldValidator></span>
                                        <div class="form-group">
                                            <asp:TextBox CssClass="form-control" ID="Salary" runat="server" placeholder="Rupees" CausesValidation="True" TextMode="Number"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col mx-auto">
                                        <center>
                                            <div class="form-group">
                                                <asp:Button class="btn btn-primary btn-block btn-md" ID="btnInsert" runat="server" OnClick="BtnInsert_Click" Text="Add Post"></asp:Button>
                                            </div>
                                        </center>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-7">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing" OnRowCommand="GridView1_RowCommand" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="625px" CssClass="auto-style3">
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
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <HeaderStyle CssClass="hdrow" />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblId" runat="server" Text="Id"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'>  
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="hdrow" />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblname" runat="server" Text="Name"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("name") %>'>  
                                        </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="hdrow" />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblduration" runat="server" Text="Duration"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblduration" runat="server" Text='<%# Eval("Duration") %>'>  
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtduration" runat="server" Text='<%# Eval("Duration") %>'>  
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="hdrow" />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblvacancy" runat="server" Text="Vacancy"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblvacancy" runat="server" Text='<%# Eval("Vacancy") %>'>  
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtvacancy" runat="server" Text='<%# Eval("Vacancy") %>'>  
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="hdrow" />
                                    <HeaderTemplate>
                                        <asp:Label ID="hlblsalary" runat="server" Text="Salary"></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblsalary" runat="server" Text='<%# Eval("Salary") %>'>  
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtsalary" runat="server" Text='<%# Eval("Salary") %>'>  
                                        </asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle CssClass="hdrow" />
                                    <ItemTemplate>
                                        <asp:Button ID="btnedit" class="btn btn-primary  btn-sm" runat="server" Text="Edit" CommandName="Edit" CausesValidation="False" />
                                        <asp:Button ID="btndelete" class="btn btn-primary  btn-sm" runat="server" Text="Delete" CommandName="Delete" CausesValidation="False" />
                                        <asp:Button ID="Button2" class="btn btn-primary  btn-sm" runat="server" Text="Show Job Applicants" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="False" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" CommandName="Update" CausesValidation="False" />
                                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" />
                                        <asp:Button ID="Button1" runat="server" Text="Cancel" CommandName="Cancel" CausesValidation="False" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-5">
                        <asp:GridView ID="GridView2" runat="server" CellPadding="4" CssClass="auto-style2" ForeColor="#333333" GridLines="None" Width="369px">
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
            </div>
        </div>
    </div>
    <br />

    <br />
</asp:Content>
