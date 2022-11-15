using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iamsobad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void studentListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.studentListBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.iamsobadDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "iamsobadDataSet.StudentList". При необходимости она может быть перемещена или удалена.
            this.studentListTableAdapter.Fill(this.iamsobadDataSet.StudentList);
            studentListBindingSource.DataSource = this.iamsobadDataSet.StudentList;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from student in this.iamsobadDataSet.StudentList where student.FIO == textBox1.Text 
                        select student;
            studentListBindingSource.DataSource = query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            var query = from student in this.iamsobadDataSet.StudentList select student;
            studentListBindingSource.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
