<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CategoryWebForm2.aspx.cs" Inherits="CustomerClient_WebApplication.CategoryWebForm2" %>

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

          <br />
           <br />
           <br />

           
             <div class ="container">
       <div class ="form-horizontal">
           
          

              <h2>Update & Delete Category</h2><br />
       
           <div class ="form-group">
               <asp:Label ID="Label3" runat="server" CssClass ="col-md-2 control-label" Text="Category ID" ></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtId1" CssClass ="form-control" runat="server"  ></asp:TextBox>
                
                  
               </div>
           </div>

             <div class ="form-group">
               <asp:Label ID="Label4" runat="server" CssClass ="col-md-2 control-label" Text="Category Name" ></asp:Label>
               <div class ="col-md-3">
                   <asp:TextBox ID="txtName1" CssClass ="form-control" runat="server"  ></asp:TextBox>
                
                  
               </div>
           </div>

            <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                       
                         <asp:Button ID="Button4" CssClass ="btn btn-success " runat="server" Text="Update" OnClick="Button4_Click"  />
                         <asp:Button ID="Button5" CssClass ="btn btn-success " runat="server" Text="Delete" OnClick="Button5_Click" />
                    </div>
                </div>
           
   <br />
           <br />
        
         <asp:GridView ID="CatInfo" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="800px" Font-Bold="True" Font-Size="Large">
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