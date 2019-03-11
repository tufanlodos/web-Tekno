<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUrunler.ascx.cs" Inherits="TeknoSatis.ucUrunler" %>
        <asp:DataList ID="dlstUrunler" runat="server" CellPadding="4" ForeColor="#333333" RepeatColumns="4" BackColor="White" OnItemCommand="dlstUrunler_ItemCommand">
            <ItemTemplate>
                <div class="row ">
                    <span class="badge default-bg col-md-offset-3">25% indirim</span>
                </div>
                <div class="row">
                    <div class="col-md-offset-1">
                    <asp:LinkButton ID="UrunAdiButonu" runat="server" ForeColor="Black" CommandName="UrunId" CommandArgument='<%#Eval("Id") %>'>
                            <asp:Label ID="lblUrunAdi" CssClass="h3" runat="server" Text='<%#Eval("UrunAdi") %>'></asp:Label>
                    </asp:LinkButton>
                    </div>
                </div>
                <div class="row">
                <div class="col-md-offset-1">
                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="UrunId" CommandArgument='<%#Eval("Id") %>'>
                    <img src='<%#Eval("ResimYolu0") %>' alt='<%#Eval("UrunAdi") %>' height="150px"/>
                </asp:LinkButton>
                </div>
                </div>
                <div class="row">
                <div class="col-md-offset-1"><label style="width:300px"><small>Özel indirimli KDV dahil fiyattır</small></label></div>
                </div>
                <div class="row">
                <div class="col-md-offset-2">
                <asp:Label ID="lblFiyat" runat="server" Text='<%#Eval("Fiyat") %>'></asp:Label>&nbsp;₺&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtAdet" runat="server" TextMode="Number" Min="1" Max='<%#Eval("Miktar") %>' Width="30px" Text="1"></asp:TextBox>
                </div>
                </div><br />
                <div class="row" style="text-align:center">
                    <div style="width:250px">
                        <div class="col-md-1">&nbsp;</div>
                        <div class="col-md-4">
                            <asp:Button ID="btnSepeteEkle" CssClass="btn btn-Primary" runat="server" Text="Sepete Ekle" CommandName="sepet" CommandArgument='<%#Eval("Id") %>' />
                        </div>
                        <div class="col-md-7">&nbsp;</div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
