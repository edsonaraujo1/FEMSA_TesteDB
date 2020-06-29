<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="AppTeste.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        Edson de Araujo<br />
        w, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Contato:</strong>   <a href="mailto:holodek.edson@gmail.com">holodek.edson@gmail.com</a><br />
        <strong>Portifolio:</strong> <a href="https://www.utyum.com.br/edson">Portifolio Edson</a>
    </address>
</asp:Content>
