using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class Form1 : Form
    {
        public IList<IMovement> Movements = new List<IMovement>();

        /// <summary>
        /// Добавить в список
        /// </summary>
        public void AddToList(IMovement movement)
        {
            Movements.Add(movement);
            dataGridView1.Rows.Add(movement.Name, movement.Coordinate);
        }

        public Form1()
        {
            InitializeComponent();
        }

        //Добавить
        private void button1_Click(object sender, EventArgs e)
        {
            new AddForm() { Owner = this, Text = "Добавить" }.ShowDialog();
        }

        //Удалить
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow?.Cells[0].Value == null) return;
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            Movements.RemoveAt(dataGridView1.CurrentCell.RowIndex);
        }

        //Случайно
        private void button3_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            switch (rnd.Next(1, 4))
            {
                case 1:
                    AddToList(new Oscillatory()
                    {
                        Amplitude = rnd.NextDouble() + 1251,
                        CyclicFrequency = rnd.NextDouble() + 1251,
                        Time = rnd.NextDouble() + 1251,
                        InitialPhase = rnd.NextDouble() + 1251
                    });
                    break;
                case 2:
                    AddToList(new Uniform()
                    {
                        StartTimeCoordinate = rnd.NextDouble() + 1251,
                        Time = rnd.NextDouble() + 1251,
                        Speed = rnd.NextDouble() + 1251
                    });
                    break;
                case 3:
                    AddToList(new UniformlyAccelerated()
                    {
                        StartTimeCoordinate = rnd.NextDouble() + 1251,
                        StartSpeed = rnd.NextDouble() + 1251,
                        Time = rnd.NextDouble() + 1251,
                        Acceleration = rnd.NextDouble() + 1251
                    });
                    break;
            }
        }

        //Сохранить
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                FileStream file = File.Create(saveFileDialog1.FileName);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, Movements);
                file.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Загрузить
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
                FileStream file = File.OpenRead(openFileDialog1.FileName);
                BinaryFormatter formatter = new BinaryFormatter();
                Movements.Clear();
                dataGridView1.Rows.Clear();
                if (Movements != null)
                    foreach (var figure in (IList<IMovement>)formatter.Deserialize(file))
                    {
                        AddToList(figure);
                    }
                file.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Поиск
        private void button6_Click(object sender, EventArgs e)
        {
            new FindForm() { Owner = this, Text = "Поиск" }.ShowDialog();
        }

        //Сброс
        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            foreach (var motion in Movements)
            {
                dataGridView1.Rows.Add(motion.Name, motion.Coordinate);
            }
        }
    }
}
