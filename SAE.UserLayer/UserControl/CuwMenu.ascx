﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CuwMenu.ascx.cs" Inherits="CuwMenu" %>
<asp:Menu ID="mnuPrincipal" runat="server" Font-Bold="False" 
    Orientation="Vertical">
<LevelMenuItemStyles>
    <asp:MenuItemStyle CssClass="level1"/>
            <asp:MenuItemStyle CssClass="level2"/>
            <asp:MenuItemStyle CssClass="level3" />
    </LevelMenuItemStyles>
    <LevelSubMenuStyles>
            <asp:SubMenuStyle CssClass="sublevel1" />
    </LevelSubMenuStyles>
     <StaticHoverStyle CssClass="hoverstyle"/>
     <DynamicHoverStyle  CssClass="hoverstyle"/>
</asp:Menu>

<asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>


