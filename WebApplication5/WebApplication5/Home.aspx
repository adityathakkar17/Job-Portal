<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Home.aspx.cs" Inherits="WebApplication5.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
        }

        .auto-style2 {
            margin-left: 490px;
        }

        .auto-style3 {
            margin-left: 493px;
        }
        #services, #service1 {
            padding: 10px 0 40px 0;
        }

            #services .box, #service1 .box {
                padding: 20px;
                position: relative;
                overflow: hidden;
                border-radius: 10px;
                margin: 0 10px 40px 10px;
                background: #fff;
                box-shadow: 0 10px 29px 0 rgba(68, 88, 144, 0.1);
                transition: all 0.3s ease-in-out;
                text-align: center;
            }

                #services .box:hover, #service1 .box:hover {
                    transform: scale(1.1);
                }

            #services .title, #service1 .title {
                font-weight: 700;
                font-size: 18px;
                padding-top: 20px;
            }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="services" class="services section-bg mt-5">
        <div class="container" data-aos="fade-up">

            <div class="section-title">
                <h4>Job Posts</h4>
            </div>
            <asp:Panel CssClass="row" ID="Panel1" runat="server">
            <asp:DataList ID="DataList1" runat="server" OnItemCommand="DataList1_ItemCommand" DataKeyField="Id" RepeatColumns="4">
                
                <ItemTemplate>
                    <div  data-aos="zoom-in" data-aos-delay="100">
                        <div class="box">
                            <asp:Label ID="lbljobId" runat="server" Visible="false" Text='<%# Eval("Id") %>'></asp:Label>
                        <h4 class="title"><asp:Label ID="lbljobname" runat="server" Text='<%# Eval("Name") %>'></asp:Label></h4>
                            <asp:Button ID="btnedit" class="btn btn-primary  btn-sm" runat="server" Text="Show Jobs" CommandName="Select" CommandArgument="<%# ((DataListItem) Container).ItemIndex %>" CausesValidation="False" />
                    </div>
                </div> 
                        
                </ItemTemplate>
            </asp:DataList>
            </asp:Panel>
            
        </div>
    </section>
       <%-- <asp:GridView ID="GridView1" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" runat="server" CssClass="auto-style1" Width="486px">
            <Columns>
                <asp:TemplateField Visible="false">
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblsubsId" runat="server" Text="Id"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblsubsId" runat="server" Text='<%# Eval("Id") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblsubsname" runat="server" Text="Job Post"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblsubsname" runat="server" Text='<%# Eval("Name") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="hdrow" />
                    <ItemTemplate>
                        <asp:Button ID="btnedit" class="btn btn-primary  btn-sm" runat="server" Text="Show Jobs" CommandName="Select" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>--%>

    </p>
    <p>
        <center>
            <asp:Label ID="Label2" runat="server"></asp:Label></center>
    </p>
    <p>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" CssClass="auto-style2" Width="495px" CellPadding="4" ForeColor="#333333" GridLines="None">
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
            <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblnameId" runat="server" Text="Company"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblnameId" runat="server" Text='<%# Eval("name") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlbllocatoinId" runat="server" Text="Location"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbllocatoinId" runat="server" Text='<%# Eval("location") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblemailId" runat="server" Text="Email"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblemailId" runat="server" Text='<%# Eval("email") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlbldurationId" runat="server" Text="Duration"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldurationId" runat="server" Text='<%# Eval("duration") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblvacancyId" runat="server" Text="Vacancy"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblvacancyId" runat="server" Text='<%# Eval("vacancy") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:GridView ID="GridView3" runat="server" OnRowCommand="GridView3_RowCommand" AutoGenerateColumns="false" CssClass="auto-style3" Width="493px" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField Visible="false">
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblsubsId" runat="server" Text="Id"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbljobId" runat="server" Text='<%# Eval("Id") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblnameId" runat="server" Text="Company"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblnameId" runat="server" Text='<%# Eval("name") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlbllocatoinId" runat="server" Text="Location"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbllocatoinId" runat="server" Text='<%# Eval("location") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblemailId" runat="server" Text="Email"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblemailId" runat="server" Text='<%# Eval("email") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlbldurationId" runat="server" Text="Duration"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbldurationId" runat="server" Text='<%# Eval("duration") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField >
                    <HeaderStyle CssClass="hdrow" />
                    <HeaderTemplate>
                        <asp:Label ID="hlblvacancyId" runat="server" Text="Vacancy"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblvacancyId" runat="server" Text='<%# Eval("vacancy") %>'>  
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle CssClass="hdrow" />
                    <ItemTemplate>
                        <asp:Button ID="btnapply" class="btn btn-primary  btn-sm" runat="server" Text="Apply" CommandName="Apply" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="False" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
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
    </p>

</asp:Content>
