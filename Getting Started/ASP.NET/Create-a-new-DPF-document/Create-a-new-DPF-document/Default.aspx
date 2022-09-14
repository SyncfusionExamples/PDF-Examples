<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Create_a_new_DPF_document._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Generate PDF Document" OnClick="GeneratePDF" />  
    <div>
        <script type ="text/javascript">        
        </script>
    </div>
</asp:Content>
