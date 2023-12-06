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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario("Nome", "Email", "Telefone", "Senha", "cep");
            usuario.Email = text2.Text;
            usuario.senha = Criptografia.CriptografarSenha(text4.Text);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.loginUsuario(usuario);


        }
    }
}
