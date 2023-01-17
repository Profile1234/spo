using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

  
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.Owner;

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                frm.dataGridView1.Rows.Clear();

                foreach (var movements in frm.Movements
                    .Where(z =>
                        z.Name == groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text &&
                        z.Coordinate >= double.Parse(textBox1.Text) &&
                        z.Coordinate <= double.Parse(textBox2.Text)).ToList())
                {
                    frm.dataGridView1.Rows.Add(movements.Name, movements.Coordinate);
                }

                this.Close();
            }
            else MessageBox.Show("Заполните все поля");
        }
    }
}
