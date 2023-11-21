using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using WebApplication2.Models;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        string baseUrl = "https://localhost:7091/api/Product";
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            using HttpClient client = new HttpClient();

            var data = await client.GetAsync(baseUrl);

            var result = await data.Content.ReadAsStringAsync();

            var list = JsonSerializer.Deserialize<List<Product>>(result, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });


            list.ForEach(x =>
            {


                listBox1.Items.Add($"{x.Id}|id :{x.Id} name: {x.Name} price: {x.Price}");

            });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var product = new Product()
            {

                Name = txtName.Text,
                Price = int.Parse(txtPrice.Text)
            };

            var jsonData = JsonSerializer.Serialize(product);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using HttpClient client = new HttpClient();
            var response = await client.PostAsync(baseUrl, stringContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("iþlem baþarýlý");


            }
            else
            {
                MessageBox.Show(await response.Content.ReadAsStringAsync());
            }



        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using HttpClient client = new HttpClient();


            var id = textBox1.Text;
            var result = await client.DeleteAsync(baseUrl + "/" + id);

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("iþlem baþarýlý");
            }
            else
            {
                MessageBox.Show(await result.Content.ReadAsStringAsync());
            }
        }

        private async void listBox1_DoubleClick(object sender, EventArgs e)
        {

            ListBox listBox = sender as ListBox;

            var selectedItemId = listBox.SelectedItem.ToString().Split("|")[0];


            //get by ýd 

            using HttpClient client = new HttpClient();


            var result = await client.GetAsync(baseUrl + $"/{selectedItemId}");

            var jsonData = await result.Content.ReadAsStringAsync();

            var product = JsonSerializer.Deserialize<Product>(jsonData, new JsonSerializerOptions()
            {

                PropertyNameCaseInsensitive = true
            });


            txtUpdatePrice.Text = product.Price.ToString();
            textUpdateName.Text = product.Name;

            itemId = product.Id;
        }

        private int itemId =0;
        private async void button4_Click(object sender, EventArgs e)
        {


            using HttpClient client = new HttpClient();


            var product = new Product()
            {

                Id = itemId,
                Price = int.Parse(txtUpdatePrice.Text),
                Name = textUpdateName.Text


            };


            var jsonData=  JsonSerializer.Serialize(product);

            var stringContext = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var UpdateResult =  await client.PutAsync(baseUrl, stringContext);

            if (UpdateResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("iþlem baþarýlý");
            }

        }
    }
}
