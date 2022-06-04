using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_DEV;

namespace Database
{
    public partial class FrmConnectDB : Form
    {
        public FrmConnectDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", 
                comboBox1.Text,textBox1.Text,textBox2.Text,textBox3.Text);
            try
            {
                SqlHelper sqlHelper = new SqlHelper(_connectionString);
                if( sqlHelper.IsConnection)
                {
                    MessageBox.Show("Test Connection Done");
                }
            }
            catch( Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadServer()
        {

            comboBox1.Items.Add(".");
            comboBox1.Items.Add("(local)");
            comboBox1.Items.Add(@".\SQLEXPRESS");
            comboBox1.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            comboBox1.SelectedIndex = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadServer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _connectionString = string.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}",
                           comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text);
            try
            {
                SqlHelper sqlHelper = new SqlHelper(_connectionString);
                if (sqlHelper.IsConnection)
                {
                    AppSettings appSettings = new AppSettings();
                    appSettings.SaveConnectionString("sqlConnection", _connectionString);
                    MessageBox.Show("Test Connection Done");
                    Form1 Login = new Form1();
                    Login.Show();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
