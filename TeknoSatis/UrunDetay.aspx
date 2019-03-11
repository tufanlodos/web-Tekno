<%@ Page Title="" Language="C#" MasterPageFile="~/Satis.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="TeknoSatis.UrunDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-3">
                         <h2><%#Eval("UrunAdi") %></h2>
                    </div>
                </div>
                <div class="row">
                    <hr />
                    <div class="col-md-offset-1">
                    <div class="col-md-3">
                        <div class="row"><img src='<%#Eval("ResimYolu0") %>' alt='<%#Eval("UrunAdi") %>' height="150px"/></div><br />
                        <div class="row">
                        <div class="col-md-offset-1"><label>Fiyatı: </label>
                            <asp:Label ID="lblFiyat" runat="server" Text='<%#Eval("Fiyat") %>'></asp:Label>₺<br /></div>
                        <div class="col-md-offset-1"><label>Stok Miktarı: </label> <%#Eval("Miktar") %> <br /></div>
                    </div>
                    </div>
                    <div class="col-md-9">
                        <label>Renk: </label> <%#Eval("UrunRenk") %><br />
                        <label>Hafıza: </label> <%#Eval("UrunHafiza") %><br />
                        <label>Ram: </label> <%#Eval("Ram") %><br />
                        <label>Ekran boyutu: </label> <%#Eval("EkranBoyut") %><br />
                        <label>Kamera: </label> <%#Eval("Kamera") %><br />
                        <label>Pil: </label> <%#Eval("Pil") %><br />
                        <br />
                        <div class="row" style="text-align:center">
                        <div style="width:250px">
                        <div class="col-md-2"><asp:TextBox ID="txtAdet" runat="server" TextMode="Number" Min="1" Max='<%#Eval("Miktar") %>' Width="30px" Height="30px" Text="1"></asp:TextBox></div>
                        <div class="col-md-4">
                            <asp:Button ID="btnSepeteEkle" CssClass="btn btn-Primary" Height="30px" runat="server" Text="Sepete Ekle" CommandName="sepet" CommandArgument='<%#Eval("Id") %>' />
                        </div>
                        <div class="col-md-6">&nbsp;</div>
                        </div>
                        </div>
                    </div>
                    </div>
                    </div>
                </div>
                <div class="row">
                    <br /><hr /><br />
                    <div class="col-md-offset-4"><label>Ürün Kategorisi: </label><asp:LinkButton ID="lbKateAdi" runat="server" CommandName="Kate" CommandArgument='<%#Eval("Id") %>' ForeColor="Black"> <%#Eval("KategoriAdi") %></asp:LinkButton><br /></div>
                    <div class="col-md-offset-4"><label>Ürün Alt Kategorisi: </label><asp:LinkButton ID="lbAltKateAdi" runat="server" CommandName="AltKate" CommandArgument='<%#Eval("Id") %>' ForeColor="Black"> <%#Eval("AltKategoriAdi") %></asp:LinkButton><br /></div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
