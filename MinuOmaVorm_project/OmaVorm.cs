using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace MinuOmaVorm_project
{
    public class OmaVorm : Form
    {
        Label failNimi;                                         //переменная "failiNimi" типа "Label"
        public OmaVorm() { }                                    //пустой конструктор для примера был сделан на уроке
        public OmaVorm(string Pealkiri, string Nupp)            //конструктор по которому работает этот класс
        {            
            this.ClientSize = new System.Drawing.Size(300, 300);//размер окна
            this.Text = Pealkiri;                               //текст
            Button nupp = new Button                            //обьявили кнопку
            {
                Text = Nupp,
                Location = new System.Drawing.Point(50, 50),    //добавляем ей свойства
                Size = new System.Drawing.Size(100,25),         //размер кнопки
                BackColor = System.Drawing.Color.Aquamarine,    //задний цвет
                ForeColor = System.Drawing.Color.Black,         //передний цвет
            };
            
            
            nupp.Click += NuppClick;                            //связываем событие с функцией "NuppClick"
            this.Controls.Add(nupp);                            //добавляем кнопку на экран
            
        }
        bool NuppWasClicked;                                    //обьявили переменную "NuppWasClicked" типа "bool" 

        private void NuppClick(object sender, EventArgs e)      //функция по нажатию на кнопку
        {
            
            Button nupp_sender = (Button)sender;                //сендер для кнопки 
            nupp_sender.Enabled = true;                         //если сендер тригернулся/включился(enabled) то равно "true"
                                                                
            Label failNimi = new Label                          //обьявили переменную "failiNimi" типа "Label"
            {                                                   
                Text = "",                                      //текст равен "" тоесть пустоте
                Location = new System.Drawing.Point(150, 50),   //местоположение
                Size = new System.Drawing.Size(100, 25),        //размер
                BackColor = System.Drawing.Color.Aquamarine,    //задний цвет
                ForeColor = System.Drawing.Color.Black,         //передний цвет
            };                                                  
                                                                
            Button nupp2 = new Button                           //обьявили второую кнопку
            {                                                   
                Text = "Play",                                  //текст равен "Play"
                Location = new System.Drawing.Point(50, 100),   //расположение
                Size = new System.Drawing.Size(100, 25),        //размер
                BackColor = System.Drawing.Color.Aquamarine,    //задний цвет
                ForeColor = System.Drawing.Color.Black,         //передний цвет
            };                                                  
            nupp2.Click += NuppClick2;                          //указали какую функцию запускать при событии(нажатии)

            Button nupp3 = new Button                           //обьявили второую кнопку
            {                                                   
                Text = "Stop",                                  //текст равен "Stop
                Location = new System.Drawing.Point(50, 200),   //расположение
                Size = new System.Drawing.Size(100, 25),        //размер
                BackColor = System.Drawing.Color.Aquamarine,    //задний цвет
                ForeColor = System.Drawing.Color.Black,         //передний цвет
            };                                                  
            nupp3.Click += NuppClick3;
                                                                
            OpenFileDialog failiValik = new OpenFileDialog();   //обьявили и создали переменную "failiValik" типа "OpenFileDialog"
            DialogResult tulemus = failiValik.ShowDialog();     //указали что результат выбора файла будет равен тому файлу который мы выберем при появлении "failiValik"
                                                                
            if (tulemus == DialogResult.OK)                     //если результат/выбор равняется ответу ок(DialogResult.OK)
            {                                                   
                if (NuppWasClicked)                             //и если кнопка была нажата
                {                                               
                    MuusikaKuulamine(failiValik.FileName);      //то используем функцию "MuusikaKuulamine" которая за аргумент принимает название файла в "string" формате
                    MessageBox.Show("hästi");                   //и показываем сообщение "hästi"
                }                                               
            }                                                   
                                                                
            string[] files = failiValik.FileNames;              //обьявили массив "files" который равен нашему "failiValik"
            foreach (string item in files)                      //за каждый предемет(item) типа "string" в "files" тоесть нашем массиве
            {                                                   
                string[] devine = item.Split('\\');             //будет массив devine которые выполняет функцию разделителя для предмета
                failNimi.Text = devine[devine.Length - 1];      //текст "failiNimi" будет равен длине массива "devine" - 1
            }                                                   
                                                                
            this.Controls.Add(failNimi);                        //добавляем элемент "failiNimi" на в панель управление/экран
            this.Controls.Add(nupp2);                           //добавляем вторую кнопку на экран
            this.Controls.Add(nupp3); 
                                                                
        }                                                       
        public void MuusikaKuulamine(string file)              //функция прослушивания музыки принимающая за аргумент название файла типа "string"
        {                                                       
            using (var muusika = new SoundPlayer(file))         //используя переменную "muusika" типа "var" которая равна созданнуму обьекту "SoundPlayer" с аргументом в виде "file" который мы передали
            {                                                   
                muusika.Play();                                 //используем встроенную функцию проигрывания файла
            }                                                   
        }                                                       
        private void NuppClick2(object sender, EventArgs e)     //и функция нажатия на вторую кнопку
        {                                                       
            NuppWasClicked = true;                              //просто если кнопка была нажата то равна тру
        }

        private void NuppClick3(object sender, EventArgs e)     //и функция нажатия на третью кнопку
        {                                                       
          using (var muusika = new SoundPlayer())
          {
                muusika.Stop();
          }                         
        }
    }    
}
