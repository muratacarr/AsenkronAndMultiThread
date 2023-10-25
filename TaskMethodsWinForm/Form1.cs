using System.Diagnostics;
using System.Threading;

namespace TaskMethodsWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("1 Main Thread : "+Thread.CurrentThread.ManagedThreadId.ToString());
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("2 button1_Click Thread : " + Thread.CurrentThread.ManagedThreadId.ToString());
            //textBox1.Text = ReadFile();
            Console.WriteLine("3 ReadFileAsync(); önce");
            var deneme = ReadFileAsync();
            Console.WriteLine("9 ReadFileAsync(); sonra");

            textBox3.Text = "ilk bu gelecek";
            Console.WriteLine("10 await deneme önce");
            textBox1.Text = await deneme;
            Console.WriteLine("14 await deneme sonra");
            Console.WriteLine("15 button1_Click Thread : " + Thread.CurrentThread.ManagedThreadId.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = Increase(textBox2.Text);
        }

        public static string Increase(string text)
        {
            string deneme = string.IsNullOrEmpty(text) ? "0" : text;
            if (int.TryParse(deneme, out int number))
            {
                number++;
                return number.ToString();
            }
            return "Sayıya çevrilemedi";
        }

        public string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Console.WriteLine("ReadFile Thread : " + Thread.CurrentThread.ManagedThreadId.ToString());
                data = streamReader.ReadToEnd();
                Thread.Sleep(5000);
            }
            return data;
        }

        public async Task<string> ReadFileAsync()
        {
            Console.WriteLine("4 ReadFileAsync() giriş");
            string data = string.Empty;
            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Console.WriteLine("5 ReadFileAsync Thread : " + Thread.CurrentThread.ManagedThreadId.ToString());
                Console.WriteLine("6 ReadToEndAsync önce");
                var data1 = streamReader.ReadToEndAsync();
                Console.WriteLine("7 ReadToEndAsync sonra");

                Console.WriteLine("8 await Task.Delay(3000); önce");
                await Task.Delay(3000);
                Console.WriteLine("11 await Task.Delay(3000); sonra");

                Console.WriteLine("12 await data1 önce");
                data = await data1;
                Console.WriteLine("13 await data1 sonra");

            }
            return data;
        }
    }
}