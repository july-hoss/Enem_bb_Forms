using MySql.Data.MySqlClient;
namespace Enem_bb

{
    public partial class Form1 : Form
    {
        string conexaoString = "server=localhost;database=Enem_bb;uid=root;pwd=;";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Preencha pelo menos o Nome e o CPF!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {
                try
                {
                    conexao.Open(); // Abre a porta de comunicação

                    // Comando SQL de inserção protegido por parâmetros
                    string query = "INSERT INTO aluno (nome, cpf, email, telefone, turno) VALUES (@nome, @cpf, @email, @telefone, @turno)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conexao))
                    {
                        // Passa os valores das caixinhas da tela para as variáveis do SQL
                        cmd.Parameters.AddWithValue("@nome", textBox1.Text);
                        cmd.Parameters.AddWithValue("@cpf", textBox2.Text);
                        cmd.Parameters.AddWithValue("@email", textBox3.Text);
                        cmd.Parameters.AddWithValue("@telefone", textBox4.Text);
                        cmd.Parameters.AddWithValue("@turno", textBox5.Text);

                        cmd.ExecuteNonQuery(); // Executa o comando no banco

                        MessageBox.Show("Aluno cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa os campos após salvar
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                        login telalogin = new login();
                        telalogin.Show();
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}