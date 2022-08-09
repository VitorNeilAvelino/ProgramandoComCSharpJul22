using Fintech.Dominio;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MovimentoRepositorio repositorio = new (Properties.Settings.Default.CaminhoArquivoMovimento);

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Cliente ClienteSelecionado { get; set; }

        public MainWindow()
        {
            //Clientes = new List<Cliente>();
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);

            clienteDataGrid.ItemsSource = Clientes;

            var banco1 = new Banco();
            banco1.Numero = 1;
            banco1.Nome = "Banco Um";

            bancoComboBox.Items.Add(banco1);
            bancoComboBox.Items.Add(new Banco { Numero = 2, Nome = "Banco Dois" });

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            var cliente = new Cliente();
            cliente.Cpf = cpfTextBox.Text;
            cliente.Nome = nomeTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            var endereco = new Endereco();
            endereco.Cep = cepTextBox.Text;
            endereco.Numero = numeroLogradouroTextBox.Text;
            endereco.Bairro = bairroTextBox.Text;
            endereco.Logradouro = logradouroTextBox.Text;

            cliente.EnderecoResidencial = endereco;

            Clientes.Add(cliente);

            MessageBox.Show("Cliente cadastrado com sucesso!");

            clienteDataGrid.Items.Refresh();

            pesquisaClienteTabItem.Focus();

            LimparControlesCliente();

            //var nome = "Vítor";
            //nome = 10;
            //object meuObjeto = 2;
            //meuObjeto = "Texto";
            //meuObjeto = false;
        }

        private void LimparControlesCliente()
        {
            cpfTextBox.Clear();
            nomeTextBox.Text = "";
            dataNascimentoTextBox.Text = null;
            sexoComboBox.SelectedIndex = -1;
            logradouroTextBox.Text = string.Empty;
            numeroLogradouroTextBox.Clear();
            bairroTextBox.Clear();
            cepTextBox.Clear();
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;
            var clienteSelecionado = botaoClicado.DataContext;

            ClienteSelecionado = (Cliente)clienteSelecionado;
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedIndex == -1) return;

            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            //var conta = new Conta();
            Conta conta = null;

            //var agencia = new Agencia();
            Agencia agencia = new();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            // design pattern chamado Factory.
            switch (tipoConta)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
            }

            ClienteSelecionado.Contas.Add(conta);

            MessageBox.Show("Conta adicionada com sucesso!");

            LimparControlesConta();

            clienteDataGrid.Items.Refresh();
            clienteTabItem.Focus();
            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contaComboBox.ItemsSource = ClienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            //LimparControlesOperacoes();

            operacoesTabItem.Focus();
        }

        private void LimparControlesOperacoes()
        {
            throw new NotImplementedException();
        }

        private void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contaComboBox.SelectedIndex == -1) return;

            var conta = /*(Conta)*/contaComboBox.SelectedItem as Conta;

            conta.Movimentos = repositorio.Selecionar(conta.Agencia.Numero, conta.Numero);

            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            saldoTextBox.Text = conta.Saldo.ToString();
        }

        private void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            var conta = (Conta)contaComboBox.SelectedItem;
            var operacao = (Operacao)operacaoComboBox.SelectedItem;
            var valor = Convert.ToDecimal(valorTextBox.Text);

            var movimento = conta.EfetuarOperacao(valor, operacao);

            repositorio.Inserir(movimento);

            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            movimentacaoDataGrid.Items.Refresh();

            saldoTextBox.Text = conta.Saldo.ToString();
        }
    }
}
