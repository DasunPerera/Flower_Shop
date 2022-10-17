<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderWebForm.aspx.cs" Inherits="CustomerClient_WebApplication.OrderWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
       <link rel="stylesheet" type="text/css" href="css/style.css"/>
</head>
<body>
    <form id="form1" runat="server">
                    <nav>
		<div class="logo">
			<p>Black Lotus </p>
		</div>
		<ul>
				<li><a href="SearchProductWebForm.aspx">Search & Stock</a></li>
			<li><a href="CategoryWebForm.aspx">Category</a></li>
            <li><a href="CategoryWebForm2.aspx">Update Category</a></li>
			<li><a href="OrderWebFrom.aspx">Order</a></li>
		</ul>
	</nav>
        <br />
        <br />
        <br />
        <br />

            
             <div class ="container">
       <div class ="form-horizontal">
           
           <br />
           <br />
           <h2>Manage Order</h2>
           <hr />

           <div class ="form-group">
               <asp:Label ID="Label1" runat="server" CssClass ="col-md-2 control-label" Text="Order Id"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtOrderId" CssClass ="form-control" runat="server"></asp:TextBox>
                  
                 </div> 
               </div>
                 <div class ="form-group">
               <asp:Label ID="Label2" runat="server" CssClass ="col-md-2 control-label" Text="Customer"></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtCustomer" CssClass ="form-control" runat="server"></asp:TextBox>
                  
                  
               </div>
           </div>

            <div class ="form-group">
               <asp:Label ID="Label3" runat="server" CssClass ="col-md-2 control-label" Text="Flower Name"></asp:Label>
               <div class ="col-md-3">
                   <asp:DropDownList ID="txtflower" runat="server"  CssClass ="form-control"></asp:DropDownList>
     
               </div>
           </div>
           
           <div class ="form-group">
               <asp:Label ID="Label5" runat="server" CssClass ="col-md-2 control-label" Text="Quantity" ></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtqty" CssClass ="form-control" runat="server"  ></asp:TextBox>
                  
               </div>
           </div>

             <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAdd" CssClass ="btn btn-success " runat="server" Text="Submit" OnClick="btnAdd_Click"  />
                        <asp:Button ID="Button1" CssClass ="btn btn-success " runat="server" Text="Update" OnClick="Button1_Click" />
                           <asp:Button ID="Button2" CssClass ="btn btn-success " runat="server" Text="Delete" OnClick="Button2_Click" />
                        
                    </div>
                </div>
        
           <br />
           <br />

       
       
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="900px" Font-Bold="True" Font-Size="Large">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
             </asp:GridView>
            </div>
           
           </div>
                 

    </form>
</body>
</html>
