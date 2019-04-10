using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pleyada
{
    public partial class Form1 : Form
    {
        List<double> koefficient = new List<double>();
        List<double> koefficientSorted = new List<double>();
        List<double> koefficientOtvet = new List<double>();
        List<List<int>> points = new List<List<int>>();
        List<List<List<int>>> pointsBuffer = new List<List<List<int>>>();
        List<List<int>> lines = new List<List<int>>();
        SolidBrush brushBlack = new SolidBrush(Color.Black);
        SolidBrush brushWhite = new SolidBrush(Color.White);
        Pen penBlack = new Pen(Color.Black);
        Pen penWhite = new Pen(Color.White);
        Font fontBig = new Font("Arial", 12);
        Font fontSmall = new Font("Arial", 8);
        Graphics g;
        bool allPoint = false;
        bool oldPoint = false;
        bool newPoint = false;
        bool newFind = false;
        int k = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        int q = 0;
        int n = 0;
        int m = 0;
        int x = 0;
        int y = 0;
        int number = 0;
        double porog = 0;
        public Form1()
        {
            InitializeComponent();
            koefficient = new List<double>();
            g = pictureBox1.CreateGraphics();
            Random random = new Random();
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 10;
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows[i].Height = 35;
                dataGridView1.RowHeadersWidth = 60;
                dataGridView1.Rows[i].HeaderCell.Value = "X" + (i + 1);
                for (int j = 0; j < 10; j++)
                {
                    dataGridView1.Columns[j].Width = 32;
                    dataGridView1.Columns[i].HeaderText = "X" + (i + 1);
                    if (i == j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = 1;
                    }
                    else if (j > i)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = Convert.ToDouble(random.Next(-100, 100)) / 100;
                        koefficient.Add(Math.Abs(Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value)));
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i > j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[j].Cells[i].Value;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points = new List<List<int>>();
            lines = new List<List<int>>();
            koefficient = new List<double>();
            x = 0;
            y = 0;
            k = 1;
            a = 0;
            g.Clear(Color.White);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j > i)
                    {
                        koefficient.Add(Math.Abs(Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value)));
                    }
                    if (i > j)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[j].Cells[i].Value;
                    }
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    x = 50;
                    y = 300;
                }
                if (i == 1)
                {
                    x = 100;
                    y = 150;
                }
                if (i == 2)
                {
                    x = 250;
                    y = 50;
                }
                if (i == 3)
                {
                    x = 350;
                    y = 50;
                }
                if (i == 4)
                {
                    x = 500;
                    y = 150;
                }
                if (i == 5)
                {
                    x = 550;
                    y = 300;
                }
                if (i == 6)
                {
                    x = 500;
                    y = 450;
                }
                if (i == 7)
                {
                    x = 350;
                    y = 550;
                }
                if (i == 8)
                {
                    x = 250;
                    y = 550;
                }
                if (i == 9)
                {
                    x = 100;
                    y = 450;
                }
                g.FillEllipse(brushBlack, x, y, 10, 10);
                g.DrawString("X" + (i + 1), fontBig, brushBlack, x + 10, y + 10);
                points.Add(new List<int>());
                points[i].Add(x + 5);
                points[i].Add(y + 5);
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = k; j < 10; j++)
                {
                    if (j > i)
                    {
                        g.DrawLine(penBlack, points[i][0], points[i][1], points[j][0], points[j][1]);
                        lines.Add(new List<int>());
                        lines[a].Add(points[i][0]);
                        lines[a].Add(points[i][1]);
                        lines[a].Add(points[j][0]);
                        lines[a].Add(points[j][1]);
                        g.DrawEllipse(penBlack, (points[i][0] + points[j][0]) / 2 - 15, (points[i][1] + points[j][1]) / 2 - 15, 30, 30);
                        g.FillEllipse(brushWhite, (points[i][0] + points[j][0]) / 2 - 14, (points[i][1] + points[j][1]) / 2 - 14, 28, 28);
                        g.DrawString(koefficient[a].ToString(), fontSmall, brushBlack, (points[i][0] + points[j][0]) / 2 - 10, (points[i][1] + points[j][1]) / 2 - 10);
                        a = a + 1;
                    }
                }
                k = k + 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pointsBuffer = new List<List<List<int>>>();
            koefficientSorted = new List<double>();
            koefficientOtvet = new List<double>();
            pointsBuffer.Add(new List<List<int>>());
            x = 0;
            y = 0;
            k = 1;
            q = 0;
            n = 0;
            koefficientSorted.AddRange(koefficient.ToArray());
            koefficientSorted.Sort();
            for (int i = 0; i < 45; i++)
            {
                if (koefficientSorted[i] != koefficientSorted[i + 1])
                {
                    porog = koefficientSorted[i + 1];
                    break;
                }
            }
            if (Convert.ToInt32(textBox1.Text) == 1)
            {
                MessageBox.Show("Порог = " + koefficientSorted[0], "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else if (Convert.ToInt32(textBox1.Text) == 10)
            {
                g.Clear(Color.White);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = k; j < 10; j++)
                    {
                        if (j > i)
                        {
                            g.DrawLine(penWhite, points[i][0], points[i][1], points[j][0], points[j][1]);
                        }
                    }
                    k = k + 1;
                }
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        x = 50;
                        y = 300;
                    }
                    if (i == 1)
                    {
                        x = 100;
                        y = 150;
                    }
                    if (i == 2)
                    {
                        x = 250;
                        y = 50;
                    }
                    if (i == 3)
                    {
                        x = 350;
                        y = 50;
                    }
                    if (i == 4)
                    {
                        x = 500;
                        y = 150;
                    }
                    if (i == 5)
                    {
                        x = 550;
                        y = 300;
                    }
                    if (i == 6)
                    {
                        x = 500;
                        y = 450;
                    }
                    if (i == 7)
                    {
                        x = 350;
                        y = 550;
                    }
                    if (i == 8)
                    {
                        x = 250;
                        y = 550;
                    }
                    if (i == 9)
                    {
                        x = 100;
                        y = 450;
                    }
                    g.FillEllipse(brushBlack, x, y, 10, 10);
                    g.DrawString("X" + (i + 1), fontBig, brushBlack, x + 10, y + 10);
                }
                MessageBox.Show("Порог = " + koefficientSorted[44], "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            else
            {
                while (n < Convert.ToInt32(textBox1.Text) - 1)
                {
                    find();
                    pointsBuffer.Add(new List<List<int>>());
                    q = q + 1;
                    n = n + 1;
                }
                g.Clear(Color.White);
                for (int i = 0; i < 10; i++)
                {
                    if (i == 0)
                    {
                        x = 50;
                        y = 300;
                    }
                    if (i == 1)
                    {
                        x = 100;
                        y = 150;
                    }
                    if (i == 2)
                    {
                        x = 250;
                        y = 50;
                    }
                    if (i == 3)
                    {
                        x = 350;
                        y = 50;
                    }
                    if (i == 4)
                    {
                        x = 500;
                        y = 150;
                    }
                    if (i == 5)
                    {
                        x = 550;
                        y = 300;
                    }
                    if (i == 6)
                    {
                        x = 500;
                        y = 450;
                    }
                    if (i == 7)
                    {
                        x = 350;
                        y = 550;
                    }
                    if (i == 8)
                    {
                        x = 250;
                        y = 550;
                    }
                    if (i == 9)
                    {
                        x = 100;
                        y = 450;
                    }
                    g.FillEllipse(brushBlack, x, y, 10, 10);
                    g.DrawString("X" + (i + 1), fontBig, brushBlack, x + 10, y + 10);
                }
                for (int i = 0; i < 45; i++)
                {
                    g.DrawLine(penBlack, lines[i][0], lines[i][1], lines[i][2], lines[i][3]);
                    if (lines[i][0] != 0)
                    {
                        if (i == 4)
                        {
                            g.DrawString(koefficient[i].ToString(), fontBig, brushBlack, (lines[i][0] + lines[i][2]) / 2 - 40, (lines[i][3] + lines[i][1]) / 2);
                        }
                        else if (i == 21)
                        {
                            g.DrawString(koefficient[i].ToString(), fontBig, brushBlack, (lines[i][0] + lines[i][2]) / 2, (lines[i][3] + lines[i][1]) / 2 - 40);
                        }
                        else
                        {
                            g.DrawString(koefficient[i].ToString(), fontBig, brushBlack, (lines[i][0] + lines[i][2]) / 2, (lines[i][3] + lines[i][1]) / 2);
                        }
                    }
                }
                for (int i = 0; i < 45; i++)
                {
                    if (lines[i][0] != 0)
                    {
                        koefficientOtvet.Add(koefficient[i]);
                    }
                }
                koefficientOtvet.Sort();
                MessageBox.Show("Порог = " + koefficientOtvet[0], "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

            }          
        }

        private void find()
        {
            newFind = false;
            for (int i = koefficientSorted.IndexOf(porog); i < 45; i++)
            {
                for (int j = 0; j < 45; j++)
                {
                    if ((koefficientSorted[i] > koefficient[j]) && (lines[j][0] != 0))
                    {
                        newFind = true;
                        b = 0;
                        pointsBuffer[q] = new List<List<int>>();
                        g.DrawLine(penWhite, lines[j][0], lines[j][1], lines[j][2], lines[j][3]);
                        for (int r = 0; r < pointsBuffer.Count; r++)
                        {
                            number = 0;
                            for (int l = 0; l < pointsBuffer[r].Count; l++)
                            {
                                if (((pointsBuffer[r][l][0] == lines[j][0]) && (pointsBuffer[r][l][1] == lines[j][1])) || ((pointsBuffer[r][l][0] == lines[j][2]) && (pointsBuffer[r][l][1] == lines[j][3])))
                                {
                                    number = number + 1;
                                }
                                if (number == 2)
                                {
                                    m = r;
                                    break;
                                }
                            }
                        }
                        lines[j][0] = 0;
                        lines[j][1] = 0;
                        lines[j][2] = 0;
                        lines[j][3] = 0;
                        pointsBuffer[q].Add(new List<int>());
                        if (n == 0)
                        {
                            pointsBuffer[q][b].Add(points[0][0]);
                            pointsBuffer[q][b].Add(points[0][1]);
                        }
                        else
                        {
                            pointsBuffer[q][b].Add(pointsBuffer[m][0][0]);
                            pointsBuffer[q][b].Add(pointsBuffer[m][0][1]);
                        }
                        b = b + 1;
                        findPart();
                        if (n == 0)
                        {
                            if (pointsBuffer[0].Count < points.Count)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (pointsBuffer[m].Count > pointsBuffer[q].Count)
                            {
                                break;
                            }
                        }
                    }
                }
                if (n == 0)
                {
                    if (pointsBuffer[0].Count < points.Count)
                    {
                        newPoint = false;
                        pointsBuffer.Add(new List<List<int>>());
                        q = q + 1;
                        c = 0;
                        for (int j = 0; j < 10; j++)
                        {
                            for (int t = 0; t < pointsBuffer[0].Count; t++)
                            {
                                if ((pointsBuffer[0][t][0] == points[j][0]) && (pointsBuffer[0][t][1] == points[j][1]))
                                {
                                    newPoint = true;
                                }
                            }
                            if (!newPoint)
                            {
                                pointsBuffer[q].Add(new List<int>());
                                pointsBuffer[q][c].Add(points[j][0]);
                                pointsBuffer[q][c].Add(points[j][1]);
                                c = c + 1;
                            }
                            newPoint = false;
                        }
                        porog = koefficientSorted[i];
                        break;
                    }
                }
                if ((newFind) && (q != 0))
                {
                    if (pointsBuffer[m].Count > pointsBuffer[q].Count)
                    {
                        newPoint = false;
                        pointsBuffer.Add(new List<List<int>>());
                        q = q + 1;
                        c = 0;
                        for (int j = 0; j < pointsBuffer[m].Count; j++)
                        {
                            for (int t = 0; t < pointsBuffer[q - 1].Count; t++)
                            {
                                if ((pointsBuffer[q - 1][t][0] == pointsBuffer[m][j][0]) && (pointsBuffer[q - 1][t][1] == pointsBuffer[m][j][1]))
                                {
                                    newPoint = true;
                                }
                            }
                            if (!newPoint)
                            {
                                pointsBuffer[q].Add(new List<int>());
                                pointsBuffer[q][c].Add(pointsBuffer[m][j][0]);
                                pointsBuffer[q][c].Add(pointsBuffer[m][j][0]);
                                c = c + 1;
                            }
                            newPoint = false;
                        }
                        porog = koefficientSorted[i];
                        break;
                    }
                }
            }
        }

        private void findPart()
        {
            allPoint = false;
            oldPoint = false;
            for (int i = 0; i < pointsBuffer[q].Count; i++)
            {
                for (int j = 0; j < 45; j++)
                {              
                    if ((pointsBuffer[q][i][0] == lines[j][0]) && (pointsBuffer[q][i][1] == lines[j][1]))
                    {
                        for (int t = 0; t < pointsBuffer[q].Count; t++)
                        {
                            if ((pointsBuffer[q][t][0] == lines[j][2]) && (pointsBuffer[q][t][1] == lines[j][3]))
                            {
                                oldPoint = true;
                            }
                        }
                        if (!oldPoint)
                        {
                            pointsBuffer[q].Add(new List<int>());
                            pointsBuffer[q][b].Add(lines[j][2]);
                            pointsBuffer[q][b].Add(lines[j][3]);
                            b = b + 1;
                            allPoint = true;
                        }
                    }
                    oldPoint = false;
                    if ((pointsBuffer[q][i][0] == lines[j][2]) && (pointsBuffer[q][i][1] == lines[j][3]))
                    {
                        for (int t = 0; t < pointsBuffer[q].Count; t++)
                        {
                            if ((pointsBuffer[q][t][0] == lines[j][0]) && (pointsBuffer[q][t][1] == lines[j][1]))
                            {
                                oldPoint = true;
                            }
                        }
                        if (!oldPoint)
                        {
                            pointsBuffer[q].Add(new List<int>());
                            pointsBuffer[q][b].Add(lines[j][0]);
                            pointsBuffer[q][b].Add(lines[j][1]);
                            b = b + 1;
                            allPoint = true;
                        }
                    }
                }
            }
            if (allPoint)
            {
                findPart();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
