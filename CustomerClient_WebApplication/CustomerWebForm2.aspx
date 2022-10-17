<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerWebForm2.aspx.cs" Inherits="CustomerClient_WebApplication.CustomerWebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="UTF-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

	<link rel="stylesheet" href="./assets/styles.css"/>
</head>
<body>
    <form id="form1" runat="server">
          
<div class="wrapper">
    <div class="title">
      Login
    </div>
    <div class="form">
       
        <div class="inputfield">
          <label>Username</label>
          <asp:TextBox ID="txtcustomer" runat="server" Cssclass="input"></asp:TextBox>

       </div>  
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Required" ControlToValidate="txtcustomer" ForeColor="Red"></asp:RequiredFieldValidator>
       <div class="inputfield">
          <label>Password</label>
         <asp:TextBox ID="txtpassword" runat="server" Cssclass="input"></asp:TextBox>
       </div>  
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="txtpassword" ForeColor="Red"></asp:RequiredFieldValidator>
   
      <div class="inputfield">
   <asp:Button ID="Button1" runat="server" Text="Button" class="btn" OnClick="Button1_Click"/>
      </div>

        
        <a style="color:white" href="CustomerWebForm.aspx">Register Here...</a>
    
</div>	
	     
       </div>
    </form>
</body>
</html>
