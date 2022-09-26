using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinuOmaVorm_project
{
    public class OmaVorm : Form
    {
        Random rnd = new Random();
        public OmaVorm() { }
        public OmaVorm(string Pealkiri, string Nupp, string Fail)
        {
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Text = Pealkiri;
            Button nupp = new Button
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightSkyBlue,

            };
            nupp.Click += Nupp_Click;
            Label failinimi = new Label
            {
                Location = new System.Drawing.Point(50, 0),
                Text = Fail,
                Size = new System.Drawing.Size(100, 50),
                BackColor = System.Drawing.Color.LightSkyBlue

            };
            this.Controls.Add(nupp);
            this.Controls.Add(failinimi);
        }

        private void Nupp_Click(object sender, EventArgs e)
        {
            string[] Songs = { @"..\..\rickroll.wav", @"..\..\this_fire.wav", @"..\..\love.wav" };
            Button nupp_sender = (Button)sender;
            var vastus = MessageBox.Show("Kas tahad muusika kuulata?", "Küsimus", MessageBoxButtons.YesNo);
            if (vastus == DialogResult.Yes)
            {
                using (var muusika = new SoundPlayer(Songs[rnd.Next(0, 2)]))
                {
                    muusika.Play();
                }
            }
            else
            {
                MessageBox.Show(":(");
            }
        }
    }
}
//есть вариант проигрывать одну соучайную песню из Х количества
//есть вариант проигрывать музыку введенную пользователем по средствам названия файла
//есть вариан с выбором нужной музыки по средствам нажатия определенной кнопки