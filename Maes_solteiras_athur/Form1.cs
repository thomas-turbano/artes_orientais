using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Maes_solteiras_athur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.Id.ToString());
                item.SubItems.Add(usuario.Nome);
                item.SubItems.Add(usuario.Email);
                item.SubItems.Add(usuario.telefone);
                item.SubItems.Add(usuario.cep);
                item.SubItems.Add(usuario.senha);
                listView1.Items.Add(item);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void text1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (text1.Text.Length < 5)
            {
                MessageBox.Show("O campo Nome deve ter pelo menos 5 caracteres.");
            }
            else if (text3.Text.Length <11)
            {
                MessageBox.Show("O campo telefone deve ter pelo menos 11 caracteres.");
            }
            else if (text4.Text.Length < 3)
            {
                MessageBox.Show("O campo Senha deve ter pelo menos 3 caracteres.");
            }
            else if (mtext3.Text.Length < 8)
            {
                MessageBox.Show("O campo CEP deve ter pelo menos 8 caracteres.");
            }
            else if (checkBox1.Checked)
            {
                string cep = mtext3.Text;
                string url = "https://viacep.com.br/ws/" + cep + "/json/";

                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    dynamic result = JsonConvert.DeserializeObject(json);

                    if (result.erro != null)
                    {
                        MessageBox.Show("CEP não encontrado.");
                        return;
                    }
                }

                Usuario usuario = new Usuario("Nome", "Email", "Telefone", "Senha", "cep");
                usuario.Nome = text1.Text;
                usuario.Email = text2.Text;
                usuario.telefone = text3.Text;
                usuario.senha = Criptografia.CriptografarSenha(text4.Text);
                usuario.cep = mtext3.Text;

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.InsertUsuario(usuario);
                text1.Clear();
                text2.Clear();
                mtext3.Clear();
                text3.Clear();
                text4.Clear();

                UpdateListView();
            }
            else
            {
                MessageBox.Show("Você precisa aceitar os termos de casamento para se cadastrar.",
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void mtext3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void text3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void text4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void text2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}