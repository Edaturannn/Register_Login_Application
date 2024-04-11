using System.Data.SqlClient;
namespace Deneme_Login_Uygulamasi
{
    public partial class Form1 : Form
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=LAPTOP-2PUE7SMB;Initial Catalog=Kayit_Giris_Sistemi;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x, mouse_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Username = textBox1.Text;
            string Password = textBox2.Text;
            bool IsThere = false;
            Connection.Open();

            SqlCommand Command = new SqlCommand("Select * From Kayit_Giris_Tablosu", Connection);
            SqlDataReader Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                if (Username == Reader["Username"].ToString().TrimEnd() && Password == Reader["Password"].ToString().TrimEnd())
                {
                    IsThere = true;
                    break;
                }
                else
                {
                    IsThere = false;
                }
               
            }
            if (IsThere)
            {
                MessageBox.Show("Baþarýlý bir þekilde giriþ yaptýnýz...","Program");
                this.Hide();
            }
            else
            {
                MessageBox.Show("Baþarýlý bir þekilde giriþ yapamadýnýz...","Program");
            }
            Connection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}