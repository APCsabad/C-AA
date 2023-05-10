using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Csaa_jo
{
    public partial class Form1 : Form
    {
        static List<Food> FoodLista = new List<Food>();
        static List<Dolgozok> DolgozokList = new List<Dolgozok>();

        List<int> priceList = new List<int>();
        public Form1()
        {
            Database db = new Database();
            FoodLista.AddRange(db.getFood());
            DolgozokList.AddRange(db.getDolgozok());



            InitializeComponent();
        }

        private void sajtburi_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void hambi_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void Csibe_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }
        private void hawaii_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }
        private void milanopizza_Click(object sender, EventArgs e)
        {
            addProduct(sender);

        }
        private void szalamisp_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void sonkasp_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void mpizza_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void spagetti_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void Csali_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void Tsali_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void nysajttorta_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void Gyümölcsleves_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }

        private void fac_Click(object sender, EventArgs e)
        {
            addProduct(sender);
        }
        //törlés
        private void Torles_Click(object sender, EventArgs e)
        {

            int index = listBox1.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("Kérlek válaszd ki elõbb mit szeretnél törölni!");
            }
            else
            {
                listBox1.Items.RemoveAt(index);
                priceList.RemoveAt(index);
            }

        }
        //tételek árának összeadása, következõ panel mutatása
        private void total_Click(object sender, EventArgs e)

        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel1.BringToFront();

            int sum = sumItems();
            label4.Text = sum.ToString();


        }

        private int sumItems()
        {

            int sum = 0;

            foreach (var price in priceList)
            {
                sum += price;
            }

            return sum;

        }

        private void addProduct(object sender)
        {
            string food = (sender as Button).Text;
            int currentPrice = get_price_by_name(food);

            string item = food + " " + currentPrice;

            listBox1.Items.Add(item);
            priceList.Add(currentPrice);
        }


        private int get_price_by_name(string name)
        {

            foreach (var food in FoodLista)
            {

                if (food.name == name)
                {
                    return food.price;
                }

            }

            return -1;

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        //teszt kiiratás
        private void button1_Click(object sender, EventArgs e)
        {
            subtract_money(textBox1, typeof(TextBox));
        }


        //számológép 
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void ketto_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void harom_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void negy_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void ot_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void hat_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void het_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void nyolc_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void kilenc_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }

        private void nulla_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox1);
        }
        private void add_Text_to_TextBox(object sender, TextBox textbox)
        {
            string text = (sender as Button).Text;

            textbox.Text += text;
        }

        //teljes osszeg
        private void otszaz_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }

        private void ezer_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }

        private void ketezer_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }

        private void otezer_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }

        private void tizezer_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }

        private void huzezer_Click(object sender, EventArgs e)
        {
            subtract_money(sender, typeof(Button));
        }
        private void subtract_money(object sender, Type type)
        {
            string text;
            if (type == typeof(Button))
            {
                text = (sender as Button).Text;
            }
            else
            {
                text = (sender as TextBox).Text;
            }
            int amount_paid = Convert.ToInt32(text);

            int sum = sumItems();
            if (amount_paid < sum)
            {
                MessageBox.Show("Túl keveset kapott!");

            }
            else
            {

                panel1.Hide();
                panel2.Hide();
                panel3.Show();
                panel1.BringToFront();
                label2.Text = (amount_paid - sum).ToString();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void visszaadva_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Show();
            panel3.Hide();
            panel1.BringToFront();

            priceList.Clear();
            listBox1.Items.Clear();
            textBox1.Clear();
            label4.Text = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pontos_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Show();
            panel1.BringToFront();
            label2.Text = "0";
        }

        private void Bejel_Click(object sender, EventArgs e)
        {
            string text = textBox2.Text;

            if (text != "")
            {

                int id = Convert.ToInt32(text);
                string name = get_name_by_id(id);

                if (name != "")
                {
                    textBox3.Text = name;
                    textBox4.Text = name;
                    panel1.Hide();
                    panel2.Show();
                    panel3.Hide();
                    panel4.Hide();
                    panel1.BringToFront();
                }
                else {
                    MessageBox.Show("Kérlek adj meg létezõ id-t!(Kártyán található szám)");
                }

            }

        }

        private string get_name_by_id(int id)
        {

            foreach (var dolgozo in DolgozokList)
            {

                if (dolgozo.userid == id)
                {
                    return dolgozo.firstname + " " + dolgozo.lastname;
                }

            }

            return "";

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void b8_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b9_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b6_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b7_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b1_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b5_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b2_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void b0_Click(object sender, EventArgs e)
        {
            add_Text_to_TextBox(sender, textBox2);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Id_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void kilepes_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dell1_Click(object sender, EventArgs e)
        {
            delete_Last_Character(sender);
        }

        private void Dell2_Click(object sender, EventArgs e)
        {
            delete_Last_Character(sender);
        }
        private void delete_Last_Character(object sender)
        {

            TextBox textBox = (sender as Button) == Dell2 ? textBox1 : textBox2;

            if (textBox.Text != "")
            {
                string result = textBox.Text.Substring(0, textBox.Text.Length - 1);

                textBox.Text = result;
            }

        }
    }
}