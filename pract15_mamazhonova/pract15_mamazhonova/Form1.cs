using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract15_mamazhonova
{
    public partial class Form1 :Form
    {
        int i = 0;
        public Form1 ()
        {
            InitializeComponent( );
        }

        private void Form1_Load (object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }

        private void button1_Click (object sender, EventArgs e)
        {
            try
            {
                i++;
                if ( radioButton1.Checked == true )
                {
                    Complex c1 = new Complex( );
                    Complex c2 = new Complex( );
                    double a = Convert.ToDouble(textBox1.Text);
                    double b = Convert.ToDouble(textBox2.Text);
                    double a2 = Convert.ToDouble(textBox3.Text);
                    double b2 = Convert.ToDouble(textBox4.Text);
                    c1.r = a;
                    c1.i = b;
                    c2.r = a2;
                    c2.i = b2;
                    label4.Text = Convert.ToString("Сложение комплексных чисел: " + c1.Sum(c1, c2).r + " +" + " " + c2.Sum(c1, c2).i + "i");



                }
                if ( radioButton2.Checked == true )
                {
                    Complex c1 = new Complex( );
                    Complex c2 = new Complex( );
                    int a = Convert.ToInt32(textBox1.Text);
                    int b = Convert.ToInt32(textBox2.Text);
                    int a2 = Convert.ToInt32(textBox3.Text);
                    int b2 = Convert.ToInt32(textBox4.Text);
                    c1.r = a;
                    c1.i = b;
                    c2.r = a2;
                    c2.i = b2;
                    if ( c2.Razn(c1, c2).i > 0 )
                        label4.Text = Convert.ToString("Вычитание комплексных чисел: " + c1.Razn(c1, c2).r + " -" + " " + c2.Razn(c1, c2).i + "i");
                    else
                        label4.Text = Convert.ToString("Вычитание комплексных чисел: " + c1.Razn(c1, c2).r + " +" + " " + c2.Razn(c1, c2).i + "i");
                }
                if ( radioButton3.Checked == true )
                {
                    Complex c1 = new Complex( );
                    Complex c2 = new Complex( );
                    double a = Convert.ToDouble(textBox1.Text);
                    double b = Convert.ToDouble(textBox2.Text);
                    double a2 = Convert.ToDouble(textBox3.Text);
                    double b2 = Convert.ToDouble(textBox4.Text);
                    c1.r = a;
                    c1.i = b;
                    c2.r = a2;
                    c2.i = b2;
                    label4.Text = Convert.ToString("Умножение комплексных чисел: " + c1.Proizv(c1, c2).r + " *" + " " + c2.Proizv(c1, c2).i + "i");
                }
                StreamWriter sr = File.AppendText("file.txt");
                if ( textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" )
                {
                    if ( i > 1 )
                    {
                        sr.WriteLine(textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);
                    }
                    else sr.WriteLine("\n" + textBox1.Text + " " + textBox2.Text + " " + textBox3.Text + " " + textBox4.Text);

                }
                else MessageBox.Show("Пустые строки", "Ошибка", MessageBoxButtons.OK);
                sr.Close( );
            }
            catch { MessageBox.Show("Введены неправильные значения", "Ошибка", MessageBoxButtons.OK); }
        }

        private void radioButton1_CheckedChanged (object sender, EventArgs e)
        {
            try
            {
                string [ ] sr = File.ReadAllLines("file.txt");
                ArrayList com = new ArrayList( );
                ArrayList com2 = new ArrayList( );
                ArrayList com3 = new ArrayList( );
                string [ ] s;
                foreach ( string ss in sr )
                {
                    s = ss.Split(' ');
                    Complex c3 = new Complex( );
                    Complex c4 = new Complex( );
                    double a3 = Convert.ToDouble(s [ 0 ]);
                    double b3 = Convert.ToDouble(s [ 1 ]);
                    double a4 = Convert.ToDouble(s [ 2 ]);
                    double b4 = Convert.ToDouble(s [ 3 ]);
                    c3.r = a3;
                    c3.i = b3;
                    com [ 0 ] = c3;
                    c4.r = a4;
                    c4.i = b4;

                    com3.Add(Convert.ToString(c3.Sum(c3, c4).r + " +" + " " + c4.Sum(c3, c4).i + "i"));
                    com.Add(c3);
                    com2.Add(c4);
                }
                dataGridView1.ColumnCount = 5;
                dataGridView1.RowCount = com.Count;
                dataGridView1.Columns [ 0 ].HeaderCell.Value = "А1";
                dataGridView1.Columns [ 1 ].HeaderCell.Value = "Б1";
                dataGridView1.Columns [ 2 ].HeaderCell.Value = "А2";
                dataGridView1.Columns [ 3 ].HeaderCell.Value = "Б2";
                dataGridView1.Columns [ 4 ].HeaderCell.Value = "Ответ";
                for ( int i = 0; i < dataGridView1.RowCount; i++ )
                {
                    dataGridView1.Rows [ i ].HeaderCell.Value = (i + 1);
                    for ( int j = 0; j < dataGridView1.ColumnCount; j++ )
                    {
                        dataGridView1 [ 0, i ].Value = ((Complex) com [ i ]).r;
                        dataGridView1 [ 1, i ].Value = ((Complex) com [ i ]).i;
                        dataGridView1 [ 2, i ].Value = ((Complex) com2 [ i ]).r;
                        dataGridView1 [ 3, i ].Value = ((Complex) com2 [ i ]).i;
                        Complex c1 = new Complex( );
                        Complex c2 = new Complex( );
                        dataGridView1 [ 4, i ].Value = com3 [ i ];
                    }

                }
            }
            catch { MessageBox.Show("Введены неправильные значения", "Ошибка", MessageBoxButtons.OK); }
        }

        private void radioButton2_CheckedChanged (object sender, EventArgs e)
        {
            string [ ] sr = File.ReadAllLines("file.txt");
            ArrayList com = new ArrayList( );
            ArrayList com2 = new ArrayList( );
            ArrayList com3 = new ArrayList( );
            string [ ] s;
            foreach ( string ss in sr )
            {
                s = ss.Split(' ');
                Complex c3 = new Complex( );
                Complex c4 = new Complex( );
                double a3 = Convert.ToDouble(s [ 0 ]);
                double b3 = Convert.ToDouble(s [ 1 ]);
                double a4 = Convert.ToDouble(s [ 2 ]);
                double b4 = Convert.ToDouble(s [ 3 ]);
                c3.r = a3;
                c3.i = b3;
                c4.r = a4;
                c4.i = b4;
                if ( c4.Razn(c3, c4).i > 0 )
                    com3.Add(Convert.ToString(c3.Razn(c3, c4).r + " +" + " " + c4.Razn(c3, c4).i + "i"));
                else com3.Add(Convert.ToString(c3.Razn(c3, c4).r + " -" + " " + c4.Razn(c3, c4).i + "i"));
                com.Add(c3);
                com2.Add(c4);
            }
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = com.Count;
            dataGridView1.Columns [ 0 ].HeaderCell.Value = "А1";
            dataGridView1.Columns [ 1 ].HeaderCell.Value = "Б1";
            dataGridView1.Columns [ 2 ].HeaderCell.Value = "А2";
            dataGridView1.Columns [ 3 ].HeaderCell.Value = "Б2";
            dataGridView1.Columns [ 4 ].HeaderCell.Value = "Ответ";
            for ( int i = 0; i < dataGridView1.RowCount; i++ )
            {
                dataGridView1.Rows [ i ].HeaderCell.Value = (i + 1);
                for ( int j = 0; j < dataGridView1.ColumnCount; j++ )
                {
                    dataGridView1 [ 0, i ].Value = ((Complex) com [ i ]).r;
                    dataGridView1 [ 1, i ].Value = ((Complex) com [ i ]).i;
                    dataGridView1 [ 2, i ].Value = ((Complex) com2 [ i ]).r;
                    dataGridView1 [ 3, i ].Value = ((Complex) com2 [ i ]).i;
                    Complex c1 = new Complex( );
                    Complex c2 = new Complex( );
                    dataGridView1 [ 4, i ].Value = com3 [ i ];
                }

            }
        }

        private void radioButton3_CheckedChanged (object sender, EventArgs e)
        {
            string [ ] sr = File.ReadAllLines("file.txt");
            ArrayList com = new ArrayList( );
            ArrayList com2 = new ArrayList( );
            ArrayList com3 = new ArrayList( );
            string [ ] s;
            foreach ( string ss in sr )
            {
                s = ss.Split(' ');
                Complex c3 = new Complex( );
                Complex c4 = new Complex( );
                double a3 = Convert.ToDouble(s [ 0 ]);
                double b3 = Convert.ToDouble(s [ 1 ]);
                double a4 = Convert.ToDouble(s [ 2 ]);
                double b4 = Convert.ToDouble(s [ 3 ]);
                c3.r = a3;
                c3.i = b3;
                c4.r = a4;
                c4.i = b4;

                com3.Add(Convert.ToString(c3.Proizv(c3, c4).r + " *" + " " + c4.Proizv(c3, c4).i + "i"));
                com.Add(c3);
                com2.Add(c4);
            }
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = com.Count;
            dataGridView1.Columns [ 0 ].HeaderCell.Value = "А1";
            dataGridView1.Columns [ 1 ].HeaderCell.Value = "Б1";
            dataGridView1.Columns [ 2 ].HeaderCell.Value = "А2";
            dataGridView1.Columns [ 3 ].HeaderCell.Value = "Б2";
            dataGridView1.Columns [ 4 ].HeaderCell.Value = "Ответ";
            for ( int i = 0; i < dataGridView1.RowCount; i++ )
            {
                dataGridView1.Rows [ i ].HeaderCell.Value = (i + 1);
                for ( int j = 0; j < dataGridView1.ColumnCount; j++ )
                {
                    dataGridView1 [ 0, i ].Value = ((Complex) com [ i ]).r;
                    dataGridView1 [ 1, i ].Value = ((Complex) com [ i ]).i;
                    dataGridView1 [ 2, i ].Value = ((Complex) com2 [ i ]).r;
                    dataGridView1 [ 3, i ].Value = ((Complex) com2 [ i ]).i;
                    Complex c1 = new Complex( );
                    Complex c2 = new Complex( );
                    dataGridView1 [ 4, i ].Value = com3 [ i ];
                }

            }
        }

        private void label5_Click (object sender, EventArgs e)
        {

        }
    }
}
