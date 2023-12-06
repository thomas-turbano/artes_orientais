using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maes_solteiras_athur
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void UpdateListView()
        {
            listView1.Items.Clear();

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUsuario1();

            foreach (Usuario usuario in usuarios)
            {
                ListViewItem item = new ListViewItem(usuario.rua);
                item.SubItems.Add(usuario.Bairro);
                item.SubItems.Add(usuario.Numero);
                listView1.Items.Add(item);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (text1.Text.Length < 4)
            {
                MessageBox.Show("O campo Rua deve ter pelo menos 4 caracteres.");
            }
            else if (text2.Text.Length < 4)
            {
                MessageBox.Show("O campo telefone deve ter pelo menos 4 caracteres.");
            }
            else if (text3.Text.Length < 2)
            {
                MessageBox.Show("O campo Senha deve ter pelo menos 2 caracteres.");
            }
            else 
            {
                Usuario usuario = new Usuario("Rua", "Bairro", "Numero_Casa");
                usuario.rua = text1.Text;
                usuario.Bairro = text2.Text;
                usuario.Numero = text3.Text;

                UsuarioDAO usuarioDAO = new UsuarioDAO();
                usuarioDAO.InsertUsuario1(usuario);
                text1.Clear();
                text2.Clear();
                text3.Clear();
            }
                

            UpdateListView();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Rua", "Bairro", "Numero_Casa");
            usuario.rua = text1.Text;
            usuario.Bairro = text2.Text;
            usuario.Numero = text3.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.UpdateUsuario1(usuario);
            text1.Clear();
            text2.Clear();
            text3.Clear();

            UpdateListView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(text3.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeletUsuario1(id);
            text1.Clear();
            text2.Clear();
            text3.Clear();
            UpdateListView();
        }
    }
}
