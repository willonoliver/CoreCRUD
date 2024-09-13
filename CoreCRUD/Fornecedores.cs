using System;
using System.Windows.Forms;

namespace CoreCRUD
{
    public partial class Fornecedores : Form
    {
        public Fornecedores()
        {
            InitializeComponent();
            InicializarEstadoInicial();
            Incluir.Click += new EventHandler(Incluir_Click);
            Gravar.Click += new EventHandler(Gravar_Click);
        }

        private void InicializarEstadoInicial()
        {
            // Desabilitar todos os campos
            InscricaoEstadual.Enabled = false;
            email.Enabled = false;
            celular.Enabled = false;
            telefone.Enabled = false;
            comboBoxUF.Enabled = false;
            Complemento.Enabled = false;
            CNPJ.Enabled = false;
            NomeCidade.Enabled = false;
            CEP.Enabled = false;
            Numero.Enabled = false;
            Endereco.Enabled = false;
            NomeFantasia.Enabled = false;
            NomeEmpresa.Enabled = false;

            // Desabilitar botões Alterar e Gravar
            Alterar.Enabled = false;
            Gravar.Enabled = false;

            // Habilitar botão Incluir
            Incluir.Enabled = true;

            // Desabilitar botão Pesquisar
            Pesquisar.Enabled = false;
        }

        private void HabilitarCampos()
        {
            // Habilitar todos os campos
            InscricaoEstadual.Enabled = true;
            email.Enabled = true;
            celular.Enabled = true;
            telefone.Enabled = true;
            comboBoxUF.Enabled = true;
            Complemento.Enabled = true;
            CNPJ.Enabled = true;
            NomeCidade.Enabled = true;
            CEP.Enabled = true;
            Numero.Enabled = true;
            Endereco.Enabled = true;
            NomeFantasia.Enabled = true;
            NomeEmpresa.Enabled = true;
        }

        private void Incluir_Click(object? sender, EventArgs e)
        {
            // Habilitar todos os campos
            HabilitarCampos();

            // Habilitar botão Gravar
            Gravar.Enabled = true;

            // Desabilitar botões Incluir, Alterar e Pesquisar
            Incluir.Enabled = false;
            Alterar.Enabled = false;
            Pesquisar.Enabled = false;
        }

        private void Gravar_Click(object? sender, EventArgs e)
        {
            // Lógica para gravar os dados
            MessageBox.Show("Dados gravados com sucesso!");

            // Voltar ao estado inicial
            InicializarEstadoInicial();
        }

        private void Alterar_Click(object? sender, EventArgs e)
        {
            // Lógica para alterar os dados
            MessageBox.Show("Dados alterados com sucesso!");
        }

        private void Pesquisar_Click(object? sender, EventArgs e)
        {
            // Lógica para pesquisar os dados
            MessageBox.Show("Pesquisa realizada com sucesso!");
        }

        // Outros eventos e lógica podem ser adicionados aqui
        private void InscricaoEstadual_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo InscricaoEstadual mudar
        }

        private void email_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo email mudar
        }

        private void celular_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo celular mudar
        }

        private void telefone_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo telefone mudar
        }

        private void comboBoxUF_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o item selecionado no comboBoxUF mudar
        }

        private void Complemento_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo Complemento mudar
        }

        private void CNPJ_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo CNPJ mudar
        }

        private void NomeCidade_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo NomeCidade mudar
        }

        private void CEP_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo CEP mudar
        }

        private void Numero_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo Numero mudar
        }

        private void Endereco_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo Endereco mudar
        }

        private void NomeFantasia_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo NomeFantasia mudar
        }

        private void NomeEmpresa_TextChanged(object? sender, EventArgs e)
        {
            // Lógica para quando o texto do campo NomeEmpresa mudar
        }
    }
}
