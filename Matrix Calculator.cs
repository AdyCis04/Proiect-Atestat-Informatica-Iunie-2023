using System;
using static System.Math;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATRIX_CALCULATOR
{
    public partial class Form1 : Form
    {
        public class Matrix
        {
            public string text;
            public double[,] M;
            public int linii;
            public int coloane;
        }

        public class nod
        {
            public string afisare;
            public long ord;
            public Matrix[] rezults;
            public int numMat;
            public nod ant;
            public nod urm;
        }

        DateTime now = DateTime.Now;
        string sem = "UK";

        Button RemRez = new Button()
        {
            Text = "REMOVE PAGE",
            Top = 1550,
            Left = 290,
            Height = 50,
            Width = 200,
            Name = "remrez",
            Enabled = true,
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.White,
            ForeColor = Color.ForestGreen,
        };

        Button UK = new Button()
        {
            Top = 50,
            Left = 1400,
            Height = 35,
            Width = 150,
            Name = "UK",
            Text = "ENGLISH",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Regular),
            Visible = true,
            ForeColor = Color.White,
            BackColor = Color.ForestGreen,
        };

        Button RO = new Button()
        {
            Top = 50,
            Left = 1550,
            Height = 35,
            Width = 150,
            Name = "RO",
            Text = "ROMANIAN",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Regular),
            Visible = true,
            ForeColor = Color.White,
            BackColor = Color.ForestGreen,
        };

        Label Header = new Label()
        {
            Top = 50,
            Left = 0,
            Height = 35,
            Width = 10200,
            Name = "TMC",
            Text = "     THE  MATRIX  CALCULATOR",
            Font = new Font("Courier New", 20, FontStyle.Bold),
            Visible = true,
            BackColor = Color.Black,
            ForeColor = Color.PaleGreen,
        };

        Label Footer = new Label()
        {
            Top = 1770,
            Left = 0,
            Height = 20,
            Width = 10200,
            Name = "TMC",
            Text = "",
            Font = new Font("Courier New", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.Black,
            ForeColor = Color.PaleGreen,
        };

        TextBox[] prmtTB = new TextBox[10];
        Label[] prmtL = new Label[10];

        long numRez = 0;
        nod rezultateRO = null;
        nod rezultateUK = null;

        ComboBox From = new ComboBox()
        {
            Top = 1650,
            Left = 190,
            Height = 30,
            Width = 80,
            Name = "From",
            Text = "",
            Font = new Font("Consolas", 10, FontStyle.Regular),
            Visible = true,
            Enabled = true,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        ComboBox To = new ComboBox()
        {
            Top = 1650,
            Left = 340,
            Height = 30,
            Width = 120,
            Name = "To",
            Text = "",
            Font = new Font("Consolas", 10, FontStyle.Regular),
            Visible = true,
            Enabled = true,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        Button insBut = new Button()
        {
            Top = 1650,
            Left = 470,
            Height = 30,
            Width = 45,
            Name = "insBut",
            Text = "->",
            Font = new Font("Consolas", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.White,
            ForeColor = Color.ForestGreen,
        };
        Label CB1 = new Label()
        {
            Top = 1650,
            Left = 90,
            Height = 30,
            Width = 100,
            Name = "CB1",
            Text = "INSERT",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.Transparent,
        };
        Label CB2 = new Label()
        {
            Top = 1650,
            Left = 290,
            Height = 30,
            Width = 50,
            Name = "CB2",
            Text = "TO",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.Transparent,
        };

        ComboBox alternatives = new ComboBox()
        {
            Text = "",
            Top = 700,
            Left = 470,
            Name = "alter",
            Width = 200,
            Height = 30,
            Font = new Font("Consolas", 10, FontStyle.Regular),
            Visible = true,
            Enabled = true,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        Label nrRez = new Label()
        {
            Top = 1110,
            Left = 390,
            Name = "nrRez",
            Text = "",
            Width = 600,
            Height = 30,
            Font = new Font("Bahnschrift SemiBold", 14, FontStyle.Regular),
            Visible = true,
            BackColor = Color.Transparent,
        };

        Button solve = new Button()
        {
            Text = "SOLVE",
            Top = 700,
            Left = 670,
            Name = "solve",
            Width = 100,
            Height = 30,
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            Enabled = true,
            BackColor = Color.ForestGreen,
            ForeColor = Color.White,
        };

        string newLine = Environment.NewLine;

        Button swap = new Button();
        Button multiply = new Button();
        Button add = new Button();
        Button powerA = new Button()
        {
            Top = 800,
            Left = 90,
            Height = 50,
            Width = 250,
            Name = "powerA",
            Text = "RAISE TO THE POWER OF",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            Enabled = true,
            BackColor = Color.ForestGreen,
            ForeColor = Color.White,
        };
        TextBox powertbA = new TextBox()
        {
            Top = 800,
            Left = 340,
            Height = 50,
            Width = 100,
            Name = "powertbA",
            Text = "",
            Multiline = true,
            Font = new Font("Consolas", 12, FontStyle.Regular),
            Visible = true,
            Enabled = true,
            TextAlign = HorizontalAlignment.Center,
        };

        Button powerB = new Button()
        {
            Left = 800,
            Top = 800,
            Height = 50,
            Width = 250,
            Name = "powerB",
            Text = "RAISE TO THE POWER OF",
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            Enabled = true,
            BackColor = Color.ForestGreen,
            ForeColor = Color.White,
        };
        TextBox powertbB = new TextBox()
        {
            Left = 1050,
            Top = 800,
            Height = 50,
            Width = 100,
            Name = "powertbB",
            Text = "",
            Multiline = true,
            Font = new Font("Consolas", 12, FontStyle.Regular),
            Visible = true,
            Enabled = true,
            TextAlign = HorizontalAlignment.Center,
        };

        Label matrixA = new Label();
        Label matrixB = new Label();


        Label liniiA = new Label(), coloaneA = new Label();
        Label liniiB = new Label(), coloaneB = new Label();

        Label down = new Label();
        Label east = new Label();

        Random r = new Random();

        Button slA = new Button(), slB = new Button();
        Button clA = new Button(), clB = new Button();
        Button scA = new Button(), scB = new Button();
        Button ccA = new Button(), ccB = new Button();

        Button dA = new Button(), dB = new Button();
        Button inveA = new Button(), inveB = new Button();
        Button rankA = new Button(), rankB = new Button();
        Button transA = new Button(), transB = new Button();
        Button esalonA = new Button(), esalonB = new Button();
        Button luA = new Button(), luB = new Button();
        Button multibyA = new Button(), multibyB = new Button();
        TextBox mulA = new TextBox();
        TextBox mulB = new TextBox();

        Button clearA = new Button(), clearB = new Button();
        Button randA = new Button(), randB = new Button();
        Button te0A = new Button(), te0B = new Button();
        Button te1A = new Button(), te1B = new Button();
        Button adjA = new Button(), adjB = new Button();

        TextBox[,] vA = new TextBox[10, 10];
        TextBox[,] vB = new TextBox[10, 10];

        int lA = 3, cA = 3, lB = 3, cB = 3;

        TextBox display = new TextBox()
        {
            Top = 1150,
            Left = 90,
            Name = "displayTextBox",
            Text = " The results of your operations will be displayed right here.",
            Height = 400,
            Width = 10000,
            Enabled = false,
            Multiline = true,
            Font = new Font("Consolas", 10, FontStyle.Regular),
            Visible = true,
        };

        Button prev = new Button()
        {
            Top = 1100,
            Left = 90,
            Name = "prev",
            Text = "PREVIOUS",
            Height = 50,
            Width = 150,
            Enabled = false,
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.White,
            ForeColor = Color.ForestGreen,
        };

        Button next = new Button()
        {
            Top = 1100,
            Left = 240,
            Name = "next",
            Text = "NEXT",
            Height = 50,
            Width = 150,
            Enabled = false,
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.White,
            ForeColor = Color.ForestGreen,
        };

        Button clearHistory = new Button()
        {
            Top = 1550,
            Left = 90,
            Name = "clearHistory",
            Text = "CLEAR HISTORY",
            Height = 50,
            Width = 200,
            Enabled = true,
            Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
            Visible = true,
            BackColor = Color.White,
            ForeColor = Color.ForestGreen,
        };

        public Form1()
        {
            InitializeComponent();

            Footer.Text = "         (C) " + now.Year.ToString() + " The Matrix Calculator";

            Controls.Add(UK); Controls.Add(RO);
            UK.Click += new System.EventHandler(eng);
            RO.Click += new System.EventHandler(rom);

            Controls.Add(Header); Controls.Add(Footer);

            swap.Text = "<->";
            swap.Left = 680;
            swap.Top = 250;
            swap.Name = "swap";
            swap.Width = 70;
            swap.Height = 30;
            swap.Font = new Font("Consolas", 10, FontStyle.Regular);
            swap.TextAlign = ContentAlignment.MiddleCenter;
            swap.Visible = true;
            Controls.Add(swap);
            swap.Click += new System.EventHandler(interschimbare);
            swap.BackColor = Color.ForestGreen;
            swap.ForeColor = Color.White;

            matrixA.Text = "MATRIX A";
            matrixA.Top = 150;
            matrixA.Left = 90;
            matrixA.Width = 150;
            matrixA.Name = "mA";
            matrixA.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            matrixA.BackColor = Color.Transparent;
            Controls.Add(matrixA);

            matrixB.Text = "MATRIX B";
            matrixB.Top = 150;
            matrixB.Left = 800;
            matrixB.Width = 150;
            matrixB.Name = "mB";
            matrixB.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            matrixB.BackColor = Color.Transparent;
            Controls.Add(matrixB);

            Controls.Add(clearHistory);
            clearHistory.Click += new System.EventHandler(clear_H);

            insBut.Click += new System.EventHandler(FromDisToMat);
            Controls.Add(From); Controls.Add(To); Controls.Add(insBut);
            Controls.Add(CB1); Controls.Add(CB2);

            To.Items.Add("MATRIX A");
            To.Items.Add("MATRIX B");

            for (int i = 0; i < 10; i++)
            {
                prmtL[i] = new Label()
                {
                    Top = 807 + (i - 1) * 43,
                    Left = 470,
                    Name = "prmatL" + i.ToString(),
                    Width = 60,
                    Height = 25,
                    Text = "X =",
                    Font = new Font("Consolas", 12, FontStyle.Regular),
                    Enabled = true,
                    Visible = true,
                    BackColor = Color.Transparent,
                };
                Controls.Add(prmtL[i]);

                prmtTB[i] = new TextBox()
                {
                    Top = 800 + (i - 1) * 43,
                    Left = 530,
                    Name = "prmatTB" + i.ToString(),
                    Width = 100,
                    Height = 40,
                    Text = "",
                    Font = new Font("Consolas", 12, FontStyle.Regular),
                    TextAlign = HorizontalAlignment.Center,
                    Enabled = true,
                    Visible = true,
                    Multiline = true,
                };
                Controls.Add(prmtTB[i]);
            }

            Controls.Add(nrRez);

            solve.Click += new System.EventHandler(solve_alter);
            Controls.Add(solve);

            Controls.Add(powerA); Controls.Add(powertbA);
            Controls.Add(powerB); Controls.Add(powertbB);

            powerA.Click += new System.EventHandler(apasa_power);
            powerB.Click += new System.EventHandler(apasa_power);

            Controls.Add(display);
            display.Text = newLine + display.Text;

            liniiA = new Label()
            {
                Text = "ROWS",
                Top = 500,
                Left = 90,
                Width = 60,
                Name = "liniiA",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            Controls.Add(liniiA);

            coloaneA = new Label()
            {
                Text = "COLUMNS",
                Top = 500,
                Left = 260,
                Width = 100,
                Name = "coloaneA",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            Controls.Add(coloaneA);

            multiply = new Button()
            {
                Text = "A * B",
                Name = "multiply",
                Left = 680,
                Top = 300,
                Width = 70,
                Height = 30,
                Font = new Font("Consolas", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(multiply);
            multiply.Click += new System.EventHandler(inmultire);

            add = new Button()
            {
                Text = "A + B",
                Name = "add",
                Left = 680,
                Top = 350,
                Width = 70,
                Height = 30,
                Font = new Font("Consolas", 10, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(add);
            add.Click += new System.EventHandler(adunare);

            down.Text = "";
            down.Top = 1820;
            down.Left = 2;
            down.Name = "down";
            down.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            down.BackColor = Color.Transparent;
            Controls.Add(down);

            dA.Top = 550;
            dA.Left = 90;
            dA.Text = "DETERMINANT";
            dA.Name = "detbA";
            dA.Width = 175;
            dA.Height = 50;
            dA.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            dA.Visible = true;
            Controls.Add(dA);
            dA.Click += new System.EventHandler(apasa_d);
            dA.BackColor = Color.ForestGreen;
            dA.ForeColor = Color.White;

            dB.Top = 550;
            dB.Left = 800;
            dB.Text = "DETERMINANT";
            dB.Name = "detbB";
            dB.Width = 175;
            dB.Height = 50;
            dB.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            dB.Visible = true;
            Controls.Add(dB);
            dB.Click += new System.EventHandler(apasa_d);
            dB.BackColor = Color.ForestGreen;
            dB.ForeColor = Color.White;

            inveA.Top = 550;
            inveA.Left = 265;
            inveA.Text = "INVERSE";
            inveA.Name = "invbA";
            inveA.Width = 175;
            inveA.Height = 50;
            inveA.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            inveA.Visible = true;
            Controls.Add(inveA);
            inveA.Click += new System.EventHandler(apasa_inve);
            inveA.BackColor = Color.ForestGreen;
            inveA.ForeColor = Color.White;

            inveB.Top = 550;
            inveB.Left = 975;
            inveB.Text = "INVERSE";
            inveB.Name = "invbB";
            inveB.Width = 175;
            inveB.Height = 50;
            inveB.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            inveB.Visible = true;
            Controls.Add(inveB);
            inveB.Click += new System.EventHandler(apasa_inve);
            inveB.BackColor = Color.ForestGreen;
            inveB.ForeColor = Color.White;

            transA = new Button()
            {
                Top = 600,
                Left = 315,
                Width = 125,
                Height = 50,
                Name = "transA",
                Text = "TRANSPOSE",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(transA);
            transA.Click += new System.EventHandler(apasa_trans);

            transB = new Button()
            {
                Top = 600,
                Left = 1025,
                Width = 125,
                Height = 50,
                Name = "transB",
                Text = "TRANSPOSE",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(transB);
            transB.Click += new System.EventHandler(apasa_trans);

            esalonA = new Button()
            {
                Top = 650,
                Left = 90,
                Width = 350,
                Height = 50,
                Name = "esalonA",
                Text = "ROW ECHELON FORM",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(esalonA);
            esalonA.Click += new System.EventHandler(apasa_esalon);

            esalonB = new Button()
            {
                Top = 650,
                Left = 800,
                Width = 350,
                Height = 50,
                Name = "esalonB",
                Text = "ROW ECHELON FORM",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(esalonB);
            esalonB.Click += new System.EventHandler(apasa_esalon);

            luA = new Button()
            {
                Top = 700,
                Left = 90,
                Width = 350,
                Height = 50,
                Name = "luA",
                Text = "LOWER-UPPER DECOMPOSITION",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(luA);
            luA.Click += new System.EventHandler(apasa_LU);

            luB = new Button()
            {
                Top = 700,
                Left = 800,
                Width = 350,
                Height = 50,
                Name = "luB",
                Text = "LOWER-UPPER DECOMPOSITION",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(luB);
            luB.Click += new System.EventHandler(apasa_LU);

            multibyA = new Button()
            {
                Top = 750,
                Left = 90,
                Width = 250,
                Height = 50,
                Name = "multibyA",
                Text = "MULTIPLY BY",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(multibyA);
            multibyA.Click += new System.EventHandler(apasa_multiplyby);
            mulA = new TextBox()
            {
                Top = 750,
                Left = 340,
                Width = 100,
                Height = 50,
                Name = "mulA",
                Text = "",
                Font = new Font("Consolas", 12, FontStyle.Regular),
                Visible = true,
                Enabled = true,
                Multiline = true,
                TextAlign = HorizontalAlignment.Center,
            };
            Controls.Add(mulA);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    vA[i, j] = new TextBox();

                    if (i == 0) vA[i, j].Top = 185;
                    else vA[i, j].Top = vA[i - 1, j].Top + 45;
                    if (j == 0) vA[i, j].Left = 90;
                    else vA[i, j].Left = vA[i, j - 1].Left + 95;
                    vA[i, j].Text = "";
                    vA[i, j].Name = "button_" + i.ToString();
                    vA[i, j].Height = 40;
                    vA[i, j].Width = 90;
                    vA[i, j].Font = new Font("Consolas", 12, FontStyle.Regular);
                    vA[i, j].TextAlign = HorizontalAlignment.Center;
                    vA[i, j].Enabled = true;
                    vA[i, j].Visible = true;
                    vA[i, j].Multiline = true;
                    Controls.Add(vA[i, j]);
                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    vB[i, j] = new TextBox();

                    if (i == 0) vB[i, j].Top = 185;
                    else vB[i, j].Top = vB[i - 1, j].Top + 45;
                    if (j == 0) vB[i, j].Left = 800;
                    else vB[i, j].Left = vB[i, j - 1].Left + 95;
                    vB[i, j].Text = "";
                    vB[i, j].Name = "";
                    vB[i, j].Height = 40;
                    vB[i, j].Width = 90;
                    vB[i, j].Font = new Font("Consolas", 12, FontStyle.Regular);
                    vB[i, j].TextAlign = HorizontalAlignment.Center;
                    vB[i, j].Enabled = true;
                    vB[i, j].Visible = true;
                    vB[i, j].Multiline = true;
                    Controls.Add(vB[i, j]);
                }
            }

            /*--------Matricea A---------*/

            adjA = new Button()
            {
                Top = 600,
                Left = 90,
                Width = 125,
                Height = 50,
                Name = "adjA",
                Text = "ADJUGATE",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(adjA);
            adjA.Click += new System.EventHandler(apasa_adj);

            clearA = new Button()
            {
                Top = 900,
                Left = 290,
                Height = 50,
                Width = 150,
                Name = "clearA",
                Text = "CLEAR",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(clearA);
            clearA.Click += new System.EventHandler(clear_matrix);

            te0A = new Button()
            {
                Top = 850,
                Left = 90,
                Height = 50,
                Width = 200,
                Name = "te0A",
                Text = "ALL ELEMENTS 0",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(te0A);
            te0A.Click += new System.EventHandler(all_0);

            te1A = new Button()
            {
                Top = 900,
                Left = 90,
                Height = 50,
                Width = 200,
                Name = "te1A",
                Text = "ALL ELEMENTS 1",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(te1A);
            te1A.Click += new System.EventHandler(all_1);

            clA.Top = 500;
            clA.Left = 190;
            clA.Text = "+";
            clA.Name = "clA";
            clA.Height = 40;
            clA.Width = 40;
            clA.Font = new Font("Consolas", 16, FontStyle.Regular);
            clA.Visible = true;
            Controls.Add(clA);
            clA.Click += new System.EventHandler(apasa_cl);
            clA.BackColor = Color.ForestGreen;
            clA.ForeColor = Color.White;

            ccA.Top = 500;
            ccA.Left = 400;
            ccA.Text = "+";
            ccA.Name = "ccA";
            ccA.Height = 40;
            ccA.Width = 40;
            ccA.Font = new Font("Consolas", 16, FontStyle.Regular);
            ccA.Visible = true;
            Controls.Add(ccA);
            ccA.Click += new System.EventHandler(apasa_cc);
            ccA.BackColor = Color.ForestGreen;
            ccA.ForeColor = Color.White;

            slA.Top = 500;
            slA.Left = 150;
            slA.Text = "-";
            slA.Name = "slA";
            slA.Height = 40;
            slA.Width = 40;
            slA.Font = new Font("Consolas", 16, FontStyle.Regular);
            slA.Visible = true;
            Controls.Add(slA);
            slA.Click += new System.EventHandler(apasa_sl);
            slA.BackColor = Color.ForestGreen;
            slA.ForeColor = Color.White;

            scA.Top = 500;
            scA.Left = 360;
            scA.Text = "-";
            scA.Name = "scA";
            scA.Height = 40;
            scA.Width = 40;
            scA.Font = new Font("Consolas", 16, FontStyle.Regular);
            scA.Visible = true;
            Controls.Add(scA);
            scA.Click += new System.EventHandler(apasa_sc);
            scA.BackColor = Color.ForestGreen;
            scA.ForeColor = Color.White;

            /*--------Matricea A--------*/




            /*--------Matricea B--------*/

            multibyB = new Button()
            {
                Top = 750,
                Left = 800,
                Width = 250,
                Height = 50,
                Name = "multibyB",
                Text = "MULTIPLY BY",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(multibyB);
            multibyB.Click += new System.EventHandler(apasa_multiplyby);
            mulB = new TextBox()
            {
                Top = 750,
                Left = 1050,
                Width = 100,
                Height = 50,
                Name = "mulB",
                Text = "",
                Font = new Font("Consolas", 12, FontStyle.Regular),
                Visible = true,
                Enabled = true,
                Multiline = true,
                TextAlign = HorizontalAlignment.Center,
            };
            Controls.Add(mulB);

            adjB = new Button()
            {
                Top = 600,
                Left = 800,
                Width = 125,
                Height = 50,
                Name = "adjB",
                Text = "ADJUGATE",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(adjB);
            adjB.Click += new System.EventHandler(apasa_adj);

            liniiB = new Label()
            {
                Text = "ROWS",
                Top = 500,
                Left = liniiA.Left + 710,
                Width = 60,
                Name = "liniiB",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            Controls.Add(liniiB);

            coloaneB = new Label()
            {
                Text = "COLUMNS",
                Top = 500,
                Left = coloaneA.Left + 710,
                Width = 100,
                Name = "coloaneB",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                BackColor = Color.Transparent,
            };
            Controls.Add(coloaneB);

            clB.Top = 500;
            clB.Left = 900;
            clB.Text = "+";
            clB.Name = "clB";
            clB.Height = 40;
            clB.Width = 40;
            clB.Font = new Font("Consolas", 16, FontStyle.Regular);
            clB.Visible = true;
            Controls.Add(clB);
            clB.Click += new System.EventHandler(apasa_cl);
            clB.BackColor = Color.ForestGreen;
            clB.ForeColor = Color.White;

            ccB.Top = 500;
            ccB.Left = ccA.Left + 710;
            ccB.Text = "+";
            ccB.Name = "ccB";
            ccB.Height = 40;
            ccB.Width = 40;
            ccB.Font = new Font("Consolas", 16, FontStyle.Regular);
            ccB.Visible = true;
            Controls.Add(ccB);
            ccB.Click += new System.EventHandler(apasa_cc);
            ccB.BackColor = Color.ForestGreen;
            ccB.ForeColor = Color.White;

            slB.Top = 500;
            slB.Left = 860;
            slB.Text = "-";
            slB.Name = "slB";
            slB.Height = 40;
            slB.Width = 40;
            slB.Font = new Font("Consolas", 16, FontStyle.Regular);
            slB.Visible = true;
            Controls.Add(slB);
            slB.Click += new System.EventHandler(apasa_sl);
            slB.BackColor = Color.ForestGreen;
            slB.ForeColor = Color.White;

            scB.Top = 500;
            scB.Left = scA.Left + 710;
            scB.Text = "-";
            scB.Name = "scB";
            scB.Height = 40;
            scB.Width = 40;
            scB.Font = new Font("Consolas", 16, FontStyle.Regular);
            scB.Visible = true;
            Controls.Add(scB);
            scB.Click += new System.EventHandler(apasa_sc);
            scB.BackColor = Color.ForestGreen;
            scB.ForeColor = Color.White;

            clearB = new Button()
            {
                Top = 900,
                Left = 1000,
                Height = 50,
                Width = 150,
                Name = "clearB",
                Text = "CLEAR",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(clearB);
            clearB.Click += new System.EventHandler(clear_matrix);

            te0B = new Button()
            {
                Top = 850,
                Left = 800,
                Height = 50,
                Width = 200,
                Name = "te0B",
                Text = "ALL ELEMENTS 0",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(te0B);
            te0B.Click += new System.EventHandler(all_0);

            te1B = new Button()
            {
                Top = 900,
                Left = 800,
                Height = 50,
                Width = 200,
                Name = "te1B",
                Text = "ALL ELEMENTS 1",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Enabled = true,
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(te1B);
            te1B.Click += new System.EventHandler(all_1);

            /*--------Matricea B--------*/

            rankA = new Button()
            {
                Top = 600,
                Left = 215,
                Width = 100,
                Height = 50,
                Name = "rankA",
                Text = "RANK",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(rankA);
            rankA.Click += new System.EventHandler(apasa_rank);

            rankB = new Button()
            {
                Top = 600,
                Left = 925,
                Width = 100,
                Height = 50,
                Name = "rankB",
                Text = "RANK",
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(rankB);
            rankB.Click += new System.EventHandler(apasa_rank);

            randA.Top = 850;
            randA.Left = 290;
            randA.Text = "RANDOM";
            randA.Name = "randA";
            randA.Height = 50;
            randA.Width = 150;
            randA.Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold);
            randA.Visible = true;
            Controls.Add(randA);
            randA.Click += new System.EventHandler(apasa_rand);
            randA.BackColor = Color.ForestGreen;
            randA.ForeColor = Color.White;

            randB = new Button()
            {
                Top = 850,
                Left = 1000,
                Text = "RANDOM",
                Name = "randB",
                Height = 50,
                Width = 150,
                Font = new Font("Bahnschrift SemiBold", 10, FontStyle.Bold),
                Visible = true,
                Enabled = true,
                BackColor = Color.ForestGreen,
                ForeColor = Color.White,
            };
            Controls.Add(randB);
            randB.Click += new System.EventHandler(apasa_rand);

            alternatives.SelectedIndexChanged += new System.EventHandler(apasa_alt);

            RemRez.Enabled = false;
            clearHistory.Enabled = false;
            Controls.Add(RemRez);
            RemRez.Click += new System.EventHandler(RemovePage);
        }

        private void RemovePage(object sender, EventArgs e)
        {
            if (rezultateRO.urm == null)
            {
                if (rezultateRO.ant == null)
                {
                    rezultateRO = null;
                    rezultateUK = null;
                }
                else
                {
                    rezultateRO = rezultateRO.ant;
                    rezultateUK = rezultateUK.ant;
                    rezultateRO.urm = null;
                    rezultateUK.urm = null;
                }
            }
            else
            {
                long i = rezultateRO.ord;
                nod p = new nod();
                nod q = new nod();

                p = rezultateRO.ant;
                q = rezultateRO.urm;
                q.ant = null;

                while (q != null)
                {
                    q.ord = i;
                    i++;
                    if (q.urm == null) break;
                    q = q.urm;
                }
                while (q.ant != null) q = q.ant;

                if (p != null) p.urm = q;
                q.ant = p;
                rezultateRO = q;

                i = rezultateUK.ord;
                p = rezultateUK.ant;
                q = rezultateUK.urm;
                q.ant = null;

                while (q != null)
                {
                    q.ord = i;
                    i++;
                    if (q.urm == null) break;
                    q = q.urm;
                }
                while (q.ant != null) q = q.ant;

                if (p != null) p.urm = q;
                q.ant = p;
                rezultateUK = q;


            }
            numRez--;
            if (numRez == 0)
            {
                clearHistory.Enabled = false;
                RemRez.Enabled = false;
            }

            From.Items.Clear();
            if (rezultateRO != null)
            {
                if (rezultateRO.ant == null) prev.Enabled = false;
                if (rezultateRO.urm == null) next.Enabled = false;

                for (int i = 0; i < rezultateRO.numMat; i++)
                    From.Items.Add(rezultateRO.rezults[i].text);

                if (sem == "RO")
                {
                    display.Text = rezultateRO.afisare;
                    nrRez.Text = " pagina " + rezultateRO.ord.ToString() + " din " + numRez.ToString();
                }
                else
                {
                    display.Text = rezultateUK.afisare;
                    nrRez.Text = " page " + rezultateUK.ord.ToString() + " of " + numRez.ToString();
                }
            }
            else
            {
                prev.Enabled = false;
                next.Enabled = false;
                nrRez.Text = "";
                if (sem == "RO") display.Text = newLine + " Rezultatele operatiilor tale vor fi afisate aici.";
                else display.Text = newLine + " The results of your operations will be displayed right here.";
            }
        }

        private string[] copyStringVec(int nrelem, string[] m)
        {
            string[] cpy = new string[100];
            for (int i = 0; i < nrelem; i++) cpy[i] = m[i];
            return cpy;
        }

        private void rom(object sender, EventArgs e)
        {
            sem = "RO";
            RO.Text = "ROMANA";
            UK.Text = "ENGLEZA";
            liniiA.Text = liniiB.Text = "LINII";
            coloaneA.Text = coloaneB.Text = "COLOANE";
            inveA.Text = inveB.Text = "INVERSA";
            adjA.Text = adjB.Text = "ADJUNCTA";
            rankA.Text = rankB.Text = "RANG";
            transA.Text = transB.Text = "TRANSPUSA";
            esalonA.Text = esalonB.Text = "FORMA TRIUNGHIULARA";
            luA.Text = luB.Text = "DESCOMPUNEREA LOWER-UPPER";
            multibyA.Text = multibyB.Text = "INMULTESTE CU";
            powerA.Text = powerB.Text = "RIDICA LA PUTEREA";
            te0A.Text = te0B.Text = "TOATE ELEMENTELE 0";
            te1A.Text = te1B.Text = "TOATE ELEMENTELE 1";
            randA.Text = randB.Text = "RANDOMIZARE";
            clearA.Text = clearB.Text = "CURATARE";
            solve.Text = "REZOLVA";
            matrixA.Text = "MATRICEA A";
            matrixB.Text = "MATRICEA B";
            prev.Text = "ANTERIOR";
            next.Text = "URMATOR";
            clearHistory.Text = "STERGERE ISTORIC";
            CB1.Text = "INSEREAZA";
            CB2.Text = "IN";
            RemRez.Text = "STERGERE PAGINA";

            To.Items.Clear();
            To.Items.Add("MATRICEA A");
            To.Items.Add("MATRICEA B");

            if (rezultateRO == null)
                display.Text = newLine + " Rezultatele operatiilor tale vor fi afisate aici.";
            else
            {
                display.Text = rezultateRO.afisare;
                nrRez.Text = " pagina " + rezultateRO.ord.ToString() + " din " + numRez.ToString();
            }
        }

        private void eng(object sender, EventArgs e)
        {
            sem = "UK";
            RO.Text = "ROMANIAN";
            UK.Text = "ENGLISH";
            liniiA.Text = liniiB.Text = "ROWS";
            coloaneA.Text = coloaneB.Text = "COLUMNS";
            inveA.Text = inveB.Text = "INVERSE";
            adjA.Text = adjB.Text = "ADJUGATE";
            rankA.Text = rankB.Text = "RANK";
            transA.Text = transB.Text = "TRANSPOSE";
            esalonA.Text = esalonB.Text = "ROW ECHELON FORM";
            luA.Text = luB.Text = "LOWER-UPPER DECOMPOSITION";
            multibyA.Text = multibyB.Text = "MULTIPLY BY";
            powerA.Text = powerB.Text = "RAISE TO THE POWER OF";
            te0A.Text = te0B.Text = "ALL ELEMENTS 0";
            te1A.Text = te1B.Text = "ALL ELEMENTS 1";
            randA.Text = randB.Text = "RANDOM";
            clearA.Text = clearB.Text = "CLEAR";
            solve.Text = "SOLVE";
            matrixA.Text = "MATRIX A";
            matrixB.Text = "MATRIX B";
            prev.Text = "PREVIOUS";
            next.Text = "NEXT";
            clearHistory.Text = "CLEAR HISTORY";
            CB1.Text = "INSERT";
            CB2.Text = "TO";
            RemRez.Text = "REMOVE PAGE";

            To.Items.Clear();
            To.Items.Add("MATRIX A");
            To.Items.Add("MATRIX B");

            if (rezultateUK == null)
                display.Text = newLine + " The results of your operations will be displayed right here.";
            else
            {
                display.Text = rezultateUK.afisare;
                nrRez.Text = " page " + rezultateUK.ord.ToString() + " of " + numRez.ToString();
            }
        }

        private void ToRez(ref nod rezultate, Matrix[] mats, int nrmats, string dp)
        {
            if (rezultate != null)
            {
                while (rezultate.urm != null) rezultate = rezultate.urm;
                nod p = new nod();
                p.afisare = dp;
                p.ord = numRez + 1;
                p.rezults = mats;
                p.numMat = nrmats;
                if (sem == "RO") nrRez.Text = " pagina " + p.ord.ToString() + " din " + p.ord.ToString();
                else nrRez.Text = " page " + p.ord.ToString() + " of " + p.ord.ToString();
                p.ant = rezultate;
                p.urm = null;
                rezultate.urm = p;
                rezultate = rezultate.urm;
                prev.Enabled = true;

                From.Items.Clear();
                for (int i = 0; i < rezultate.numMat; i++) From.Items.Add(rezultate.rezults[i].text);
            }
            else
            {
                nod p = new nod();
                p.afisare = dp;
                p.ord = numRez + 1;
                p.rezults = mats;
                p.numMat = nrmats;
                if (sem == "RO") nrRez.Text = " pagina " + p.ord.ToString() + " din " + p.ord.ToString();
                else nrRez.Text = " page " + p.ord.ToString() + " of " + p.ord.ToString();
                p.ant = null;
                p.urm = null;
                rezultate = p;

                From.Items.Clear();
                for (int i = 0; i < rezultate.numMat; i++) From.Items.Add(rezultate.rezults[i].text);
            }
        }

        private void MB(string warn)
        {
            if (sem == "RO") MessageBox.Show(warn, "ATENTIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show(warn, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void clear_H(object sender, EventArgs e)
        {
            rezultateRO = rezultateUK = null;
            if (sem == "UK") display.Text = newLine + " The results of your operations will be displayed right here.";
            else display.Text = newLine + " Rezultatele operatiile tale vor fi afisate aici.";
            prev.Enabled = false;
            next.Enabled = false;
            From.Items.Clear();
            numRez = 0;
            nrRez.Text = "";
            clearHistory.Enabled = false;
            RemRez.Enabled = false;
        }

        private void FromDisToMat(object sender, EventArgs e)
        {
            int i = 0;
            while (i < rezultateRO.numMat)
            {
                if (rezultateRO.rezults[i].text == From.Text) break;
                i++;
            }

            if (i == rezultateRO.numMat) return;
            else
            {
                string[,] m = new string[10, 10];
                int lin, col;
                lin = rezultateRO.rezults[i].linii;
                col = rezultateRO.rezults[i].coloane;
                m = FromDoubToStr(rezultateRO.rezults[i].M, lin, col);
                if (To.Text == "MATRIX A" || To.Text == "MATRICEA A")
                {
                    lA = lin; cA = col;
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (j < lin && k < col)
                            {
                                vA[j, k].Visible = true;
                                vA[j, k].Text = m[j, k];
                            }
                            else
                            {
                                vA[j, k].Visible = false;
                                vA[j, k].Text = "";
                            }
                        }
                    }
                }
                if (To.Text == "MATRIX B" || To.Text == "MATRICEA B")
                {
                    lB = lin; cB = col;
                    for (int j = 0; j < 6; j++)
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (j < lin && k < col)
                            {
                                vB[j, k].Visible = true;
                                vB[j, k].Text = m[j, k];
                            }
                            else
                            {
                                vB[j, k].Visible = false;
                                vB[j, k].Text = "";
                            }
                        }
                    }
                }
            }
        }

        private double[,] adjuncta(int dim, double[,] mat)
        {
            double[,] tm = new double[100, 100];
            double[,] invm = new double[100, 100];
            int p = 1;
            tm = transpose(dim, dim, mat);
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    double[,] mp = new double[100, 100];
                    mp = eliminare(dim, tm, i, j);
                    double det = new double();
                    det = determinant(dim - 1, mp);
                    if ((i + j) % 2 == 0) p = 1;
                    else p = -1;
                    invm[i, j] = det * p;
                }
            }
            return invm;
        }

        private void all_0(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "te0A")
            {
                for (int i = 0; i < lA; i++)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        vA[i, j].Text = "0";
                    }
                }
            }
            if (but.Name == "te0B")
            {
                for (int i = 0; i < lB; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        vB[i, j].Text = "0";
                    }
                }
            }
        }

        private void all_1(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "te1A")
            {
                for (int i = 0; i < lA; i++)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        vA[i, j].Text = "1";
                    }
                }
            }
            if (but.Name == "te1B")
            {
                for (int i = 0; i < lB; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        vB[i, j].Text = "1";
                    }
                }
            }
        }

        private void clear_matrix(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "clearA")
            {
                for (int i = 0; i < lA; i++)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        vA[i, j].Text = "";
                    }
                }
            }
            if (but.Name == "clearB")
            {
                for (int i = 0; i < lB; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        vB[i, j].Text = "";
                    }
                }
            }
        }

        private void apasa_alt(object sender, EventArgs e)
        {
            prmtL[0].Visible = prmtTB[0].Visible = false;
            prmtL[1].Visible = prmtTB[1].Visible = false;
            prmtL[2].Visible = prmtTB[2].Visible = false;
            prmtL[3].Visible = prmtTB[3].Visible = false;
            prmtL[0].Text = prmtL[1].Text = prmtL[2].Text = prmtL[3].Text = "";
            prmtTB[0].Text = prmtTB[1].Text = prmtTB[2].Text = prmtTB[3].Text = "";

            if (alternatives.Text == "x * A + y * B")
            {
                prmtL[0].Visible = prmtTB[0].Visible = true;
                prmtL[1].Visible = prmtTB[1].Visible = true;
                prmtL[0].Text = "x ="; prmtL[1].Text = "y =";
            }
            if (alternatives.Text == "x * A^n + y * B^m")
            {
                prmtL[0].Visible = prmtTB[0].Visible = true;
                prmtL[1].Visible = prmtTB[1].Visible = true;
                prmtL[2].Visible = prmtTB[2].Visible = true;
                prmtL[3].Visible = prmtTB[3].Visible = true;
                prmtL[0].Text = "x ="; prmtL[1].Text = "n =";
                prmtL[2].Text = "y ="; prmtL[3].Text = "m =";
            }
        }

        private void solve_alter(object sender, EventArgs e)
        {
            if (alternatives.Text == "A * X = B")
            {
                if (lA == lB)
                {
                    Matrix[] mats = new Matrix[6];
                    for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                    int nrmats = 0;
                    string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                    double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                    strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                    bool valid1, valid2;
                    valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                    if (valid1 == false || valid2 == false)
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                        else MB("Please fill out the matrixes with real numbers!");
                        return;
                    }

                    string[] dis = new string[20];
                    string[] disRO = new string[20];
                    string[] disUK = new string[20];
                    string displayRO = newLine, displayUK = newLine;
                    string piRO = "", piUK = "";
                    string[] nec = new string[100];
                    int nrNec = 0;
                    string pi = "";
                    display.Text = newLine;

                    matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);

                    for (int i = 0; i <= Max(lA, cA) * 2; i++)
                    {
                        if (i == Max(lA, cA)) dis[i] = dis[i] + " A = ";
                        else dis[i] = dis[i] + "     ";
                    }

                    if (lA < cA) addmatrix(ref dis, matA, lA, cA, cA - lA);
                    else addmatrix(ref dis, matA, lA, cA, 0);
                    mats[nrmats].M = matA;
                    mats[nrmats].linii = lA;
                    mats[nrmats].coloane = cA;
                    mats[nrmats].text = "A";
                    nrmats++;

                    for (int i = 0; i <= Max(lA, cA) * 2; i++)
                    {
                        if (i == Max(lA, cA)) dis[i] = dis[i] + ", B = ";
                        else dis[i] = dis[i] + "      ";
                    }

                    if (lA < cA) addmatrix(ref dis, matB, lB, cB, cA - lA);
                    else addmatrix(ref dis, matB, lB, cB, 0);
                    mats[nrmats].M = matB;
                    mats[nrmats].linii = lB;
                    mats[nrmats].coloane = cB;
                    mats[nrmats].text = "B";
                    nrmats++;

                    for (int i = 0; i <= Max(lA, cA) * 2; i++)
                    {
                        if (i == Max(lA, cA)) dis[i] = dis[i] + ", A * X = B => ";
                        else dis[i] = dis[i] + "               ";
                    }

                    int OK = 1;
                    string[,] X = new string[cA, cB];
                    for (int j = 0; j < cB; j++)
                    {
                        double[,] matColB = new double[lA, 1];
                        for (int i = 0; i < lA; i++) matColB[i, 0] = matB[i, j];

                        string[,] ColX = new string[cA, 1];
                        ColX = SolutionCol(lA, cA, matA, matColB, j, ref nec, ref nrNec);
                        if (ColX[0, 0] != " Ecuatia nu are nicio solutie. ")
                        {
                            X = ConcatStr(cA, j, X, 1, ColX);
                        }
                        else
                        {
                            OK = 0; break;
                        }

                    }

                    if (OK == 1)
                    {
                        for (int i = 0; i <= Max(lA, cA) * 2; i++)
                        {
                            if (i == Max(lA, cA)) dis[i] = dis[i] + "X = ";
                            else dis[i] = dis[i] + "    ";
                        }
                        if (lA < cA) addmatrixString(ref dis, X, cA, cB, 0);
                        else addmatrixString(ref dis, X, cA, cB, lA - cA);
                        if (verif_strings(X, cA, cB) == true)
                        {
                            mats[nrmats].M = ToDouble(X, cA, cB);
                            mats[nrmats].linii = cA;
                            mats[nrmats].coloane = cB;
                            mats[nrmats].text = "X";
                            nrmats++;
                        }
                        if (nrNec != 0)
                        {
                            if (nrNec != 1)
                            {
                                piRO = piRO + " unde elementele ";
                                piUK = piUK + " where the elements ";
                                for (int i = 0; i < nrNec; i++)
                                {
                                    if (i == nrNec - 1)
                                    {
                                        piRO = piRO + nec[i] + " pot ";
                                        piUK = piUK + nec[i] + " can ";
                                    }
                                    else
                                    {
                                        if (i == nrNec - 2)
                                        {
                                            piRO = piRO + nec[i] + " si ";
                                            piUK = piUK + nec[i] + " and ";
                                        }
                                        else
                                        {
                                            piRO = piRO + nec[i] + ", ";
                                            piUK = piUK + nec[i] + ", ";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                piRO = piRO + " unde elementul " + nec[0] + " poate ";
                                piUK = piUK + " where the element " + nec[0] + " can ";
                            }
                            piRO = piRO + "lua orice valoare din multimea numerelor reale";
                            piUK = piUK + "take any real number";
                        }
                        disRO = copyStringVec(Max(lA, cA) * 2 + 1, dis);
                        disUK = copyStringVec(Max(lA, cA) * 2 + 1, dis);
                    }
                    else
                    {
                        disRO = copyStringVec(Max(lA, cA) * 2 + 1, dis);
                        disUK = copyStringVec(Max(lA, cA) * 2 + 1, dis);
                        disRO[Max(lA, cA)] = disRO[Max(lA, cA)] + "nu exista solutii ";
                        disUK[Max(lA, cA)] = disUK[Max(lA, cA)] + "there's no solution ";
                    }

                    for (int i = 0; i <= Max(lA, cA) * 2; i++)
                    {
                        displayRO = displayRO + disRO[i] + newLine;
                        displayUK = displayUK + disUK[i] + newLine;
                    }
                    displayRO = displayRO + newLine + piRO;
                    displayUK = displayUK + newLine + piUK;

                    if (sem == "RO") display.Text = displayRO;
                    else display.Text = displayUK;

                    ToRez(ref rezultateRO, mats, nrmats, displayRO);
                    ToRez(ref rezultateUK, mats, nrmats, displayUK);

                    clearHistory.Enabled = true;
                    RemRez.Enabled = true;
                    next.Enabled = false;
                    numRez++;
                }
                else
                {
                    if (sem == "RO") MB("Numarul de linii ale matricei A trebuie sa fie egal cu cel al matricei B.");
                    else MB("Matrixes A and B have to have same number of rows.");
                }
            }

            if (alternatives.Text == "X * A = B")
            {
                if (cA == cB)
                {
                    Matrix[] mats = new Matrix[6];
                    for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                    int nrmats = 0;
                    display.Text = newLine;
                    string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                    double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                    strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                    bool valid1, valid2;
                    valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                    if (valid1 == false || valid2 == false)
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                        else MB("Please fill out the matrixes with real numbers!");
                        return;
                    }

                    string[] dis = new string[20];
                    string[] disRO = new string[20];
                    string[] disUK = new string[20];
                    string[] nec = new string[100];
                    int nrNec = 0;
                    string piRO = "", piUK = "";
                    string displayRO = newLine, displayUK = newLine;

                    matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);

                    for (int i = 0; i <= Max(lA, lB) * 2; i++)
                    {
                        if (i == Max(lA, lB)) dis[i] = dis[i] + " A = ";
                        else dis[i] = dis[i] + "     ";
                    }

                    if (lA < lB) addmatrix(ref dis, matA, lA, cA, lB - lA);
                    else addmatrix(ref dis, matA, lA, cA, 0);
                    mats[nrmats].M = matA;
                    mats[nrmats].linii = lA;
                    mats[nrmats].coloane = cA;
                    mats[nrmats].text = "A";
                    nrmats++;

                    for (int i = 0; i <= Max(lA, lB) * 2; i++)
                    {
                        if (i == Max(lA, lB)) dis[i] = dis[i] + ", B = ";
                        else dis[i] = dis[i] + "      ";
                    }

                    if (lA < lB) addmatrix(ref dis, matB, lB, cB, 0);
                    else addmatrix(ref dis, matB, lB, cB, lA - lB);
                    mats[nrmats].M = matB;
                    mats[nrmats].linii = lB;
                    mats[nrmats].coloane = cB;
                    mats[nrmats].text = "B";
                    nrmats++;

                    for (int i = 0; i <= Max(lA, lB) * 2; i++)
                    {
                        if (i == Max(lA, lB)) dis[i] = dis[i] + ", X * A = B => ";
                        else dis[i] = dis[i] + "               ";
                    }

                    double[,] matTrA = new double[cA, lA];
                    double[,] matTrB = new double[cB, lB];
                    matTrA = transpose(lA, cA, matA); matTrB = transpose(lB, cB, matB);
                    int OK = 1;
                    string[,] X = new string[lB, lA];
                    string[,] TrX = new string[lA, lB];

                    for (int j = 0; j < lB; j++)
                    {
                        double[,] matColB = new double[cA, 1];
                        for (int i = 0; i < cA; i++) matColB[i, 0] = matTrB[i, j];

                        string[,] ColX = new string[lA, 1];
                        ColX = SolutionLin(cA, lA, matTrA, matColB, j, ref nec, ref nrNec);
                        if (ColX[0, 0] != " Ecuatia nu are nicio solutie. ")
                        {
                            TrX = ConcatStr(lA, j, TrX, 1, ColX);
                        }
                        else
                        {
                            OK = 0;
                            break;
                        }
                    }

                    if (OK == 1)
                    {
                        X = transposeString(lA, lB, TrX);
                        for (int i = 0; i <= Max(lA, lB) * 2; i++)
                        {
                            if (i == Max(lA, lB)) dis[i] = dis[i] + "X = ";
                            else dis[i] = dis[i] + "    ";
                        }
                        if (lA < lB) addmatrixString(ref dis, X, lB, lA, 0);
                        else addmatrixString(ref dis, X, lB, lA, lA - lB);
                        if (verif_strings(X, lB, lA) == true)
                        {
                            mats[nrmats].M = ToDouble(X, lB, lA);
                            mats[nrmats].linii = lB;
                            mats[nrmats].coloane = lA;
                            mats[nrmats].text = "X";
                            nrmats++;
                        }
                        if (nrNec != 0)
                        {
                            if (nrNec != 1)
                            {
                                piRO = piRO + " unde elementele ";
                                piUK = piUK + " where the elements ";
                                for (int i = 0; i < nrNec; i++)
                                {
                                    if (i == nrNec - 1)
                                    {
                                        piRO = piRO + nec[i] + " pot ";
                                        piUK = piUK + nec[i] + " can ";
                                    }
                                    else
                                    {
                                        if (i == nrNec - 2)
                                        {
                                            piRO = piRO + nec[i] + " si ";
                                            piUK = piUK + nec[i] + " and ";
                                        }
                                        piRO = piRO + nec[i] + ", ";
                                        piUK = piUK + nec[i] + ", ";
                                    }
                                }
                            }
                            else
                            {
                                piRO = piRO + " unde elementul " + nec[0] + " poate ";
                                piUK = piUK + " where the element " + nec[0] + " can ";
                            }
                            piRO = piRO + "lua orice valoare din multimea numerelor reale";
                            piUK = piUK + "take any real number";
                        }
                        disRO = copyStringVec(Max(lA, lB) * 2 + 1, dis);
                        disUK = copyStringVec(Max(lA, lB) * 2 + 1, dis);
                    }
                    else
                    {
                        disRO = copyStringVec(Max(lA, lB) * 2 + 1, dis);
                        disUK = copyStringVec(Max(lA, lB) * 2 + 1, dis);
                        disRO[Max(lA, lB)] = disRO[Max(lA, lB)] + "nu exista solutii ";
                        disUK[Max(lA, lB)] = disUK[Max(lA, lB)] + "there's no solution ";
                    }

                    for (int i = 0; i <= Max(lA, lB) * 2; i++)
                    {
                        displayRO = displayRO + disRO[i] + newLine;
                        displayUK = displayUK + disUK[i] + newLine;
                    }
                    displayRO = displayRO + newLine + piRO;
                    displayUK = displayUK + newLine + piUK;

                    if (sem == "RO") display.Text = displayRO;
                    else display.Text = displayUK;

                    ToRez(ref rezultateRO, mats, nrmats, displayRO);
                    ToRez(ref rezultateUK, mats, nrmats, displayUK);

                    clearHistory.Enabled = true;
                    RemRez.Enabled = true;
                    next.Enabled = false;
                    numRez++;
                }
                else
                {
                    if (sem == "RO") MB("Numarul de coloane ale matricei A trebuie sa fie egal cu cel al matricei B.");
                    else MB("Matrixes A and B have to have same number of columns.");
                }
            }

            if (alternatives.Text == "x * A^n + y * B^m")
            {
                if (lA == cA && lB == cB && lA == lB)
                {
                    string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                    double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                    strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                    bool valid1, valid2;
                    valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                    if (valid1 == false || valid2 == false)
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                        else MB("Please fill out the matrixes with real numbers!");
                        return;
                    }
                    matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);

                    double x, n, y, m;
                    bool xBool, nBool, yBool, mBool;
                    xBool = double.TryParse(prmtTB[0].Text, out x);
                    nBool = double.TryParse(prmtTB[1].Text, out n);
                    yBool = double.TryParse(prmtTB[2].Text, out y);
                    mBool = double.TryParse(prmtTB[3].Text, out m);

                    if (xBool && yBool && nBool && mBool)
                    {
                        if (n == Math.Round(n, 0) && m == Math.Round(m, 0))
                        {
                            if ((n <= 0 && determinant(lA, matA) == 0) || (m <= 0 && determinant(lB, matB) == 0))
                            {
                                if (sem == "RO")
                                    MB("Matricile trebuie sa aiba determinantii diferiti de 0 pentru a putea fi ridicate la puteri negative sau egale cu 0.");
                                else
                                    MB("Both matrixes have to have determinants equal to 0 so that they can be raised to a less or equal to 0 power.");
                            }
                            else
                            {
                                Matrix[] mats = new Matrix[6];
                                for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                                int nrmats = 0;
                                string[] dis = new string[100];
                                string xStr, yStr, nStr, mStr;

                                if (x < 0) xStr = "(" + x.ToString() + ")";
                                else
                                {
                                    if (x == 0) xStr = "0";
                                    else xStr = x.ToString();
                                }
                                if (n < 0) nStr = "(" + n.ToString() + ")";
                                else
                                {
                                    if (n == 0) nStr = "0";
                                    else nStr = n.ToString();
                                }
                                if (y < 0) yStr = "(" + y.ToString() + ")";
                                else
                                {
                                    if (y == 0) yStr = "0";
                                    else yStr = y.ToString();
                                }
                                if (m < 0) mStr = "(" + m.ToString() + ")";
                                else
                                {
                                    if (m == 0) mStr = "0";
                                    else mStr = m.ToString();
                                }

                                for (int i = 0; i <= 2 * lA; i++)
                                {
                                    if (i == lA) dis[i] = dis[i] + " A = ";
                                    else dis[i] = dis[i] + "     ";
                                }
                                addmatrix(ref dis, matA, lA, cA, 0);
                                mats[nrmats].M = matA;
                                mats[nrmats].linii = lA;
                                mats[nrmats].coloane = cA;
                                mats[nrmats].text = "A";
                                nrmats++;
                                for (int i = 0; i <= 2 * lA; i++)
                                {
                                    if (i == lA) dis[i] = dis[i] + ", B = ";
                                    else dis[i] = dis[i] + "      ";
                                }
                                addmatrix(ref dis, matB, lB, cB, 0);
                                mats[nrmats].M = matB;
                                mats[nrmats].linii = lB;
                                mats[nrmats].coloane = cB;
                                mats[nrmats].text = "B";
                                nrmats++;
                                for (int i = 0; i <= 2 * lA; i++)
                                {
                                    if (i == lA) dis[i] = dis[i] + " => C = " + xStr + " * A^" + nStr + " + " + yStr + " * B^" + mStr + " = ";
                                    else for (int j = 0; j < 24 + xStr.Length + yStr.Length + nStr.Length + mStr.Length; j++) dis[i] = dis[i] + " ";
                                }

                                double[,] newA = new double[lA, lA];
                                double[,] newB = new double[lA, lA];
                                double[,] rez = new double[lA, lA];

                                newA = ToPower(lA, matA, n);
                                newB = ToPower(lA, matB, m);
                                newA = multiplyby(newA, lA, lA, x);
                                newB = multiplyby(newB, lA, lA, y);
                                rez = addition(lA, lA, newA, newB);

                                addmatrix(ref dis, rez, lA, lA, 0);
                                mats[nrmats].M = rez;
                                mats[nrmats].linii = lA;
                                mats[nrmats].coloane = cA;
                                mats[nrmats].text = "C";
                                nrmats++;

                                display.Text = "";
                                for (int i = 0; i <= 2 * lA + 2; i++)
                                {
                                    display.Text = display.Text + newLine + dis[i];
                                }

                                ToRez(ref rezultateRO, mats, nrmats, display.Text);
                                ToRez(ref rezultateUK, mats, nrmats, display.Text);

                                clearHistory.Enabled = true;
                                RemRez.Enabled = true;
                                next.Enabled = false;
                                numRez++;
                            }
                        }
                        else
                        {
                            if (sem == "RO") MB("Te rog introdu puteri intregi!");
                            else MB("Please fill out with whole powers!");
                        }
                    }
                    else
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale pentru x, n, y si m!");
                        else MB("Please fill out textboxes for x, n, y and m with real numbers!");
                    }
                }
                else
                {
                    if (sem == "RO") MB("Matricile A si B trebuie sa fie patrate si sa aiba dimensiuni egale.");
                    else MB("Both matrixes A and B have to be square and have the same sizes.");
                }
            }

            if (alternatives.Text == "x * A + y * B")
            {
                if (lA == lB && cA == cB)
                {
                    string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                    double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                    strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                    bool valid1, valid2;
                    valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                    if (valid1 == false || valid2 == false)
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                        else MB("Please fill out the matrixes with real numbers!");
                        return;
                    }
                    matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);

                    double x, y;
                    bool xBool, yBool;
                    xBool = double.TryParse(prmtTB[0].Text, out x);
                    yBool = double.TryParse(prmtTB[1].Text, out y);

                    if (xBool && yBool)
                    {
                        Matrix[] mats = new Matrix[6];
                        for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                        int nrmats = 0;
                        double[,] rez = new double[lA, cA];

                        string[] dis = new string[100];
                        string xStr, yStr;

                        if (x < 0) xStr = "(" + x.ToString() + ")";
                        else
                        {
                            if (x == 0) xStr = "0";
                            else xStr = x.ToString();
                        }
                        if (y < 0) yStr = "(" + y.ToString() + ")";
                        else
                        {
                            if (y == 0) yStr = "0";
                            else yStr = y.ToString();
                        }

                        for (int i = 0; i <= 2 * lA; i++)
                        {
                            if (i == lA) dis[i] = dis[i] + " A = ";
                            else dis[i] = dis[i] + "     ";
                        }
                        addmatrix(ref dis, matA, lA, cA, 0);
                        mats[nrmats].M = matA;
                        mats[nrmats].linii = lA;
                        mats[nrmats].coloane = cA;
                        mats[nrmats].text = "A";
                        nrmats++;
                        for (int i = 0; i <= 2 * lB; i++)
                        {
                            if (i == lB) dis[i] = dis[i] + ", B = ";
                            else dis[i] = dis[i] + "      ";
                        }
                        addmatrix(ref dis, matB, lB, cB, 0);
                        mats[nrmats].M = matB;
                        mats[nrmats].linii = lA;
                        mats[nrmats].coloane = cA;
                        mats[nrmats].text = "B";
                        nrmats++;
                        for (int i = 0; i <= 2 * lA; i++)
                        {
                            if (i == lA) dis[i] = dis[i] + " => C = " + xStr + " * A + " + yStr + " * B = ";
                            else for (int j = 0; j < xStr.Length + yStr.Length + 22; j++) dis[i] = dis[i] + " ";
                        }

                        matA = multiplyby(matA, lA, cA, x);
                        matB = multiplyby(matB, lB, cB, y);
                        rez = addition(lA, cA, matA, matB);
                        addmatrix(ref dis, rez, lA, cA, 0);
                        mats[nrmats].M = rez;
                        mats[nrmats].linii = lA;
                        mats[nrmats].coloane = cA;
                        mats[nrmats].text = "C";
                        nrmats++;

                        display.Text = newLine;
                        for (int i = 0; i <= 2 * lA; i++) display.Text = display.Text + dis[i] + newLine;

                        ToRez(ref rezultateRO, mats, nrmats, display.Text);
                        ToRez(ref rezultateUK, mats, nrmats, display.Text);

                        clearHistory.Enabled = true;
                        RemRez.Enabled = true;
                        next.Enabled = false;
                        numRez++;
                    }
                    else
                    {
                        if (sem == "RO") MB("Te rog introdu valori numere reale pentru x si y!");
                        else MB("Please fill out textboxes for x and y with real numbers!");
                    }
                }
                else
                {
                    if (sem == "RO") MB("Dimensiunile matricilor trebuie sa fie egale.");
                    else MB("Both matrixes A and B have to have the same size.");
                }
            }
        }

        private double[,] ToPower(int lin, double[,] x, double power)
        {
            double[,] newm = new double[lin, lin];
            if (power == 0)
            {
                for (int i = 0; i < lin; i++)
                {
                    for (int j = 0; j < lin; j++)
                    {
                        if (i == j) newm[i, j] = 1;
                        else newm[i, j] = 0;
                    }
                }
            }
            else
            {
                if (power < 0)
                {
                    double[,] inv = new double[lin, lin];
                    inv = inversa(lin, x);
                    newm = inv;
                    for (int i = 1; i < -power; i++) newm = multi(lin, lin, newm, lin, lin, inv);
                }
                else
                {
                    newm = x;
                    for (int i = 1; i < power; i++) newm = multi(lin, lin, newm, lin, lin, x);
                }
            }
            return newm;
        }

        private string[,] transposeString(int lin, int col, string[,] vtb)
        {
            string[,] trans = new string[col, lin];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    trans[j, i] = vtb[i, j];
                }
            }
            return trans;
        }

        private string[,] ConcatStr(int linA, int colA, string[,] a, int colB, string[,] b)
        {
            string[,] ab = new string[linA, colA + colB];
            for (int i = 0; i < linA; i++)
            {
                for (int j = 0; j < colA + colB; j++)
                {
                    if (j < colA) ab[i, j] = a[i, j];
                    else ab[i, j] = b[i, j - colA];
                }
            }
            return ab;
        }

        private double[,] ConcatDoub(int linA, int colA, double[,] a, int colB, double[,] b)
        {
            double[,] ab = new double[linA, colA + colB];
            for (int i = 0; i < linA; i++)
            {
                for (int j = 0; j < colA + colB; j++)
                {
                    if (j < colA) ab[i, j] = a[i, j];
                    else ab[i, j] = b[i, j - colA];
                }
            }
            return ab;
        }

        private string[,] SolutionLin(int linA, int colA, double[,] a, double[,] b, int linSol, ref string[] nec, ref int nrNec)
        {
            string[,] nonSol = new string[1, 1];
            nonSol[0, 0] = " Ecuatia nu are nicio solutie. ";
            string[,] Sol = new string[colA, 1];

            double[,] ab = new double[linA, colA + 1];
            ab = ConcatDoub(linA, colA, a, 1, b);

            double[,] P = new double[10, 10];
            double[,] L = new double[10, 10];
            double[,] U = new double[10, 10];
            esalon(linA, colA + 1, ab, ref P, ref L, ref U);

            int val = 0;
            for (int i = 0; i < linA; i++)
            {
                if (P[i, i] == 0)
                {
                    val = 1;
                    break;
                }
            }
            if (val == 1)
            {
                double[,] P1 = new double[10, 10];
                ab = multi(linA, linA, P, linA, colA + 1, ab);
                esalon(linA, colA + 1, ab, ref P1, ref L, ref U);
            }

            string[,] strU = new string[linA, colA + 1];
            strU = FromDoubToStr(U, linA, colA + 1);
            U = ToDouble(strU, linA, colA + 1);

            int linLim1 = 0, OK = 1;
            while (linLim1 < linA)
            {
                int okc = 1;
                for (int i = linLim1; i < colA; i++)
                {
                    if (U[linLim1, i] != 0)
                    {
                        okc = 0;
                        break;
                    }
                }
                if (okc == 0) linLim1++;
                else break;
            }

            if (linLim1 == linA) OK = 1;
            else
            {
                if (U[linLim1, colA] != 0) OK = 0;
            }

            if (OK == 0) return nonSol;
            else
            {
                for (int i = linLim1 - 1; i > 0; i--)
                {
                    int j = i;
                    while (U[i, j] == 0) j++;
                    for (int k1 = i - 1; k1 >= 0; k1--)
                    {
                        double r = U[k1, j] / U[i, j];
                        for (int k2 = 0; k2 <= colA; k2++)
                        {
                            U[k1, k2] = U[k1, k2] - r * U[i, k2];
                        }
                    }
                }

                int[] stay = new int[6]; int cardStay = 0;
                int[] move = new int[6]; int cardMove = 0;
                int d = 0;
                for (int i = 0; i < linLim1; i++)
                {
                    while (U[i, i + d] == 0) d++;
                    stay[cardStay] = i + d;
                    cardStay++;
                }
                for (int j = 0; j < colA; j++)
                {
                    int ok = 0;
                    for (int i = 0; i < cardStay; i++)
                    {
                        if (stay[i] == j) ok = 1;
                    }
                    if (ok == 0)
                    {
                        move[cardMove] = j;
                        cardMove++;
                    }
                }

                double[,] stayC = new double[linLim1, cardStay];
                double[,] moveC = new double[linLim1, cardMove + 1];

                for (int i = 0; i < linLim1; i++)
                {
                    for (int j = 0; j < cardStay; j++)
                    {
                        stayC[i, j] = U[i, stay[j]];
                    }
                }
                for (int i = 0; i < linLim1; i++)
                {
                    moveC[i, 0] = U[i, colA];
                    for (int j = 0; j < cardMove; j++)
                    {
                        moveC[i, j + 1] = -U[i, move[j]];
                    }
                }

                for (int i = 0; i < cardStay; i++)
                {
                    double z = moveC[i, 0] / stayC[i, i];
                    Sol[stay[i], 0] = Math.Round(z, 10).ToString();
                    for (int j = 0; j < cardMove; j++)
                    {
                        z = (moveC[i, j + 1] / stayC[i, i]);
                        if (Math.Round(z, 10) > 0)
                        {
                            if (Math.Round(z, 10) != 1)
                                Sol[stay[i], 0] = Sol[stay[i], 0] + " + " + Math.Round(z, 10).ToString() + " * x[" + (linSol + 1).ToString() + "," + (move[j] + 1).ToString() + "]";
                            else Sol[stay[i], 0] = Sol[stay[i], 0] + " + x[" + (linSol + 1).ToString() + "," + (move[j] + 1).ToString() + "]";
                        }
                        if (Math.Round(z, 10) < 0)
                        {
                            if (Math.Round(z, 10) != -1)
                                Sol[stay[i], 0] = Sol[stay[i], 0] + " - " + Math.Round(-z, 10).ToString() + " * x[" + (linSol + 1).ToString() + "," + (move[j] + 1).ToString() + "]";
                            else Sol[stay[i], 0] = Sol[stay[i], 0] + " - x[" + (linSol + 1).ToString() + "," + (move[j] + 1).ToString() + "]";
                        }
                    }
                    if (double.TryParse(Sol[stay[i], 0], out double n) == false)
                        Sol[stay[i], 0] = "(" + Sol[stay[i], 0] + ")";
                }
                for (int i = 0; i < cardMove; i++)
                {
                    Sol[move[i], 0] = "x[" + (linSol + 1).ToString() + "," + (move[i] + 1).ToString() + "]";
                    nec[nrNec] = Sol[move[i], 0];
                    nrNec++;
                }

                return Sol;
            }

        }

        private string[,] SolutionCol(int linA, int colA, double[,] a, double[,] b, int colSol, ref string[] nec, ref int nrNec)
        {
            string[,] nonSol = new string[1, 1];
            nonSol[0, 0] = " Ecuatia nu are nicio solutie. ";
            string[,] Sol = new string[colA, 1];

            double[,] ab = new double[linA, colA + 1];
            ab = ConcatDoub(linA, colA, a, 1, b);

            double[,] P = new double[10, 10];
            double[,] L = new double[10, 10];
            double[,] U = new double[10, 10];
            esalon(linA, colA + 1, ab, ref P, ref L, ref U);

            int val = 0;
            for (int i = 0; i < linA; i++)
            {
                if (P[i, i] == 0)
                {
                    val = 1;
                    break;
                }
            }
            if (val == 1)
            {
                double[,] P1 = new double[10, 10];
                ab = multi(linA, linA, P, linA, colA + 1, ab);
                esalon(linA, colA + 1, ab, ref P1, ref L, ref U);
            }

            string[,] strU = new string[linA, colA + 1];
            strU = FromDoubToStr(U, linA, colA + 1);
            U = ToDouble(strU, linA, colA + 1);

            int linLim1 = 0, OK = 1;
            while (linLim1 < linA)
            {
                int okc = 1;
                for (int i = linLim1; i < colA; i++)
                {
                    if (U[linLim1, i] != 0)
                    {
                        okc = 0;
                        break;
                    }
                }
                if (okc == 0) linLim1++;
                else break;
            }

            if (linLim1 == linA) OK = 1;
            else
            {
                if (U[linLim1, colA] != 0) OK = 0;
            }

            if (OK == 0) return nonSol;
            else
            {
                for (int i = linLim1 - 1; i > 0; i--)
                {
                    int j = i;
                    while (U[i, j] == 0) j++;
                    for (int k1 = i - 1; k1 >= 0; k1--)
                    {
                        double r = U[k1, j] / U[i, j];
                        for (int k2 = 0; k2 <= colA; k2++)
                        {
                            U[k1, k2] = U[k1, k2] - r * U[i, k2];
                        }
                    }
                }

                int[] stay = new int[6]; int cardStay = 0;
                int[] move = new int[6]; int cardMove = 0;
                int d = 0;
                for (int i = 0; i < linLim1; i++)
                {
                    while (U[i, i + d] == 0) d++;
                    stay[cardStay] = i + d;
                    cardStay++;
                }
                for (int j = 0; j < colA; j++)
                {
                    int ok = 0;
                    for (int i = 0; i < cardStay; i++)
                    {
                        if (stay[i] == j) ok = 1;
                    }
                    if (ok == 0)
                    {
                        move[cardMove] = j;
                        cardMove++;
                    }
                }

                double[,] stayC = new double[linLim1, cardStay];
                double[,] moveC = new double[linLim1, cardMove + 1];

                for (int i = 0; i < linLim1; i++)
                {
                    for (int j = 0; j < cardStay; j++)
                    {
                        stayC[i, j] = U[i, stay[j]];
                    }
                }
                for (int i = 0; i < linLim1; i++)
                {
                    moveC[i, 0] = U[i, colA];
                    for (int j = 0; j < cardMove; j++)
                    {
                        moveC[i, j + 1] = -U[i, move[j]];
                    }
                }

                for (int i = 0; i < cardStay; i++)
                {
                    double z = moveC[i, 0] / stayC[i, i];
                    Sol[stay[i], 0] = Math.Round(z, 10).ToString();
                    for (int j = 0; j < cardMove; j++)
                    {
                        z = (moveC[i, j + 1] / stayC[i, i]);
                        if (Math.Round(z, 10) > 0)
                        {
                            if (Math.Round(z, 10) != 1)
                                Sol[stay[i], 0] = Sol[stay[i], 0] + " + " + Math.Round(z, 10).ToString() + " * x[" + (move[j] + 1).ToString() + "," + (colSol + 1).ToString() + "]";
                            else Sol[stay[i], 0] = Sol[stay[i], 0] + " + x[" + (move[j] + 1).ToString() + "," + (colSol + 1).ToString() + "]";
                        }
                        if (Math.Round(z, 10) < 0)
                        {
                            if (Math.Round(z, 10) != -1)
                                Sol[stay[i], 0] = Sol[stay[i], 0] + " - " + Math.Round(-z, 10).ToString() + " * x[" + (move[j] + 1).ToString() + "," + (colSol + 1).ToString() + "]";
                            else Sol[stay[i], 0] = Sol[stay[i], 0] + " - x[" + (move[j] + 1).ToString() + "," + (colSol + 1).ToString() + "]";
                        }
                    }
                    if (double.TryParse(Sol[stay[i], 0], out double n) == false)
                        Sol[stay[i], 0] = "(" + Sol[stay[i], 0] + ")";
                }
                for (int i = 0; i < cardMove; i++)
                {
                    Sol[move[i], 0] = "x[" + (move[i] + 1).ToString() + "," + (colSol + 1).ToString() + "]";
                    nec[nrNec] = Sol[move[i], 0];
                    nrNec++;
                }

                return Sol;
            }

        }

        private void addmatrixString(ref string[] dis, string[,] vtb, int lin, int col, int dist)
        {
            int length = 0;
            int i = 0;

            for (i = 0; i < col; i++)
            {
                length = 0;
                for (int j = 0; j < lin; j++)
                {
                    if (vtb[j, i].Length > length)
                    {
                        length = vtb[j, i].Length;
                    }
                }
                length += 2;
                for (int j = 0; j < lin; j++)
                {
                    vtb[j, i] = vtb[j, i].PadLeft(length);
                }
            }

            i = 0;
            while (i < dist)
            {
                dis[i] = dis[i] + " ";
                for (int j = 0; j < col; j++)
                {
                    for (int k = 0; k < vtb[0, j].Length; k++)
                    {
                        dis[i] = dis[i] + " ";
                    }
                }
                dis[i] = dis[i] + "   ";
                i++;
            }
            while (i - dist <= 2 * lin)
            {
                if ((i - dist) % 2 == 1)
                {
                    dis[i] = dis[i] + "|";
                    for (int j = 0; j < col; j++)
                    {
                        dis[i] = dis[i] + vtb[(i - dist) / 2, j];
                    }
                    dis[i] = dis[i] + "  |";
                }
                else
                {
                    if (i - dist == 0) dis[i] = dis[i] + "/";
                    else
                    {
                        if (i - dist == 2 * lin) dis[i] = dis[i] + "\\";
                        else dis[i] = dis[i] + "|";
                    }
                    for (int j = 0; j < col; j++)
                    {
                        for (int k = 0; k < vtb[0, j].Length; k++)
                        {
                            dis[i] = dis[i] + " ";
                        }
                    }
                    if (i - dist == 0) dis[i] = dis[i] + "  \\";
                    else
                    {
                        if (i - dist == 2 * lin) dis[i] = dis[i] + "  /";
                        else dis[i] = dis[i] + "  |";
                    }
                }
                i++;
            }
            while (i - dist - 2 * lin - 1 < dist)
            {
                dis[i] = dis[i] + " ";
                for (int j = 0; j < col; j++)
                {
                    for (int k = 0; k < vtb[0, j].Length; k++)
                    {
                        dis[i] = dis[i] + " ";
                    }
                }
                dis[i] = dis[i] + "   ";
                i++;
            }
        }

        private void previous(object sender, EventArgs e)
        {
            rezultateRO = rezultateRO.ant;
            rezultateUK = rezultateUK.ant;

            if (sem == "RO") display.Text = rezultateRO.afisare;
            else display.Text = rezultateUK.afisare;

            if (sem == "RO") nrRez.Text = " pagina " + rezultateRO.ord.ToString() + " din " + numRez.ToString();
            else nrRez.Text = " page " + rezultateUK.ord.ToString() + " of " + numRez.ToString();

            next.Enabled = true;
            if (rezultateRO.ant == null) prev.Enabled = false;
            From.Items.Clear();
            for (int i = 0; i < rezultateRO.numMat; i++) From.Items.Add(rezultateRO.rezults[i].text);
        }

        private void urmatorul(object sender, EventArgs e)
        {
            rezultateRO = rezultateRO.urm;
            rezultateUK = rezultateUK.urm;

            if (sem == "RO") display.Text = rezultateRO.afisare;
            else display.Text = rezultateUK.afisare;

            if (sem == "RO") nrRez.Text = " pagina " + rezultateRO.ord.ToString() + " din " + numRez.ToString();
            else nrRez.Text = " page " + rezultateUK.ord.ToString() + " of " + numRez.ToString();

            prev.Enabled = true;
            if (rezultateRO.urm == null) next.Enabled = false;
            From.Items.Clear();
            for (int i = 0; i < rezultateRO.numMat; i++) From.Items.Add(rezultateRO.rezults[i].text);
        }

        private void apasa_cl(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "clA")
                if (lA < 6)
                {
                    lA++;
                    for (int j = 0; j < cA; j++) vA[lA - 1, j].Visible = true;
                    slA.Enabled = true;
                    if (lA == 6) clA.Enabled = false;
                }
            if (but.Name == "clB")
                if (lB < 6)
                {
                    lB++;
                    for (int j = 0; j < cB; j++) vB[lB - 1, j].Visible = true;
                    slB.Enabled = true;
                    if (lB == 6) clB.Enabled = false;
                }
        }

        private void apasa_sl(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "slA")
            {
                if (lA > 1)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        vA[lA - 1, j].Visible = false;
                        vA[lA - 1, j].Text = "";
                    }
                    lA--;
                    clA.Enabled = true;
                    if (lA == 1) slA.Enabled = false;
                }
            }
            if (but.Name == "slB")
            {
                if (lB > 1)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        vB[lB - 1, j].Visible = false;
                        vB[lB - 1, j].Text = "";
                    }
                    lB--;
                    clB.Enabled = true;
                    if (lB == 1) slB.Enabled = false;
                }
            }
        }

        private void apasa_cc(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "ccA")
                if (cA < 6)
                {
                    cA++;
                    for (int j = 0; j < lA; j++) vA[j, cA - 1].Visible = true;
                    scA.Enabled = true;
                    if (cA == 6) ccA.Enabled = false;
                }
            if (but.Name == "ccB")
                if (cB < 6)
                {
                    cB++;
                    for (int j = 0; j < lB; j++) vB[j, cB - 1].Visible = true;
                    scB.Enabled = true;
                    if (cB == 6) ccB.Enabled = false;
                }
        }

        private void apasa_sc(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Name == "scA")
                if (cA > 1)
                {
                    for (int j = 0; j < lA; j++)
                    {
                        vA[j, cA - 1].Visible = false;
                        vA[j, cA - 1].Text = "";
                    }
                    cA--;
                    ccA.Enabled = true;
                    if (cA == 1) scA.Enabled = false;
                }
            if (but.Name == "scB")
                if (cB > 1)
                {
                    for (int j = 0; j < lB; j++)
                    {
                        vB[j, cB - 1].Visible = false;
                        vB[j, cB - 1].Text = "";
                    }
                    cB--;
                    ccB.Enabled = true;
                    if (cB == 1) scB.Enabled = false;
                }
        }

        private bool whole_num(double[,] m, int lin, int col)
        {
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double z = Math.Round(m[i, j], 0);
                    if (m[i, j] != z) return false;
                }
            }
            return true;
        }

        private double[,] transpose(int lin, int col, double[,] m)
        {
            double[,] trans = new double[col, lin];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    trans[j, i] = m[i, j];
                }
            }
            return trans;
        }
        private void interschimbare(object sender, EventArgs e)
        {
            int cs, ls;
            bool[,] bo1 = new bool[100, 100];
            string[,] tb1 = new string[100, 100];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    bo1[i, j] = vA[i, j].Visible;
                    tb1[i, j] = vA[i, j].Text;
                }
            }
            bool[,] bo2 = new bool[100, 100];
            string[,] tb2 = new string[100, 100];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    bo2[i, j] = vB[i, j].Visible;
                    tb2[i, j] = vB[i, j].Text;
                }
            }
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    vA[i, j].Text = tb2[i, j];
                    vA[i, j].Visible = bo2[i, j];
                    vB[i, j].Text = tb1[i, j];
                    vB[i, j].Visible = bo1[i, j];
                }
            }
            cs = cA; cA = cB; cB = cs;
            ls = lA; lA = lB; lB = ls;

        }

        private double[,] addition(int lin, int col, double[,] a, double[,] b)
        {
            double[,] rez = new double[lin, col];
            for (int i = 0; i < lA; i++)
            {
                for (int j = 0; j < cA; j++)
                {
                    rez[i, j] = a[i, j] + b[i, j];
                }
            }
            return rez;
        }

        private void adunare(object sender, EventArgs e)
        {
            if (lA != lB || cA != cB)
            {
                if (sem == "RO") MB("Dimensiunile matricilor trebuie sa fie egale.");
                else MB("Both matrixes A and B have to have the same size.");
            }
            else
            {
                Matrix[] mats = new Matrix[6];
                for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                int nrmats = 0;
                string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                bool valid1, valid2;
                valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                if (valid1 == false || valid2 == false)
                {
                    if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                    else MB("Please fill out the matrixes with real number!");
                    return;
                }

                matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);
                double[,] rez = new double[lA, cA];

                rez = addition(lA, cA, matA, matB);

                string[] dis = new string[100];
                for (int i = 0; i <= lA * 2; i++)
                {
                    if (i == lA) dis[i] = dis[i] + " A = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matA, lA, cA, 0);
                mats[nrmats].M = matA;
                mats[nrmats].linii = lA;
                mats[nrmats].coloane = cA;
                mats[nrmats].text = "A";
                nrmats++;
                for (int i = 0; i <= 2 * lA; i++)
                {
                    if (i == lA) dis[i] = dis[i] + ", B = ";
                    else dis[i] = dis[i] + "      ";
                }
                addmatrix(ref dis, matB, lB, cB, 0);
                mats[nrmats].M = matB;
                mats[nrmats].linii = lB;
                mats[nrmats].coloane = cB;
                mats[nrmats].text = "B";
                nrmats++;
                for (int i = 0; i <= 2 * lA; i++)
                {
                    if (i == lA) dis[i] = dis[i] + " => C = A + B = ";
                    else dis[i] = dis[i] + "                ";
                }
                addmatrix(ref dis, rez, lA, cB, 0);
                mats[nrmats].M = rez;
                mats[nrmats].linii = lA;
                mats[nrmats].coloane = cA;
                mats[nrmats].text = "C";
                nrmats++;

                display.Text = "";
                for (int i = lA * 2; i >= 0; i--)
                {
                    display.Text = newLine + dis[i] + display.Text;
                }

                ToRez(ref rezultateRO, mats, nrmats, display.Text);
                ToRez(ref rezultateUK, mats, nrmats, display.Text);

                clearHistory.Enabled = true;
                RemRez.Enabled = true;
                next.Enabled = false;
                numRez++;
            }
        }
        private void inmultire(object sender, EventArgs e)
        {
            if (cA != lB)
            {
                if (sem == "RO") MB("Numarul coloanelor matricei A trebuie sa fie egal cu numarul liniilor matricei B.");
                else MB("The number of matrix A columns has to be equal to number of matrix B rows.");
            }
            else
            {
                Matrix[] mats = new Matrix[6];
                for (int i = 0; i < 6; i++) mats[i] = new Matrix();
                int nrmats = 0;
                string[,] strA = new string[lA, cA], strB = new string[lB, cB];
                double[,] matA = new double[lA, cA], matB = new double[lB, cB];
                strA = matrix(vA, lA, cA); strB = matrix(vB, lB, cB);
                bool valid1, valid2;
                valid1 = verif_strings(strA, lA, cA); valid2 = verif_strings(strB, lB, cB);
                if (valid1 == false || valid2 == false)
                {
                    if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                    else MB("Please fill out the matrixes with real number!");
                    return;
                }

                matA = ToDouble(strA, lA, cA); matB = ToDouble(strB, lB, cB);
                double[,] rez = new double[lA, cB];
                rez = multi(lA, cA, matA, lB, cB, matB);

                string[] dis = new string[100];
                for (int i = 0; i <= Max(lA, lB) * 2; i++)
                {
                    if (i == Max(lA, lB)) dis[i] = dis[i] + " A = ";
                    else dis[i] = dis[i] + "     ";
                }
                if (lA < lB) addmatrix(ref dis, matA, lA, cA, lB - lA);
                else addmatrix(ref dis, matA, lA, cA, 0);
                mats[nrmats].M = matA;
                mats[nrmats].linii = lA;
                mats[nrmats].coloane = cA;
                mats[nrmats].text = "A";
                nrmats++;
                for (int i = 0; i <= 2 * Max(lA, lB); i++)
                {
                    if (i == Max(lA, lB)) dis[i] = dis[i] + ", B = ";
                    else dis[i] = dis[i] + "      ";
                }
                if (lA > lB) addmatrix(ref dis, matB, lB, cB, lA - lB);
                else addmatrix(ref dis, matB, lB, cB, 0);
                mats[nrmats].M = matB;
                mats[nrmats].linii = lB;
                mats[nrmats].coloane = cB;
                mats[nrmats].text = "B";
                nrmats++;
                for (int i = 0; i <= 2 * Max(lA, lB); i++)
                {
                    if (i == Max(lA, lB)) dis[i] = dis[i] + " => C = A * B = ";
                    else dis[i] = dis[i] + "                ";
                }
                addmatrix(ref dis, rez, lA, cB, Max(lA, lB) - lA);
                mats[nrmats].M = rez;
                mats[nrmats].linii = lA;
                mats[nrmats].coloane = cB;
                mats[nrmats].text = "C";
                nrmats++;

                display.Text = "";
                for (int i = Max(lA, lB) * 2; i >= 0; i--) display.Text = newLine + dis[i] + display.Text;

                ToRez(ref rezultateRO, mats, nrmats, display.Text);
                ToRez(ref rezultateUK, mats, nrmats, display.Text);

                clearHistory.Enabled = true;
                RemRez.Enabled = true;
                next.Enabled = false;
                numRez++;
            }
        }

        private double[,] copyArray(int lin, int col, double[,] m)
        {
            double[,] nArray = new double[lin, col];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    nArray[i, j] = m[i, j];
                }
            }
            return nArray;
        }

        private void changepivot(int nrl, int nrc, ref double[,] m, ref double[,] P, int lin, int col)
        {
            double[,] nArray = new double[nrl, nrc];
            nArray = copyArray(nrl, nrc, m);
            if (nArray[lin, col] == 0)
                for (int j = lin + 1; j < nrl; j++)
                {
                    if (nArray[j, col] != 0)
                    {
                        for (int k = 0; k < nrc; k++)
                        {
                            double p = new double();
                            p = nArray[j, k];
                            nArray[j, k] = nArray[lin, k];
                            nArray[lin, k] = p;
                        }
                        for (int k = 0; k < nrl; k++)
                        {
                            double p = new double();
                            p = P[j, k];
                            P[j, k] = P[lin, k];
                            P[lin, k] = p;
                        }
                        break;
                    }
                }
            m = nArray;
        }

        private void esalon(int lin, int col, double[,] m, ref double[,] P, ref double[,] L, ref double[,] U)
        {
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < lin; j++)
                {
                    if (i == j) L[i, j] = P[i, j] = 1;
                    else L[i, j] = P[i, j] = 0;
                }
            }
            U = copyArray(lin, col, m);
            int d = 0;
            for (int i = 0; i < Min(lin, col); i++)
            {
                if (i + d == col) break;
                while (U[i, i + d] == 0 && i + d < col)
                {
                    changepivot(lin, col, ref U, ref P, i, i + d);
                    if (U[i, i + d] == 0) d++;
                    if (i + d == col) break;
                }
                if (i + d == col) break;
                for (int j = i + 1; j < lin; j++)
                {
                    double r = new double();
                    r = U[j, i + d] / U[i, i + d];
                    L[j, i] = Math.Round(r, 10);
                    for (int k = i + d; k < col; k++)
                    {
                        double rez = new double();
                        rez = U[i, k] * r;
                        rez = U[j, k] - rez;
                        U[j, k] = rez;
                    }
                }
            }
        }

        private double[,] multi(int linA, int colA, double[,] A, int linB, int colB, double[,] B)
        {
            double[,] C = new double[linA, colB];
            for (int i = 0; i < linA; i++)
            {
                for (int j = 0; j < colB; j++)
                {
                    for (int k = 0; k < colA; k++)
                    {
                        C[i, j] = C[i, j] + A[i, k] * B[k, j];
                    }
                }
            }
            bool wh;
            wh = whole_num(C, linA, colB);
            if (wh) ToZ(linA, colB, ref C);
            return C;
        }

        private double deter_I(int dim, double[,] I)
        {
            int sign = 1;
            for (int i = 0; i < dim; i++)
            {
                while (I[i, i] == 0)
                {
                    sign *= -1;
                    for (int j = i + 1; j < dim; j++)
                    {
                        if (I[j, i] == 1)
                        {
                            for (int k = 0; k < dim; k++)
                            {
                                double p = new double();
                                p = I[i, k];
                                I[i, k] = I[j, k];
                                I[j, k] = p;
                            }
                            break;
                        }
                    }
                }
            }
            return sign;
        }

        private double determinant(int dim, double[,] m)
        {
            double d = 1;
            bool wh;
            wh = whole_num(m, dim, dim);

            double[,] nArray = new double[dim, dim];
            double[,] L = new double[dim, dim];
            double[,] P = new double[dim, dim];
            esalon(dim, dim, m, ref P, ref L, ref nArray);

            d = deter_I(dim, P);
            for (int i = 0; i < dim; i++)
            {
                d *= nArray[i, i];
            }
            if (wh) d = Math.Round(d, 0);
            else d = Math.Round(d, 10);
            if (d == 0) d = 0;
            return d;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }


        private double[,] eliminare(int dim, double[,] m, int lin1, int col1)
        {
            double[,] newm = new double[100, 100];
            newm = copyArray(dim, dim, m);
            for (int i = lin1; i < dim - 1; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    newm[i, j] = newm[i + 1, j];
                }
            }
            for (int j = col1; j < dim - 1; j++)
            {
                for (int i = 0; i < dim - 1; i++)
                {
                    newm[i, j] = newm[i, j + 1];
                }
            }
            return newm;
        }

        private double[,] inversa(int dim, double[,] m)
        {
            double detm = new double();
            double[,] invm = new double[100, 100];
            detm = determinant(dim, m);
            invm = adjuncta(dim, m);
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    invm[i, j] = invm[i, j] / detm;
                }
            }
            return invm;
        }

        private void comb(ref int[,] ar, ref int num, ref int[] vec, int k, int x, int y)
        {
            for (int i = 1; i <= x; i++)
            {
                vec[k] = i;
                if (k == 1)
                {
                    if (k == y)
                    {
                        num++;
                        for (int j = 1; j <= y; j++) ar[num, j] = vec[j];
                    }
                    else comb(ref ar, ref num, ref vec, k + 1, x, y);
                }
                else
                    if (vec[k - 1] < vec[k])
                {
                    if (k == y)
                    {
                        num++;
                        for (int j = 1; j <= y; j++) ar[num, j] = vec[j];
                    }
                    else comb(ref ar, ref num, ref vec, k + 1, x, y);
                }
            }

        }

        private int rang(double[,] vtb, int lin, int col)
        {
            int min, numl = 0, numc = 0;
            min = Min(lin, col);
            while (min > 0)
            {
                int[,] arlin = new int[1000, 10];
                int[] veclin = new int[10]; numl = 0;
                comb(ref arlin, ref numl, ref veclin, 1, lin, min);

                int[,] arcol = new int[1000, 10];
                int[] veccol = new int[10]; numc = 0;
                comb(ref arcol, ref numc, ref veccol, 1, col, min);

                for (int i = 1; i <= numl; i++)
                    for (int j = 1; j <= numc; j++)
                    {
                        double[,] m = new double[100, 100];
                        for (int i1 = 1; i1 <= min; i1++)
                        {
                            for (int j1 = 1; j1 <= min; j1++)
                            {
                                m[i1 - 1, j1 - 1] = vtb[arlin[i, i1] - 1, arcol[j, j1] - 1];
                            }
                        }
                        double detm = new double();
                        detm = determinant(min, m);
                        if (detm != 0) return min;
                    }
                min--;
            }
            return min;
        }

        private string[,] matrix(TextBox[,] vtb, int lin, int col)
        {
            string[,] str = new string[10, 10];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    str[i, j] = vtb[i, j].Text;
                }
            }
            return str;
        }

        private string[,] FromDoubToStr(double[,] vtb, int lin, int col)
        {
            string[,] matstr = new string[lin, col];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double z = new double();
                    z = vtb[i, j];
                    z = Math.Round(z, 10);
                    matstr[i, j] = z.ToString();
                    if (matstr[i, j] == "-0" || matstr[i, j] == "+0") matstr[i, j] = "0";
                }
            }
            return matstr;
        }

        private double[,] ToDouble(string[,] vtb, int lin, int col)
        {
            double[,] dmat = new double[lin, col];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    double z = new double();
                    double.TryParse(vtb[i, j], out z);
                    dmat[i, j] = z;
                }
            }
            return dmat;
        }

        private void addmatrix(ref string[] dis, double[,] m, int lin, int col, int dist)
        {
            string[,] vtb = new string[lin, col];
            vtb = FromDoubToStr(m, lin, col);

            int length = 0;
            int i = 0;

            for (i = 0; i < col; i++)
            {
                length = 0;
                for (int j = 0; j < lin; j++)
                {
                    if (vtb[j, i].Length > length)
                    {
                        length = vtb[j, i].Length;
                    }
                }
                length += 2;
                for (int j = 0; j < lin; j++)
                {
                    vtb[j, i] = vtb[j, i].PadLeft(length);
                }
            }

            i = 0;
            while (i < dist)
            {
                dis[i] = dis[i] + " ";
                for (int j = 0; j < col; j++)
                {
                    for (int k = 0; k < vtb[0, j].Length; k++)
                    {
                        dis[i] = dis[i] + " ";
                    }
                }
                dis[i] = dis[i] + "   ";
                i++;
            }
            while (i - dist <= 2 * lin)
            {
                if ((i - dist) % 2 == 1)
                {
                    dis[i] = dis[i] + "|";
                    for (int j = 0; j < col; j++)
                    {
                        dis[i] = dis[i] + vtb[(i - dist) / 2, j];
                    }
                    dis[i] = dis[i] + "  |";
                }
                else
                {
                    if (i - dist == 0) dis[i] = dis[i] + "/";
                    else
                    {
                        if (i - dist == 2 * lin) dis[i] = dis[i] + "\\";
                        else dis[i] = dis[i] + "|";
                    }
                    for (int j = 0; j < col; j++)
                    {
                        for (int k = 0; k < vtb[0, j].Length; k++)
                        {
                            dis[i] = dis[i] + " ";
                        }
                    }
                    if (i - dist == 0) dis[i] = dis[i] + "  \\";
                    else
                    {
                        if (i - dist == 2 * lin) dis[i] = dis[i] + "  /";
                        else dis[i] = dis[i] + "  |";
                    }
                }
                i++;
            }
            while (i - dist - 2 * lin - 1 < dist)
            {
                dis[i] = dis[i] + " ";
                for (int j = 0; j < col; j++)
                {
                    for (int k = 0; k < vtb[0, j].Length; k++)
                    {
                        dis[i] = dis[i] + " ";
                    }
                }
                dis[i] = dis[i] + "   ";
                i++;
            }
        }

        private void ToZ(int lin, int col, ref double[,] mat)
        {
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mat[i, j] = Math.Round(mat[i, j], 0);
                }
            }
        }

        private void matrixOp(string[,] vtb, int lin, int col, string anunt)
        {
            double[,] matrice = new double[lin, col];
            matrice = ToDouble(vtb, lin, col);
            Matrix[] mats = new Matrix[6];
            for (int i = 0; i < 6; i++) mats[i] = new Matrix();
            int nrmats = 0;
            string[] dis = new string[100];
            string displayRO = newLine;
            string displayUK = newLine;

            if (anunt == "adjA" || anunt == "adjB")
            {
                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;

                for (int i = 0; i <= 2 * lin; i++)
                {
                    if (i == lin)
                    {
                        dis[i] = dis[i] + " => C = " + anunt[anunt.Length - 1].ToString() + "  = ";
                    }
                    else
                    {
                        if (i == lin - 1) dis[i] = dis[i] + "         *   ";
                        else dis[i] = dis[i] + "             ";
                    }
                }

                double[,] invmat = new double[lin, col];
                invmat = adjuncta(lin, matrice);

                addmatrix(ref dis, invmat, lin, col, 0);
                mats[nrmats].M = invmat;
                mats[nrmats].text = "C";
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;
            }

            if (anunt == "powerA" || anunt == "powerB")
            {
                double n = 0;
                if (anunt == "powerA") double.TryParse(powertbA.Text, out n);
                if (anunt == "powerB") double.TryParse(powertbB.Text, out n);
                string p;
                p = n.ToString();
                double[,] newMat = new double[lin, col];

                newMat = ToPower(lin, matrice, n);

                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;

                for (int i = 0; i <= 2 * lin; i++)
                {
                    if (i == lin)
                    {
                        dis[i] = dis[i] + " => C = " + anunt[anunt.Length - 1].ToString();
                        for (int j = 0; j < p.Length; j++) dis[i] = dis[i] + " ";
                        dis[i] = dis[i] + " = ";
                    }
                    else
                    {
                        if (i == lin - 1) dis[i] = dis[i] + "         " + p + "   ";
                        else
                        {
                            dis[i] = dis[i] + "         ";
                            for (int j = 0; j < p.Length; j++) dis[i] = dis[i] + " ";
                            dis[i] = dis[i] + "   ";
                        }
                    }
                }

                addmatrix(ref dis, newMat, lin, col, 0);
                mats[nrmats].M = newMat;
                mats[nrmats].text = "C";
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;
            }

            if (anunt == "multibyA" || anunt == "multibyB")
            {
                string p;
                double z = new double();
                if (anunt == "multibyA") double.TryParse(mulA.Text, out z);
                else double.TryParse(mulB.Text, out z);
                if (z < 0) p = " (" + z.ToString() + ") * ";
                else p = " " + z.ToString() + " * ";

                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;

                for (int i = 0; i <= 2 * lin; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " => C =" + p + anunt[anunt.Length - 1].ToString() + " = ";
                    else for (int j = 0; j < p.Length + 11; j++) dis[i] = dis[i] + " ";
                }

                double[,] rez = new double[lin, col];
                rez = multiplyby(matrice, lin, col, z);
                addmatrix(ref dis, rez, lin, col, 0);
                mats[nrmats].M = rez;
                mats[nrmats].text = "C";
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;
            }

            if (anunt == "detbA" || anunt == "detbB")
            {
                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }

                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;

                dis[lin] = dis[lin] + " => det(" + anunt[anunt.Length - 1].ToString() + ") = ";
                double detmat = new double();
                detmat = determinant(lin, matrice);
                dis[lin] = dis[lin] + detmat.ToString();
            }

            if (anunt == "invbA" || anunt == "invbB")
            {
                if (determinant(lin, matrice) != 0)
                {
                    for (int i = 0; i <= lin * 2; i++)
                    {
                        if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                        else dis[i] = dis[i] + "     ";
                    }
                    addmatrix(ref dis, matrice, lin, col, 0);
                    mats[nrmats].M = matrice;
                    mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                    mats[nrmats].linii = mats[nrmats].coloane = lin;
                    nrmats++;

                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        if (i == lin)
                        {
                            dis[i] = dis[i] + " => C = " + anunt[anunt.Length - 1].ToString() + "   = ";
                        }
                        else
                        {
                            if (i == lin - 1) dis[i] = dis[i] + "         -1   ";
                            else dis[i] = dis[i] + "              ";
                        }
                    }

                    double[,] invmat = new double[lin, col];
                    invmat = inversa(lin, matrice);

                    addmatrix(ref dis, invmat, lin, col, 0);
                    mats[nrmats].M = invmat;
                    mats[nrmats].text = "C";
                    mats[nrmats].linii = mats[nrmats].coloane = lin;
                    nrmats++;

                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        displayRO = displayRO + dis[i] + newLine;
                        displayUK = displayUK + dis[i] + newLine;
                    }
                }
                else
                {
                    string[] disRO = new string[100];
                    string[] disUK = new string[100];

                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        if (i == lin)
                        {
                            disRO[i] = disRO[i] + " Matricea " + anunt[anunt.Length - 1].ToString() + " = ";
                            disUK[i] = disUK[i] + " Matrix " + anunt[anunt.Length - 1].ToString() + " = ";
                        }
                        else
                        {
                            disRO[i] = disRO[i] + "              ";
                            disUK[i] = disUK[i] + "            ";
                        }
                    }
                    addmatrix(ref disRO, matrice, lin, col, 0);
                    addmatrix(ref disUK, matrice, lin, col, 0);
                    disRO[lin] = disRO[lin] + " nu este inversabila deoarece determinantul ei este egal cu 0.";
                    disUK[lin] = disUK[lin] + " is not invertible because determinant is equal to 0.";

                    mats[nrmats].M = matrice;
                    mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                    mats[nrmats].linii = mats[nrmats].coloane = lin;
                    nrmats++;

                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        displayRO = displayRO + disRO[i] + newLine;
                        displayUK = displayUK + disUK[i] + newLine;
                    }
                }
            }

            if (anunt == "rankA" || anunt == "rankB")
            {
                string[] disRO = new string[100];
                string[] disUK = new string[100];

                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin)
                    {
                        disRO[i] = disRO[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                        disUK[i] = disUK[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    }
                    else
                    {
                        disRO[i] = disRO[i] + "     ";
                        disUK[i] = disUK[i] + "     ";
                    }
                }
                addmatrix(ref disRO, matrice, lin, col, 0);
                addmatrix(ref disUK, matrice, lin, col, 0);

                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = mats[nrmats].coloane = lin;
                nrmats++;

                disRO[lin] = disRO[lin] + " => rang(" + anunt[anunt.Length - 1].ToString() + ") = ";
                disUK[lin] = disUK[lin] + " => rank(" + anunt[anunt.Length - 1].ToString() + ") = ";

                int r = new int();
                r = rang(matrice, lin, col);
                disRO[lin] = disRO[lin] + r.ToString();
                disUK[lin] = disUK[lin] + r.ToString();

                for (int i = 0; i <= 2 * lin; i++)
                {
                    displayRO = displayRO + disRO[i] + newLine;
                    displayUK = displayUK + disUK[i] + newLine;
                }
            }

            if (anunt == "transB" || anunt == "transA")
            {
                for (int i = 0; i <= Max(lin, col) * 2; i++)
                {
                    if (i == Max(lin, col)) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                if (lin > col) addmatrix(ref dis, matrice, lin, col, 0);
                else addmatrix(ref dis, matrice, lin, col, col - lin);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;

                for (int i = 0; i <= 2 * Max(lin, col); i++)
                {
                    if (i == Max(lin, col))
                    {
                        dis[i] = dis[i] + " => C = " + anunt[anunt.Length - 1].ToString() + "  = ";
                    }
                    else
                    {
                        if (i == Max(lin, col) - 1) dis[i] = dis[i] + "         T   ";
                        else dis[i] = dis[i] + "             ";
                    }
                }
                double[,] transmat = new double[col, lin];
                transmat = transpose(lin, col, matrice);

                if (col > lin) addmatrix(ref dis, transmat, col, lin, 0);
                else addmatrix(ref dis, transmat, col, lin, lin - col);
                mats[nrmats].M = transmat;
                mats[nrmats].text = "C";
                mats[nrmats].linii = col;
                mats[nrmats].coloane = lin;
                nrmats++;
            }

            if (anunt == "esalonA" || anunt == "esalonB")
            {
                string lit = anunt[anunt.Length - 1].ToString();
                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + lit + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = lit;
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;

                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + ", " + anunt[anunt.Length - 1].ToString() + " ~ C => C = ";
                    else dis[i] = dis[i] + "               ";
                }

                double[,] U = new double[lin, col];
                double[,] L = new double[lin, lin];
                double[,] P = new double[lin, lin];
                esalon(lin, col, matrice, ref P, ref L, ref U);

                for (int i = 0; i < lin; i++)
                {
                    for (int j = 0; j < i && j < col; j++)
                    {
                        U[i, j] = 0;
                    }
                }

                addmatrix(ref dis, U, lin, col, 0);
                mats[nrmats].M = U;
                mats[nrmats].text = "C";
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;
            }

            if (anunt == "luA" || anunt == "luB")
            {
                for (int i = 0; i <= lin * 2; i++)
                {
                    if (i == lin) dis[i] = dis[i] + " " + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "     ";
                }
                addmatrix(ref dis, matrice, lin, col, 0);
                mats[nrmats].M = matrice;
                mats[nrmats].text = anunt[anunt.Length - 1].ToString();
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;

                for (int i = 0; i <= lin * 2; i++)
                {
                    if (lin == i) dis[i] = dis[i] + ", ";
                    else dis[i] = dis[i] + "  ";
                }

                int val = 1;
                double[,] P = new double[lin, lin];
                double[,] L = new double[lin, lin];
                double[,] U = new double[lin, col];
                esalon(lin, col, matrice, ref P, ref L, ref U);

                for (int i = 0; i < lin; i++)
                {
                    if (P[i, i] == 0)
                    {
                        val = 0;
                        break;
                    }
                }

                double[,] P1 = new double[lin, lin];
                esalon(lin, col, multi(lin, lin, P, lin, col, matrice), ref P1, ref L, ref U);

                if (val == 0)
                {
                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        if (i == lin) dis[i] = dis[i] + "P * ";
                        else dis[i] = dis[i] + "    ";
                    }
                }
                for (int i = 0; i <= 2 * lin; i++)
                {
                    if (i == lin) dis[i] = dis[i] + anunt[anunt.Length - 1].ToString() + " = L * U => ";
                    else dis[i] = dis[i] + "             ";
                }

                if (val == 0)
                {
                    addmatrix(ref dis, P, lin, lin, 0);
                    mats[nrmats].M = P;
                    mats[nrmats].text = "P";
                    mats[nrmats].linii = lin;
                    mats[nrmats].coloane = lin;
                    nrmats++;
                    for (int i = 0; i <= 2 * lin; i++)
                    {
                        if (i == lin) dis[i] = dis[i] + " * ";
                        else dis[i] = dis[i] + "   ";
                    }
                }
                for (int i = 0; i <= 2 * lin; i++)
                {
                    if (i == lin) dis[i] = dis[i] + anunt[anunt.Length - 1].ToString() + " = ";
                    else dis[i] = dis[i] + "    ";
                }

                for (int i = 0; i < lin; i++)
                {
                    for (int j = i + 1; j < lin; j++)
                    {
                        L[i, j] = 0;
                    }
                }

                addmatrix(ref dis, L, lin, lin, 0);
                mats[nrmats].M = L;
                mats[nrmats].text = "L";
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = lin;
                nrmats++;

                for (int i = 0; i < lin * 2 + 1; i++)
                {
                    if (i != lin) dis[i] = dis[i] + "   ";
                    else dis[i] = dis[i] + " * ";
                }

                for (int i = 0; i < lin; i++)
                {
                    for (int j = 0; j < i && j < col; j++)
                    {
                        U[i, j] = 0;
                    }
                }

                addmatrix(ref dis, U, lin, col, 0);
                mats[nrmats].M = U;
                mats[nrmats].text = "U";
                mats[nrmats].linii = lin;
                mats[nrmats].coloane = col;
                nrmats++;
            }


            display.Text = "";
            if (anunt == "invbA" || anunt == "invbB" || anunt == "rankA" || anunt == "rankB")
            {
                ToRez(ref rezultateRO, mats, nrmats, displayRO);
                ToRez(ref rezultateUK, mats, nrmats, displayUK);
                if (sem == "RO") display.Text = displayRO;
                else display.Text = displayUK;
            }
            else
            {
                if (anunt == "transA" || anunt == "transB")
                {
                    for (int i = 0; i <= Max(lin, col) * 2; i++)
                    {
                        display.Text = display.Text + newLine + dis[i];
                    }
                }
                else
                {
                    if (anunt == "powerA" || anunt == "powerB" || anunt == "adjA" || anunt == "adjB")
                        for (int i = 0; i <= lin * 2; i++)
                        {
                            display.Text = display.Text + newLine + dis[i];
                        }
                    else
                    {
                        if (anunt == "luA" || anunt == "luB")
                        {
                            displayRO = newLine + " DESCOMPUNEREA LOWER-UPPER:" + newLine;
                            displayUK = newLine + " LOWER-UPPER DECOMPOSITION:" + newLine;
                        }
                        else displayRO = displayUK = "";
                        for (int i = 0; i <= lin * 2; i++)
                        {
                            displayRO = displayRO + newLine + dis[i];
                            displayUK = displayUK + newLine + dis[i];
                        }
                        if (sem == "RO") display.Text = displayRO;
                        else display.Text = displayUK;
                    }
                }

                if (anunt == "luA" || anunt == "luB")
                {
                    ToRez(ref rezultateRO, mats, nrmats, displayRO);
                    ToRez(ref rezultateUK, mats, nrmats, displayUK);
                }
                else
                {
                    ToRez(ref rezultateRO, mats, nrmats, display.Text);
                    ToRez(ref rezultateUK, mats, nrmats, display.Text);
                }
            }

            clearHistory.Enabled = true;
            RemRez.Enabled = true;
            next.Enabled = false;
            numRez++;
        }

        private double[,] multiplyby(double[,] mat, int lin, int col, double mult)
        {
            double[,] multimat = new double[lin, col];
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    multimat[i, j] = mult * mat[i, j];
                }
            }
            bool wh;
            wh = whole_num(multimat, lin, col);
            if (wh) ToZ(lin, col, ref multimat);
            return multimat;
        }

        private bool verif_str_Doub(string txt)
        {
            bool valid;
            valid = double.TryParse(txt, out double z);
            return valid;
        }

        private bool verif_strings(string[,] txts, int lin, int col)
        {
            bool valid = true;
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    valid = verif_str_Doub(txts[i, j]);
                    if (valid == false) break;
                }
                if (valid == false) break;
            }
            return valid;
        }

        private void apasa_d(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "detbA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "detbB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }

            bool valid;
            valid = verif_strings(txts, l, c);
            if (valid == false)
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
            else
            {
                if (l != c)
                {
                    if (sem == "RO") MB("Matricea nu este patrata.");
                    else MB("The matrix is not square.");
                }
                else matrixOp(txts, l, c, but.Name);
            }
        }

        private void apasa_inve(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "invbA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "invbB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }

            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == false)
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
            else
            {
                if (l != c)
                {
                    if (sem == "RO") MB("Matricea nu este patrata.");
                    else MB("The matrix is not square.");
                }
                else matrixOp(txts, l, c, but.Name);
            }
        }

        private void apasa_rank(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "rankA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "rankB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }
            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == true) matrixOp(txts, l, c, but.Name);
            else
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
        }

        private void apasa_trans(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "transA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "transB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }
            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == true) matrixOp(txts, l, c, but.Name);
            else
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
        }

        private void apasa_esalon(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "esalonA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "esalonB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }
            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == true) matrixOp(txts, l, c, but.Name);
            else
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
        }

        private void apasa_LU(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "luA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "luB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }
            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == true) matrixOp(txts, l, c, but.Name);
            else
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
        }

        private void apasa_multiplyby(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            string mul = null;
            Button but = (Button)sender;
            if (but.Name == "multibyA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
                mul = mulA.Text;
            }
            if (but.Name == "multibyB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
                mul = mulB.Text;
            }
            bool valid1, valid2;
            valid1 = verif_strings(txts, l, c); valid2 = verif_str_Doub(mul);
            if (valid1 && valid2) matrixOp(txts, l, c, but.Name);
            else
            {
                if (valid1 == false)
                {
                    if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                    else MB("Please fill out the matrix with real numbers!");
                }
                else
                {
                    if (sem == "RO") MB("Te rog introdu o valoare numar real pentru inmultitor!");
                    else MB("Please fill out the textbox for multiplier with a real number!");
                }
            }
        }

        private void apasa_power(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            string pow = null;
            Button but = (Button)sender;
            if (but.Name == "powerA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
                pow = powertbA.Text;
            }
            if (but.Name == "powerB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
                pow = powertbB.Text;
            }

            bool valid1, valid2;
            valid1 = verif_strings(txts, l, c); valid2 = verif_str_Doub(pow);
            if (valid1 & valid2)
            {
                if (l != c)
                {
                    if (sem == "RO") MB("Matricea nu este patrata.");
                    else MB("The matrix is not square.");
                }
                else
                {
                    double z;
                    double.TryParse(pow, out z);
                    if (z != Math.Round(z, 0))
                    {
                        if (sem == "RO") MB("Te rog introdu o putere intreaga!");
                        else MB("Please fill out the textbox for power with a whole number!");
                    }
                    else
                    {
                        double[,] mat = new double[l, c];
                        mat = ToDouble(txts, l, c);
                        if (determinant(l, mat) == 0 && z <= 0)
                        {
                            if (sem == "RO") MB("Matricea nu poate fi ridicata la o putere negativa sau egala cu 0 deoarece determinantul ei este egal cu 0.");
                            else MB("The matrix cannot be raised to a less or equal to 0 power because determinant is 0.");
                        }
                        else matrixOp(txts, l, c, but.Name);
                    }
                }
            }
            else
            {
                if (valid1 == false)
                {
                    if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                    else MB("Please fill out the matrix with real numbers!");
                }
                else
                {
                    if (sem == "RO") MB("Te rog introdu o putere intreaga!");
                    else MB("Please fill out the textbox for power with a whole power!");
                }
            }
        }

        private void apasa_adj(object sender, EventArgs e)
        {
            int l = 0, c = 0;
            string[,] txts = new string[10, 10];
            Button but = (Button)sender;
            if (but.Name == "adjA")
            {
                l = lA; c = cA;
                txts = matrix(vA, l, c);
            }
            if (but.Name == "adjB")
            {
                l = lB; c = cB;
                txts = matrix(vB, l, c);
            }

            bool valid = true;
            valid = verif_strings(txts, l, c);
            if (valid == false)
            {
                if (sem == "RO") MB("Te rog introdu valori numere reale in matrici!");
                else MB("Please fill out the matrix with real numbers!");
            }
            else
            {
                if (l != c)
                {
                    if (sem == "RO") MB("Matricea nu este patrata.");
                    else MB("The matrix is not square.");
                }
                else matrixOp(txts, l, c, but.Name);
            }
        }

        private void apasa_rand(object sender, EventArgs e)
        {
            Random r1 = new Random();
            Button but = (Button)sender;
            if (but.Name == "randA")
                for (int i = 0; i < lA; i++)
                {
                    for (int j = 0; j < cA; j++)
                    {
                        vA[i, j].Text = r1.Next(-10, 11).ToString();
                    }
                }
            if (but.Name == "randB")
                for (int i = 0; i < lB; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        vB[i, j].Text = r1.Next(-10, 11).ToString();
                    }
                }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            alternatives.Items.Add("A * X = B");
            alternatives.Items.Add("X * A = B");
            alternatives.Items.Add("x * A + y * B");
            alternatives.Items.Add("x * A^n + y * B^m");
            Controls.Add(alternatives);

            Controls.Add(prev);
            prev.Click += new System.EventHandler(previous);

            Controls.Add(next);
            next.Click += new System.EventHandler(urmatorul);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i < 3 && j < 3) vA[i, j].Visible = true;
                    else
                    {
                        vA[i, j].Text = "";
                        vA[i, j].Visible = false;
                    }

                }
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i < 3 && j < 3) vB[i, j].Visible = true;
                    else
                    {
                        vB[i, j].Text = "";
                        vB[i, j].Visible = false;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                prmtL[i].Visible = false;
                prmtTB[i].Visible = false;
            }
        }
    }
}