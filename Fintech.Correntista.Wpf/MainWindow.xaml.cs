using Fintech.Dominio;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

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
    }
}
