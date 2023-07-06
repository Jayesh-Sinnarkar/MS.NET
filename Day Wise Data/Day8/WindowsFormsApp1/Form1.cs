using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.MyTypedDataSetTableAdapters;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyTypedDataSet ds;
        private void button1_Click(object sender, EventArgs e)
        {
            DepartmentsTableAdapter daDeps = new DepartmentsTableAdapter();
            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();
            ds = new MyTypedDataSet();

            daDeps.Fill(ds.Departments);
            daEmps.Fill(ds.Employees);
            dataGridView1.DataSource = ds.Employees;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepartmentsTableAdapter daDeps = new DepartmentsTableAdapter();
            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();

            daEmps.Update(ds.Employees);
        }
    }
}
