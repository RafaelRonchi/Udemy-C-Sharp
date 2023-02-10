using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaCadastro
{
    public partial class Form1 : Form
    {
        List<Pessoa> pessoas;  
        public Form1()
        {
            InitializeComponent();
            pessoas = new List<Pessoa>();

            //ComboBox Constructor
            comboEC.Items.Add("Casado/a");
            comboEC.Items.Add("Solteiro/a");
            comboEC.Items.Add("Viúvo/a");
            comboEC.Items.Add("Divorciado/a");
            comboEC.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            int index = -1;

            foreach (Pessoa p1 in pessoas)
            {
                if (p1.Nome == txtNome.Text)
                {
                    index = pessoas.IndexOf(p1);
                }
            }

            if (txtNome.Text == "")
            {
                MessageBox.Show("Preencha o campo de nome!");
                txtNome.Focus();
                return;
            }
            if (txtTelefone.Text == "(  )      -")
            {
                MessageBox.Show("Preencha o campo de telefone!");
                txtTelefone.Focus();
                return;
            }

            char sexo = 'O';
            if (radioF.Checked)
            {
                sexo = 'F';
            }
            if (radioM.Checked)
            {
                sexo = 'M';
            }
            if (radioO.Checked)
            {
                sexo = 'O';
            }

            Pessoa p = new Pessoa();
            p.Nome = txtNome.Text;
            p.DataNascimento = txtData.Text;
            p.EstadoCivil = comboEC.SelectedItem.ToString();
            p.Telefone = txtTelefone.Text;
            p.CasaPropia = checkCasa.Checked;
            p.Veiculo= checkVeiculo.Checked;
            p.Sexo = sexo;

            if (index < 0)
            {
                pessoas.Add(p);
            }
            else
            {
                pessoas[index] = p;
            }
            btnLimpar_Click(btnLimpar, EventArgs.Empty);

            Listar();
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int indice =lista.SelectedIndex;
            pessoas.RemoveAt(indice);
            Listar();

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            txtData.Text = "";
            comboEC.SelectedIndex = 0;
            txtTelefone.Text = "";
            checkCasa.Checked = false;
            checkVeiculo.Checked = false;
            radioF.Checked = false;
            radioM.Checked = false;
            radioO.Checked = false;
            txtNome.Focus();
        }

        //Listar cadastros
        private void Listar()
        {
            lista.Items.Clear();

            foreach (Pessoa p in pessoas)
            {
                lista.Items.Add(p.Nome);
            }
        }

        private void lista_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int indice = lista.SelectedIndex;
            Pessoa p = pessoas[indice];

            txtNome.Text = p.Nome;
            txtData.Text = p.DataNascimento;
            comboEC.SelectedItem = p.EstadoCivil;
            txtTelefone.Text = p.Telefone;
            checkCasa.Checked = p.CasaPropia ;
            checkVeiculo.Checked = p.Veiculo;

            switch (p.Sexo) 
            {
                case 'M':
                    radioM.Checked = true;
                    break;
                case 'F':
                    radioF.Checked = true;
                    break;
                default:
                    radioO.Checked = true;
                    break;
            }
        }
    }
}
