<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="CommanderMets.aspx.cs" Inherits="Restaurant.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    

    <style type="text/css">
        .auto-style1 {
            width: 121px;
        }
        .auto-style2 {
            margin-left: 42px;
        }
        .auto-style3 {
            margin-top: 18px;
        }
        .auto-style4 {
            width: 232px;
        }
    </style>
    

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenu" runat="server">
    <div>

    
    <div style="width: 60%; float:left">
        <div>
             <table style="width:100%" style="margin-left:50px">
                   
  <tr>
    <td class="auto-style1"><asp:Image ID="Image1" runat="server"   ImageUrl="C:/Users/MAIN/source/repos/Micropoune/Restaurant/pizza.jpg" Height="100px" Width="100px" />
             </td>
    <td>
        <asp:Panel ID="Panel1" runat="server" GroupingText="Pizza" Width="565px">
            <br />
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Format" style="margin-left:50px"></asp:Label>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdb_petite" runat="server" Text=" Petite 8&quot" />
                    </td>
                    <td>
                        <asp:RadioButton ID="rdb_grande" runat="server" Text=" Grande 12&quot"/>
                    </td>
                </tr>
                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:RadioButton ID="rdb_moyenne" runat="server" Text=" Moyenne 10&quot"/>
                    </td>
                    <td>
                         <asp:RadioButton ID="rdb_large" runat="server" Text=" X-Large 16&quot"/>
                    </td>
                </tr>

            </table>
            
            
            

            <br />
            
           
            <br />
            <br />
                </asp:Panel>
    </td>
    
  </tr>
  <tr>
    <td class="auto-style1"></td>
    <td>
         <asp:Panel ID="Panel2" runat="server" GroupingText="Boisson" Width="565px">
            <table style="width:100%">
                <tr>
                    <td>
                        <asp:DropDownList ID="ddl_choix_boisson" runat="server"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RadioButton ID="rdb_350ml" runat="server" Text="350 ml" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_quantite" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:RadioButton ID="rdb_2litre" runat="server" Text="2 Litre" />
                    </td>
                    <td>
                        <asp:Button ID="btn_ajouter" runat="server" CssClass="auto-style2" Text="Ajouter" />
                    </td>
                </tr>
            </table>
                </asp:Panel>
    </td>
   
  </tr>
</table> 
               
            
        </div>
    </div>
            <div style="float:right">
                <asp:LinqDataSource ID="LinqDataSource1" runat="server"></asp:LinqDataSource>
                <asp:Panel ID="Panel3" runat="server" Height="772px" Width="318px" style="margin: 0px 50px 50px 50px" CssClass="auto-style3" >

                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>


                    <table>
                        <tr>
                            <td class="auto-style4">
                                <asp:Button ID="btn_retour" runat="server" Text="Retour" />
                            </td>
                            <td>
                                <asp:Button ID="btn_valider" runat="server" Text="Valider" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
    
  </div>
</asp:Content>
