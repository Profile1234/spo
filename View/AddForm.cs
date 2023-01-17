using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class AddForm : Form
    {
        public AddForm()
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

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Visible = false;
            label4.Visible = false;
            label1.Text = "Координата";
            label2.Text = "Время";
            label3.Text = "Скорость";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            label4.Visible = true;
            label1.Text = "Амплитуда";
            label2.Text = "Цикл. частота";
            label3.Text = "Время";
            label4.Text = "Фаза";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.Visible = true;
            label4.Visible = true;
            label1.Text = "Координата";
            label2.Text = "Скорость";
            label3.Text = "Время";
            label4.Text = "Ускорение";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = (Form1)this.Owner;

            try
            {
                switch (groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked)?.Text)
                {
                    case "Равномерное движение":
                        frm.AddToList(new Uniform()
                        {
                            StartTimeCoordinate = double.Parse(textBox1.Text),
                            Time = double.Parse(textBox2.Text),
                            Speed = double.Parse(textBox3.Text)
                        });
                        break;
                    case "Колебательное движение":
                        frm.AddToList(new Oscillatory()
                        {
                            Amplitude = double.Parse(textBox1.Text),
                            CyclicFrequency = double.Parse(textBox2.Text),
                            Time = double.Parse(textBox3.Text),
                            InitialPhase = double.Parse(textBox4.Text)
                        });
                        break;
                    case "Равноускоренное движение":
                        frm.AddToList(new UniformlyAccelerated()
                        {
                            StartTimeCoordinate = double.Parse(textBox1.Text),
                            StartSpeed = double.Parse(textBox2.Text),
                            Time = double.Parse(textBox3.Text),
                            Acceleration = double.Parse(textBox4.Text)
                        });
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
