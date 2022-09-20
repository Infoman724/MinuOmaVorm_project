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
            oksad.Nodes.Add(new TreeNode("Dialog aken- Message box"));

            puu.AfterSelect += Puu_AfterSelect;
            puu.Nodes.Add(oksad);
            this.Controls.Add(puu);
        }

        private void Puu_AfterSelect(object sender, TreeViewEventArgs e)
        {
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
                silt = new Label
                {
                    Text = "Minu esimine vorm",
                    Size = new Size(200, 50),
                    Location = new Point(200, 0),
                };
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
