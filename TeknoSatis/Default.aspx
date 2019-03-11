<%@ Page Title="" Language="C#" MasterPageFile="~/Satis.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TeknoSatis.Default" %>

<%@ Register Src="~/ucUrunler.ascx" TagPrefix="uc1" TagName="ucUrunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucUrunler runat="server" ID="ucUrunler" />
</asp:Content>
