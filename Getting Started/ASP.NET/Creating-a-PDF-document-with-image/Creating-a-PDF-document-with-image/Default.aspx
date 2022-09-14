<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Creating_a_PDF_document_with_image._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Button ID="Button1" runat="server" Text="Generate PDF Document with image" OnClick="GeneratePDF" />  
    <div>
        <script type ="text/javascript">        
        </script>
    </div>
</asp:Content>
