<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Path.ascx.vb" Inherits="Controls_Path" %>

    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
  <table cellpadding="0" cellspacing="0" class="style1" dir="ltr">
                      <tr>
                          <td align="right">
                              <asp:SiteMapPath ID="SiteMapPath1" runat="server" EnableTheming="True" 
                                   RenderCurrentNodeAsLink="True" ShowToolTips="true" 
                                  SiteMapProvider="MapPath" SkipLinkText="">
                                  <PathSeparatorStyle Font-Underline="False" ForeColor="White" />
                                  <CurrentNodeStyle Font-Bold="False" Font-Italic="False" Font-Underline="False" 
                                      ForeColor="Black" Font-Size="10pt" />
                                  <PathSeparatorTemplate>
                                      <asp:Image ID="Image2" runat="server" 
                                          ImageUrl="~/Images/Titles/OrangeArrow.gif" />
                                  </PathSeparatorTemplate>
                                  <NodeStyle Font-Bold="False" Font-Overline="False" Font-Underline=false   
                                      ForeColor="#0B417F" Font-Size="10pt" />
                                  <RootNodeStyle Font-Size="10pt" />
                              </asp:SiteMapPath>
                          </td>
                          <td align="right" width="5">
                              &nbsp;</td>
                          <td width="20">
                  <asp:Image ID="Image1" runat="server"  
                      ImageUrl="~/Images/Icons/HomepageIcon.png"  BackColor="Transparent"  />
                 
                          </td>
                      </tr>
                  </table>