<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Motorista.aspx.cs" Inherits="AppTeste.Motorista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Container" style="width: 100%">
        <h2 style="height: 48px">Cadastro Simples de Motorista</h2>
        <table style="height: 168px">
            <tr>
                <td style="height: 35px">Codigo</td>
                <td style="height: 35px">
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
            </tr>
            <tr>
                <td>CPF</td>
                <td>
                    <asp:TextBox ID="txtCpf" runat="server" Onchange="ValidadeCPF(this)" Width="182px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server"
                        ErrorMessage="O Campo CPF deve ser informada" ToolTip="O Campo CPF deve ser informada"
                        ControlToValidate="txtCpf" BackColor="White" ForeColor="Blue"></asp:RequiredFieldValidator>
                </td>

            </tr>
            <tr>
                <td style="height: 35px">Nome</td>
                <td style="height: 35px">
                    <asp:TextBox ID="txtNome" runat="server" Width="307px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="O Campo Nome deve ser informada" ToolTip="O Campo Nome deve ser informada"
                        ControlToValidate="txtNome" BackColor="White" ForeColor="Blue"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 35px">Sexo</td>
                <td style="height: 35px">

                    <asp:DropDownList ID="txtSexo" runat="server" Height="30px">
                        <asp:ListItem>Masculino</asp:ListItem>
                        <asp:ListItem>Feminino</asp:ListItem>
                        <asp:ListItem>Outros</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 35px">Idade</td>
                <td style="height: 35px">
                    <asp:TextBox ID="txtIdade" runat="server" Onchange="ValidadeIdade(this)"></asp:TextBox>
                    <asp:Label ID="txtAno" Name="txtAno" Class="txtAno" runat="server" EnableViewState="False" BackColor="White" ForeColor="Blue"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ErrorMessage="O Campo Idade deve ser informada" ToolTip="O Campo Idade deve ser informada"
                        ControlToValidate="txtIdade" BackColor="White" ForeColor="Blue"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="height: 35px">Ativo</td>
                <td style="height: 35px">

                    <asp:DropDownList ID="txtAtivo" runat="server" Height="30px">
                        <asp:ListItem>Sim</asp:ListItem>
                        <asp:ListItem>Nao</asp:ListItem>
                        <asp:ListItem>Cancelado</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

        <asp:Label ID="lblMsg" runat="server" EnableViewState="False" BackColor="White" ForeColor="Red" Font-Bold="True"></asp:Label>
        <p />

        <table>
            <tr>
                <td style="text-align: center">
                    <asp:LinkButton ID="LinkButton1" runat="server"
                        Style="font-family: 'Trebuchet MS'" class="btn btn-primary" OnClick="LinkButton1_Click">Incluir </asp:LinkButton>

                    <asp:LinkButton ID="LinkButton2" runat="server"
                        Style="font-family: 'Trebuchet MS'" class="btn btn-primary" OnClick="LinkButton2_Click">Alterar</asp:LinkButton>

                    <asp:LinkButton ID="LinkButton3" runat="server"
                        Style="font-family: 'Trebuchet MS'" class="btn btn-primary" OnClick="LinkButton3_Click">Deletar</asp:LinkButton>

                    <asp:LinkButton ID="LinkButton4" runat="server"
                        Style="font-family: 'Trebuchet MS'" class="btn btn-primary" OnClick="LinkButton4_Click">Limpar</asp:LinkButton>

                    <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/Default.aspx"
                        Style="font-family: 'Trebuchet MS'" class="btn btn-primary">Sair</asp:LinkButton>
                </td>
            </tr>
        </table>

        <asp:GridView ID="GridView1" EmptyDataText="Nenhum Registro foi Encontrado" runat="server" AutoGenerateColumns="False" Width="100%" Height="10px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>

                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                <asp:BoundField DataField="nome" HeaderText="Nome" />
                <asp:BoundField DataField="sexo" HeaderText="Sexo" />
                <asp:BoundField DataField="idade" HeaderText="Idade" />
                <asp:BoundField DataField="ativo" HeaderText="Ativo" />

                <asp:CommandField ShowSelectButton="True" />
            </Columns>
            <HeaderStyle BackColor="#00BFFF" Font-Bold="True" ForeColor="White" />
        </asp:GridView>

    </div>
    <script>

        function ValidadeCPF() {

            var resu = document.getElementById('<%= txtCpf.ClientID %>').value;
            if (verifica_cpf_cnpj(resu)) {
            } else {
                alert("CPF invalido verifique !!!");
            }
        }

        function verifica_cpf_cnpj(valor) {

            valor = valor.toString();
            valor = valor.replace(/[^0-9]/g, '');
            if (valor.length === 11) {
                return 'CPF';
            }
            else if (valor.length === 14) {
                return 'CNPJ';
            }
            else {
                return false;
            }
        }

        function ValidadeIdade() {

            var anos_a = document.getElementById('<%= txtIdade.ClientID %>').value;
            var now = new Date();
            var nov = now.getFullYear() - anos_a;
            $('.txtAno').text(nov);
        }

    </script>

</asp:Content>
