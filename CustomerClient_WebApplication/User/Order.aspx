<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="CustomerClient_WebApplication.User.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.1/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="path/to/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="./css/order.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section class="inner_page_head">
         <div class="container_fuild">
            <div class="row">
               <div class="col-md-12">
                  <div class="full">
                     <h3>Order Now</h3>
                  </div>
               </div>
            </div>
         </div>
      </section>
<br />
    
<div class="example" style="margin:auto;max-width:300px">
    <asp:TextBox ID="TextBox1" runat="server"  placeholder="Search flower"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
 
</div>
    <br />
    <br />


    <asp:GridView ID="GridView1" runat="server" Width="1000px" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" BorderWidth="5px" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
     </asp:GridView>
     


    <div class="wrapper">
    <div class="title">
      Order
    </div>
    <div class="form">
       
        <div class="inputfield">
          <label>Order ID</label>
          <asp:TextBox ID="txtorder" runat="server" Cssclass="input"></asp:TextBox>
       </div>  
          <div class="inputfield">
          <label>Customer Name</label>
          <asp:TextBox ID="txtcustomer1" runat="server" Cssclass="input"></asp:TextBox>
       </div> 
       <div class="inputfield">
          <label>Flower Name</label>
        <asp:DropDownList ID="txtflower" runat="server" Cssclass="input"></asp:DropDownList>
     
       </div>  
    <br />
       <div class="inputfield">
          <label>Quntity</label>
         <asp:TextBox ID="txtqty" runat="server" Cssclass="input"></asp:TextBox>
       </div>  
   
      <div class="inputfield">
   <asp:Button ID="Button2" runat="server" Text="Order" class="btn" OnClick="Button2_Click"/>
      </div>

    
    
</div>	
	     
       </div>



</asp:Content>
