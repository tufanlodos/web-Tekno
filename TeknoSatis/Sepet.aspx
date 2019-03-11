<%@ Page Title="" Language="C#" MasterPageFile="~/Satis.Master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="TeknoSatis.Sepet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row"><br />
        <div class="col-md-offset-5"><asp:Label ID="lblSepetBaslik" runat="server" Font-Bold="true" Font-Size="Large" Text="Sepetiniz"></asp:Label></div>
    </div><hr /><hr />
    <asp:Repeater ID="repSepet" runat="server" OnItemCommand="repSepet_ItemCommand">
        <ItemTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-md-2">
                        <div class="row">
                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Urune" CommandArgument='<%#Eval("UrunId") %>'>
                            <img src='<%#Eval("ResimYolu") %>' alt='<%#Eval("UrunAdi") %>' title='<%#Eval("UrunAdi") %>' height="150px" width="150px"/></asp:LinkButton></div><br />
                    </div>
                    <div class="col-md-10">
                        <div class="row">
                            <asp:LinkButton ID="UrunAdiButonu" runat="server" ForeColor="Black" CommandName="Urune" CommandArgument='<%#Eval("UrunId") %>'>
                             <h4><strong><%#Eval("UrunAdi") %></strong></h4>
                            </asp:LinkButton>
                        </div>
                        <div class="row">
                            <h6><strong>Birim Fiyatı : </strong><%#Eval("BirimFiyat","{0:c}") %></h6>
                            <h6><strong> Adet : </strong>
                                <asp:Button ID="Azalt" CommandName="Azalt" CommandArgument='<%#Eval("SepetId") %>' runat="server" Text="-" CssClass="btn btn-Primary btn-xs"/>
                                    <%#Eval("Adet") %>
                                <asp:Button ID="Arttir" CommandName="Arttir" CommandArgument='<%#Eval("SepetId") %>' runat="server" Text="+" CssClass="btn btn-Primary btn-xs" />
                            </h6>
                            <h6><strong>Tutar : <span style="font-size:medium"><%#Eval("Tutar","{0:c}") %></span></strong></h6>
                        </div><br />
                        <div class="row">
                            <div class="col-md-offset-6">
                                <asp:Button ID="btnCikar" runat="server" Text="Sepettten Çıkar" CssClass="btn btn-Primary" CommandName="sepettencikar" CommandArgument='<%#Eval("SepetId") %>'/>
                            </div>
                        </div>
                    </div>
                </div>
             </div><hr /><hr />
        </ItemTemplate>
    </asp:Repeater>
    <div class="row">
        <div class="row">
        <div class="col-md-offset-9"><strong>Sepet toplam tutarı: <span style="font-size:larger"> <%: string.Format("{0:C}", Session["toplamtutar"]) %></span></strong></div>
        </div>
        <div class="row">
            <div class="col-md-offset-9">
                <asp:Button ID="btnTemizle" runat="server" Text="Sepeti Temizle" CssClass="btn btn-Primary" OnClick="btnTemizle_Click" />
                <asp:Button ID="btnSatinAl" runat="server" Text="Satın Al" CssClass="btn btn-Primary" /> 
            </div>
        </div>
        </div><hr />
</asp:Content>
