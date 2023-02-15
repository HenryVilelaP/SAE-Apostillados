<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CuwNavegacion.ascx.cs" Inherits="UserControl_CuwNavegacion" %>

        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <asp:SiteMapPath ID="SiteMapPath1" runat="server" BorderStyle="None"  PathSeparator=" : " SkipLinkText="">
            <PathSeparatorStyle Font-Bold="True" ForeColor="#990000" />
            <CurrentNodeStyle ForeColor="#333333" />
            <NodeStyle Font-Bold="True" ForeColor="#990000" />
            <RootNodeStyle Font-Bold="True" ForeColor="#FF8000"   />
</asp:SiteMapPath>
