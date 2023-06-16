<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Open_and_save_PDF_document._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Load and save PDF document" OnClick="OpenAndSaveDocument" />  
    <div>
        <script type ="text/javascript">        
        </script>
    </div>
</asp:Content>
