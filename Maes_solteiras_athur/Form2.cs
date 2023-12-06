using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Maes_solteiras_athur
{
    public partial class Form2 : Form
    {
        public Form2()
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
        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.DeletUsuario(id);
            text1.Clear();
            text2.Clear();
            mtext3.Clear();
            text3.Clear();
            text4.Clear();
            UpdateListView();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Nome", "Email", "Telefone", "Senha", "cep");
            usuario.Id = int.Parse(txtID.Text);
            usuario.Nome = text1.Text;
            usuario.Email = text2.Text;
            usuario.telefone = text3.Text;
            usuario.senha = Criptografia.CriptografarSenha(text4.Text);
            usuario.cep = mtext3.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.UpdateUsuario(usuario);
            text1.Clear();
            text2.Clear();
            mtext3.Clear();
            text3.Clear();
            text4.Clear();

            UpdateListView();

        }

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            int index;
            index = listView1.FocusedItem.Index;
            txtID.Text = listView1.Items[index].SubItems[0].Text;
            text1.Text = listView1.Items[index].SubItems[1].Text;
            text2.Text = listView1.Items[index].SubItems[2].Text;
            text3.Text = listView1.Items[index].SubItems[3].Text;
            text4.Text = listView1.Items[index].SubItems[5].Text;
            mtext3.Text= listView1.Items[index].SubItems[4].Text;
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
