<%@ Page Language="C#" MasterPageFile="~/MP/Main.master" AutoEventWireup="true" CodeFile="frmPerfil.aspx.cs" Inherits="Pages_Maestros_frmPerfil" Title="Untitled Page" %>


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

