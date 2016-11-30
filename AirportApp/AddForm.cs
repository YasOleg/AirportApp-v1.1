using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AirportApp
{
    public partial class AddForm : Form
    {
        public AddForm(Form1 _frm)
        {
            InitializeComponent();
            frm = _frm;
        }
        public Form1 frm;
        private void AddForm_Load(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void DBfunk()
        {
            try
            {
                FileStream fileStream = new FileStream("Airport_INFO.txt", FileMode.Append);//запись в конец файла
                StreamWriter strWriter = new StreamWriter(fileStream);

                string lines = tbNumberFly.Text + "/" + tbArrival.Text + "/" + tbDepart.Text + "/" +
                               tbDirection.Text + "/" + tbAirline.Text + "/" + tbTerminal.Text + "/" +
                               cbStatus.Text;

                strWriter.Write("\r\n" + lines);
                strWriter.Close();
                
                MessageBox.Show("Information added", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNumberFly.Text == "" && tbArrival.Text == "" && tbDepart.Text == "" &&
                tbDirection.Text == "" && tbAirline.Text == "" && tbTerminal.Text == "" &&
                cbStatus.Text == "")
            {
                MessageBox.Show("One of the elements is not assepted", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else DBfunk();
        }
    }
}
