<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerWebForm.aspx.cs" Inherits="CustomerClient_WebApplication.CustomerWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
    <meta charset="UTF-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

	<link rel="stylesheet" href="./assets/styles.css"/>
</head>
<body>
    <form id="form1" runat="server">
   
<div class="wrapper">
    <div class="title">
      Registration
    </div>
    <div class="form">
       <div class="inputfield">
          <label>Customer ID</label>
         <asp:TextBox ID="txtId" runat="server" Cssclass="input"></asp:TextBox>
         

       </div>  
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required" ControlToValidate="txtId" ForeColor="Red"></asp:RequiredFieldValidator>
        <div class="inputfield">
          <label>Customer Name</label>
          <asp:TextBox ID="txtcustomer" runat="server" Cssclass="input"></asp:TextBox>
  

       </div>  
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtcustomer" ForeColor="Red"></asp:RequiredFieldValidator>
       <div class="inputfield">
          <label>Password</label>
         <asp:TextBox ID="txtpassword" runat="server" TextMode="password" Cssclass="input"></asp:TextBox>
           
       </div>  
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="txtpassword" ForeColor="Red"></asp:RequiredFieldValidator>
      <div class="inputfield">
          <label>Confirm Password</label>
        <asp:TextBox ID="txtcpassword" TextMode="password" runat="server" CssClass="input"></asp:TextBox>
          
       </div> 
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ControlToValidate="txtcpassword" ForeColor="Red"></asp:RequiredFieldValidator><br />
                            
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtpassword" ControlToValidate="txtcpassword" ErrorMessage="Password is not match" ForeColor="Red"></asp:CompareValidator>
        <div class="inputfield" >
          <label>Email</label>
          <asp:TextBox ID="txtemail" runat="server" CssClass="input"></asp:TextBox>
            

       </div> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="txtemail" ForeColor="Red"></asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
      
      <div class="inputfield">
          <label>Contact</label>
       <asp:TextBox ID="txtcontact" runat="server" CssClass="input"></asp:TextBox>
         
           
       </div> 
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Required" ControlToValidate="txtcontact" ForeColor="Red"></asp:RequiredFieldValidator>
   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtcontact" ErrorMessage="Invalid number" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
        <div class="inputfield">
          <label>Address</label>
         <asp:TextBox ID="txtaddress" runat="server" CssClass="input"></asp:TextBox>
            
       </div> 
         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required" ControlToValidate="txtaddress" ForeColor="Red"></asp:RequiredFieldValidator>
      <div class="inputfield">
   <asp:Button ID="Button1" runat="server" Text="Button" class="btn" OnClick="Button1_Click1"/>
      </div>
    
</div>	
	     
       </div>
    </form>
</body>
</html>
