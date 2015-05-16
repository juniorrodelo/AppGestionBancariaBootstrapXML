<%@ Page Title="" Language="C#" MasterPageFile="~/Web/Site1.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="App.Web.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <form id="form1" runat="server" role="form" class="form-horizontal">
    <div class="jumbotron">
        <h2>Crear Cuentas</h2>
        <div class="form-group">
         <label class="control-label">Seleccionar Tipo de cuenta</label>
         <asp:DropDownList onChange="javascript:mostrar(this.value);" ID="type" runat="server" class="form-control" >
             <asp:ListItem Value="0">-seleccionar-</asp:ListItem>
             <asp:ListItem Value="corrientes">Corrientes</asp:ListItem>
             <asp:ListItem Value="cheques">Cheques</asp:ListItem>
             <asp:ListItem Value="ahorros">Ahorros</asp:ListItem>
         </asp:DropDownList>
         </div>

        <div class="form-group">
                <label class="control-label">Cliente</label>
                <asp:TextBox ID="txtcliente" runat="server" class="form-control" ></asp:TextBox>
         </div>
             <div class="form-group">
                <label class="control-label">Identificacion</label>
                 <asp:TextBox ID="txtId" runat="server" class="form-control" ></asp:TextBox> 
          </div>       
             <div class="form-group">
                <label class="control-label" >Idcliente</label>
                <asp:TextBox ID="txtIdCliente" runat="server" class="form-control" ></asp:TextBox> 
           </div>
             <div class="form-group">
                <label class="control-label" >Balance</label>
                 <asp:TextBox ID="txtbalance" runat="server" class="form-control"  value="0.0" onFocus="if (this.value=='0.0') this.value='';"></asp:TextBox>
             </div>
             <div class="form-group" style="display: none;" id="limitedecredito">
                <label class="control-label" >Limites De Creditos</label>     
                 <asp:TextBox ID="txtlimitesDeCreditos" runat="server" class="form-control" value="0.0" onFocus="if (this.value=='0.0') this.value='';" ></asp:TextBox>
             </div>
             <div class="form-group" style="display: none;" id="tasadeinteres">
                <label class="control-label" >Tasa De Interes</label>
                 <asp:TextBox ID="txttasaInteres" runat="server" class="form-control"  ></asp:TextBox>
             </div>
             <div class="form-group" style="display: none;" id="talonario">
                <label class="control-label" >ID Talonario</label>
                 <asp:TextBox ID="idtalonario" runat="server" class="form-control"  ></asp:TextBox>
             </div>
            <div class="form-group" style="display: none;" id="tasadeinteresh">
                <label class="control-label" >Tasa de Interes</label>
                 <asp:TextBox ID="txttasadeinteresh" runat="server" class="form-control" value="0.0" onFocus="if (this.value=='0.0') this.value='';" ></asp:TextBox>
             </div>
             <div class="form-group">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" class="btn btn-group-lg btn-success" OnClick="btnGuardar_Click"/>
             </div>  
    </div>
    </form>
</asp:Content>
