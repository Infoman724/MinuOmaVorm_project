using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuOmaVorm_project
{
    public partial class MinuOmaVorm : Form
    {
        TreeView puu;
        Button nupp;
        Label silt;
        CheckBox mruut1, mruut2;
        RadioButton rnupp1, rnupp2, rnupp3, rnupp4;
        PictureBox pilt;
        ProgressBar riba;
        public MinuOmaVorm()
        {
            Height = 600;                                               //ширина
            Width = 900;                                                //высота
            Text = "Minu oma vorm koos elementidega";                   //название формы??
            puu = new TreeView();                                           
            puu.Dock = DockStyle.Left;
            puu.Location = new Point(0, 0);
            TreeNode oksad = new TreeNode("Elemendid");
            oksad.Nodes.Add(new TreeNode("Nupp-Button"));
            oksad.Nodes.Add(new TreeNode("Silt-Label"));
            oksad.Nodes.Add(new TreeNode("Dialog aken-Message box"));
            oksad.Nodes.Add(new TreeNode("Märkeruut-Checkbox"));
            oksad.Nodes.Add(new TreeNode("Radionupp-Radiobutton"));
            oksad.Nodes.Add(new TreeNode("Edenemisriba-Progressbar"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            

            silt = new Label
            {
                Text = "Minu esimine vorm",
                Size = new Size(200, 50),
                Location = new Point(200, 0),
            };
            mruut1 = new CheckBox
            {
                Checked = false,
                Text = "Üks",
                Location = new Point(silt.Left + silt.Width, 0),
                Height = 100,
                Width = 100

            };
            mruut2 = new CheckBox
            {
                Checked = false,
                Text = "Kaks",
                Location = new Point(silt.Left + silt.Width, mruut1.Height),
                Height = 25,
                Width = 100

            };
            if (e.Node.Text == "Nupp-Button")
            {
                nupp = new Button();
                nupp.Text = "Vajuta siia";
                nupp.Height = 30;
                nupp.Width = 100;
                nupp.Location = new Point(200, 100);
                nupp.Click += Nupp_Click;
                this.Controls.Add(nupp);
            }
            else if (e.Node.Text == "Silt-Label")
            {   
               
                silt.MouseEnter += Silt_MouseEnter;
                silt.MouseLeave += Silt_MouseLeave;
                this.Controls.Add(silt);
            }
            else if (e.Node.Text == "Dialog aken-Message box")
            {
                MessageBox.Show("Siia kirjuta lause", "Kõike lihtne aken");
                var vastus = MessageBox.Show("Kas paneme aken kinni?","Valik",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (vastus == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (vastus == DialogResult.No)
                {
                    MessageBox.Show("Tbi Bbikanul?");
                }
            }
            else if (e.Node.Text == "Märkeruut-Checkbox")
            {   
                
                this.Controls.Add(mruut1);
                this.Controls.Add(mruut2);
                mruut1.CheckedChanged += mruut_Click;
                mruut2.CheckedChanged += mruut_Click;




            }
            else if (e.Node.Text == "Radionupp-Radiobutton")
            {
                rnupp1 = new RadioButton
                {
                    Text = "Paremale",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height)

                };
                rnupp2 = new RadioButton
                {
                    Text = "Vasakule",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height + rnupp1.Width)

                };
                rnupp3 = new RadioButton
                {
                    Text = "Ülesse",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height + rnupp1.Width + rnupp2.Width)

                };
                rnupp4 = new RadioButton
                {
                    Text = "Alla",
                    Width = 112,
                    Location = new Point(mruut2.Left + mruut2.Width, mruut1.Height + mruut2.Height + rnupp1.Width + rnupp2.Width + rnupp3.Width)

                };
                pilt = new PictureBox
                {
                    Image = new Bitmap("meme.JPEG"),
                    Location = new Point(300, 450),                 
                    Size = new Size(100, 100),
                    SizeMode = PictureBoxSizeMode.Zoom,
                };
                rnupp1.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp2.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp3.CheckedChanged += new EventHandler(Rnuppud_Changed);
                rnupp4.CheckedChanged += new EventHandler(Rnuppud_Changed);

                this.Controls.Add(rnupp1);
                this.Controls.Add(rnupp2);
                this.Controls.Add(rnupp3);
                this.Controls.Add(rnupp4);
                this.Controls.Add(pilt);
                
            }
            else if (e.Node.Text == "Edenemisriba-Progressbar")
            {
                riba = new ProgressBar
                {
                    Width = 400,
                    Height = 30,
                    Location = new Point(350, 500),
                    Value = 0,
                    Minimum = 0,
                    Maximum = 100,
                    Step = 1,
                    Dock = DockStyle.Bottom
                };
                this.Controls.Add(riba);
            }
        }

        private void Rnuppud_Changed(object sender, EventArgs e)
        {
            if (rnupp1.Checked)
            {
                pilt.Location = new Point(pilt.Left + 10, pilt.Top);
                rnupp1.Checked = false;
            }
            else if (rnupp2.Checked)
            {
                pilt.Location = new Point(pilt.Left - 10, pilt.Top);
                rnupp2.Checked = false;
            }
            else if (rnupp3.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top - 10);
                rnupp3.Checked = false;
            }
            else if (rnupp4.Checked)
            {
                pilt.Location = new Point(pilt.Left, pilt.Top + 10);
                rnupp4.Checked = false;
            }
        }

        private void mruut_Click(object sender, System.EventArgs e)
        {
              
            if (mruut1.Checked == true && mruut2.Checked == true)
            {
                BackColor = Color.Blue;
            }
            else if (mruut1.Checked == true && mruut2.Checked == false)
            {
                BackColor = Color.Green;                                                               //мб позже доделаю больше
            }
            else if (mruut1.Checked == false && mruut2.Checked == true)
            {
                BackColor = Color.Yellow;
            }
            else if (mruut1.Checked == false && mruut2.Checked == false)
            {
                BackColor = Color.White;
            }
        }

        private void Silt_MouseLeave(object sender, EventArgs e)
        {
            
            silt.BackColor = Color.Beige;
            silt.BackColor = Color.Transparent;
        }

        private void Silt_MouseEnter(object sender, EventArgs e)
        {
            silt.ForeColor = Color.White;
            
        }

        Random random = new Random();
        private void Nupp_Click(object sender, EventArgs e)
        {
            int red,green,blue;
            red = random.Next(255);
            green = random.Next(255);
            blue = random.Next(255);
            this.BackColor = Color.FromArgb(red, green, blue);




        }
    }
}









//------------------------------------------Подвал приколов---------------------------------------------------------------------------
//InitializeComponent(); Нужно для того если работать с инструментами
//oksad-ветки

/*private void mruut_Click(object sender, System.EventArgs e)               
{

    if (mruut1.Checked)
    {
        mruut1.Text = "Do you even know what you did????!!";
    }
    else if (mruut1.Checked == false)
    {
        mruut1.Text = "You better click it its already to late for you";   P.s мой вариант текст первого бокса переключался а второго нет
    }
    else if (mruut2.Checked)
    {
        mruut1.Text = "Actualy this button might help you";
    }
    else if (mruut2.Checked == false)
    {
        mruut1.Text = "Uncheck the first button that will save you";
    }
}
*/