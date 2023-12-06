﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maes_solteiras_athur
{
    internal class UsuarioDAO
    {
        public List<Usuario> SelectUsuario()
        {
            Connect conn = new Connect();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM [dbo].[User]";

            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();


                while (dr.Read())
                {

                    Usuario objeto = new Usuario(


                    (int)dr["ID"],

                    (string)dr["nome"],

                    (string)dr["Email"],

                    (string)dr["telefone"],

                    (string)dr["CEP"],

                    (string)dr["senha"]


                    );

                    usuarios.Add(objeto);

                }
                dr.Close();

                return usuarios;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }
        public List<Usuario> SelectUsuario1()
        {
            Connect conn = new Connect();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM endereco";

            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();


                while (dr.Read())
                {

                    Usuario objeto = new Usuario(


                    (string)dr["Rua"],
                     (string)dr["Bairro"],
                     (string)dr["Numero_Casa"]
                    );

                    usuarios.Add(objeto);

                }
                dr.Close();

                return usuarios;
            }
            catch (Exception err)
            {
                throw new Exception(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }
        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(email);
        }
        public void InsertUsuario(Usuario usuario)
        {
            string email = usuario.Email;
            Connect connection = new Connect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO [dbo].[User] VALUES 
            (@Nome, @Email, @Telefone,@CEP, @Senha)";

            sqlCommand.Parameters.AddWithValue("@Nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@Email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@Telefone", usuario.telefone);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
            sqlCommand.Parameters.AddWithValue("@Senha", usuario.senha);

            if (IsValidEmail(email) == true)
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Criado Com Sucesso Seu Cadastro",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email invalido",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }

        }
        public void InsertUsuario1(Usuario usuario)
        {
            Connect connection = new Connect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO endereco VALUES 
            (@Rua, @Bairro, @Numero)";

            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);

            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Criado Com Sucesso Seu Cadastro",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);


        }
        public void UpdateUsuario(Usuario usuario)
        {
            Connect connection = new Connect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE [dbo].[User] SET 
            nome= @nome,
            Email= @email, 
            telefone= @telefone,
            CEP= @CEP,
            senha= @senha
            WHERE ID=@id";

            sqlCommand.Parameters.AddWithValue("@nome", usuario.Nome);
            sqlCommand.Parameters.AddWithValue("@email", usuario.Email);
            sqlCommand.Parameters.AddWithValue("@telefone", usuario.telefone);
            sqlCommand.Parameters.AddWithValue("@CEP", usuario.cep);
            sqlCommand.Parameters.AddWithValue("@senha", usuario.senha);
            sqlCommand.Parameters.AddWithValue("@id", usuario.Id);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("EDITADA COM SUCESSO!",
               "AVISO",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }
        public void UpdateUsuario1(Usuario usuario)
        {
            Connect connection = new Connect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE endereco SET 
            Rua = @Rua,
            Bairro = @Bairro
            WHERE Numero_Casa = @Numero";

            sqlCommand.Parameters.AddWithValue("@Rua", usuario.rua);
            sqlCommand.Parameters.AddWithValue("@Bairro", usuario.Bairro);
            sqlCommand.Parameters.AddWithValue("@Numero", usuario.Numero);

            sqlCommand.ExecuteNonQuery();

            MessageBox.Show("EDITADA COM SUCESSO!",
               "AVISO",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
        }
        public void DeletUsuario(int Id)
        {
            Connect connection = new Connect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM [dbo].[user] WHERE ID = @id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
            try
            {
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Excluido com sucesso",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
        }
            public void DeletUsuario1(int Id)
            {
                Connect connection = new Connect();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = connection.ReturnConnection();
                sqlCommand.CommandText = @"DELETE FROM endereco WHERE Numero_Casa = @id";
                sqlCommand.Parameters.AddWithValue("@id", Id);
                try
                {
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Excluido com sucesso",
                    "AVISO",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception err)
                {
                    throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
                }
                finally
                {
                    connection.CloseConnection();
                }
            }
            public void loginUsuario(Usuario usuario)
        {


            // Conexão com o banco de dados
            Connect connect = new Connect();
            SqlConnection connection = connect.ReturnConnection();

            // Consulta SQL para verificar se o usuário existe
            string query = "SELECT ID FROM [dbo].[User] WHERE Email=@Email AND Senha=@Senha";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", usuario.Email);
            command.Parameters.AddWithValue("@Senha", usuario.senha);
            int userId = Convert.ToInt32(command.ExecuteScalar());

            if (userId > 0)
            {
                MessageBox.Show("Login feito com sucesso");
                Form4 form4 = new Form4(userId);
                form4.Show();
            }
            else
            {
                MessageBox.Show("Erro ao fazer login");
            }

            connect.CloseConnection();
        }


    }
}
