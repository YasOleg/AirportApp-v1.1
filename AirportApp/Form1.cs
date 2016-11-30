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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private void Form1_Load(object sender, EventArgs e)
        {

        }
         DataSet dsSet = new DataSet();

         private void button1_Click(object sender, EventArgs e)
        {
            AddForm frmADD = new AddForm(this);
            frmADD.Show();
        }
       
        private void btnDelInfo_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);

            StreamWriter myWritet = new StreamWriter("Airport_INFO.txt");
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
            {
               myWritet.Write(dataGridView1.Columns[j].HeaderText.ToString() + ",");
            }
            myWritet.WriteLine();
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount - 1; j++)
                {
                    myWritet.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "/");
                }
                myWritet.WriteLine();
            }
            myWritet.Close();
        }

        public void FuncDataRead()
        {
            StreamReader strReader = new StreamReader("Airport_INFO.txt");
            dsSet.Tables.Add(new DataTable());
            string header = strReader.ReadLine();

            string[] colName = System.Text.RegularExpressions.Regex.Split(header, ",");

            for (int i = 0; i < colName.Length; i++)
            {
                dsSet.Tables[0].Columns.Add(colName[i]);
            }
            string row = strReader.ReadLine();
            while (row != null)
            {
                string[] rowValue = System.Text.RegularExpressions.Regex.Split(row, "/");
                dsSet.Tables[0].Rows.Add(rowValue);
                row = strReader.ReadLine();
            }

            dataGridView1.DataSource = dsSet.Tables[0];
            strReader.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(tbSearch.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            MessageBox.Show("Entry is found in a database...", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                       
            }
           
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Enabled)
            {
                FuncDataRead();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            
        }

        string text = @"            Помните, что в случае пожара на борту самолета наибольшую 
опасность представляет дым, а не огонь. Дышите только через хлопчатобумажные или шерстяные элементы одежды, 
по возможности, смоченные водой. Пробираясь к выходу, двигайтесь пригнувшись или на четвереньках, так как внизу 
салона задымленность меньше. Защитите открытые участки тела от прямого воздействия огня, используя имеющуюся одежду,
пледы и т.д. После приземления и остановки самолета немедленно направляйтесь к ближайшему выходу, 
так как высока вероятность взрыва. Если проход завален, пробирайтесь через кресла, опуская их спинки. 
При эвакуации избавьтесь от ручной клади и избегайте выхода через люки, вблизи которых имеется открытый огонь или сильная задымленность.
После выхода из самолета удалитесь от него как можно дальше и лягте на землю, прижав голову руками – возможен взрыв.
В любой ситуации действуйте без паники и решительно, это способствует Вашему спасению.";

        private void timer1_Tick(object sender, EventArgs e)
        {
            text = text.Substring(1) + text[0];
            tbWarning.Text = text;
        }

        private void btnWarning_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }
    }
}
