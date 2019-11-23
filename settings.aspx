<%@ Page Language="C#" AutoEventWireup="true" CodeFile="settings.aspx.cs" Inherits="settings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta charset="utf-8"/>
    <meta name="keywords" content="Key Login Form a Responsive Web Template, Bootstrap Web Templates, Flat Web Templates, Android Compatible Web Template, Smartphone Compatible Web Template, Free Webdesigns for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design"/>
    <script>
        addEventListener("load", function () {
            setTimeout(hideURLbar, 0);
        }, false);

        function hideURLbar() {
            window.scrollTo(0, 1);
        }
    </script>
    <!-- //Meta-Tags -->
    <!-- Index-Page-CSS -->
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all"/>
    <!-- //Custom-Stylesheet-Links -->
    <!--fonts -->
    <!-- //fonts -->
    <link rel="stylesheet" href="css/font-awesome.min.css" type="text/css" media="all"/>
    <!-- //Font-Awesome-File-Links -->
	
	<!-- Google fonts -->
	<link href="//fonts.googleapis.com/css?family=Quattrocento+Sans:400,400i,700,700i" rel="stylesheet"/>
	<link href="//fonts.googleapis.com/css?family=Mukta:200,300,400,500,600,700,800" rel="stylesheet"/>
	<!-- Google fonts -->

</head>
<body>
    <section class="main">
         <div class="links">
                   
                </div>
	<div class="layer">
		
		<div class="bottom-grid">
			<div class="logo">
				
			</div>
             <ul class="links-unordered-list">
                        <li class="">
                            <a href="home.aspx" class="">Home</a>
                        </li>
                       </ul>
			</div>
		<div class="content-w3ls">
			<div class="text-center icon">
			</div>
			<div class="content-bottom">
				<form id="form1" runat="server">
					<div class="field-group">
						<span class="fa fa-user" aria-hidden="true"></span>
						<div class="wthree-field">
							<asp:TextBox runat="server" name="text1" id="text1" type="email" placeholder="email address" required=""/>
						</div>
					</div>
                    
                    <div class="wthree-field">
                        <asp:Button ID="Button1" runat="server" Text="Add Email" OnClick="Button1_Click" />
                    </div>
                   <%-- <div class="wthree-field">
                        <asp:Button ID="Button2" runat="server" Text="Add Email" OnClick="Button1_Click" />
                    </div>--%>
					
					<ul class="list-login-bottom">
						<li class="">
							
						</li>
						<li class="">
							
						</li>
						<li class="clearfix"></li>
					</ul>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="450px" DataKeyNames="id" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:TemplateField HeaderText="Row Number" ItemStyle-Width="100">
                                <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                </ItemTemplate>

                                <ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:BoundField DataField="id" HeaderText="id" Visible="false" />
                            <asp:BoundField DataField="email" HeaderText="Email Address" />
                             <asp:TemplateField HeaderText="Edit">
	                            <ItemTemplate>
		                            <asp:LinkButton ID="lnkEdit" Text="Edit"  OnClick="lnkEdit_Click" runat="server"><i class="fa fa-lg fa-edit"></i></asp:LinkButton>
	                            </ItemTemplate>
	                            </asp:TemplateField>   
                                <asp:TemplateField HeaderText="Delete">
	                            <ItemTemplate>
		                            <asp:LinkButton ID="lnkDelete" Text="Delete"  OnClick="lnkDelete_Click" OnClientClick="return confirm('Are you sure you want to delete this email ?')" runat="server" ><i class="fa fa-lg fa-trash"></i></asp:LinkButton>
	                            </ItemTemplate>
	                            </asp:TemplateField>  
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>
				</form>
			</div>
		</div>
		
    </div>
</section>
</body>
</html>
