using Fintech.Dominio;
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
            var botaoClicado = (Button)sender;
            var clienteSelecionado = botaoClicado.DataContext;

            ClienteSelecionado = (Cliente)clienteSelecionado;

            clienteTextBox.Text = $"{ClienteSelecionado.Nome} - {ClienteSelecionado.Cpf}";

            contasTabItem.Focus();
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
    }
}
