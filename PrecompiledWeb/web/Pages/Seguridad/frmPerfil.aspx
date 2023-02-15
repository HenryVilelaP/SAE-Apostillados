<%@ page language="C#" masterpagefile="~/MP/Main.master" autoeventwireup="true" inherits="Pages_Maestros_frmPerfil, App_Web_4qxwtc8o" title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="cphCuerpo" Runat="Server">

    
    
    
    
    
         
    
    
    
           
                    
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> 
                <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" />  
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
    
    </ContentTemplate>                                                      
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
    <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
    </Triggers>          
    </asp:UpdatePanel>
    
</asp:Content>

