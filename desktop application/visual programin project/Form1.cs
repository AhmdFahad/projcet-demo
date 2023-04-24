using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using System.Collections;
using Newtonsoft.Json;


namespace visual_programin_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            l();
         
        }
        public async void l() {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://127.0.0.1:8000/");
                var r = await response.Content.ReadAsStringAsync();
                var x = JsonConvert.DeserializeObject<List<string>>(r);

                listBox1.Items.Clear();
                foreach (string k in x)
                {
                    listBox1.Items.Add(k);
                }
            }

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            string item=textBox1.Text;
            
            textBox1.Clear();

            using (HttpClient client = new HttpClient())
            {
                StringContent c = new StringContent("Content-Type: application/json");
                var res= await client.PostAsync("http://127.0.0.1:8000/"+ item,c);
            }
            l();
        }

        private async void button2_Click(object sender, EventArgs e)
        {

            using (HttpClient client = new HttpClient())
            {
                for(int i = 0; i < listBox1.SelectedItems.Count; i++) { 
                    var res = await client.DeleteAsync("http://127.0.0.1:8000/" + listBox1.SelectedItems[i].ToString());
                }

            }
            l();
        }
    }
}
