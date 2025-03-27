namespace pictureTest
{
    public partial class Form1 : Form
    {
        const string path = "C:\\Users\\reall\\Pictures\\Screenshots";
        Random rm = new Random();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("ordner existiert nisch");
                return;
            }
            string[] images = Directory.GetFiles(path, "*.*")
                .Where(f => f.EndsWith(".jbg") || f.EndsWith(".png") || f.EndsWith(".bmp"))
                .ToArray();

            if (images.Length == 0)
            {
                MessageBox.Show("Keine Bilder gefunden");
                return;
            }
            string randomimage = images[rm.Next(images.Length)];
            pictureBox1.Image = System.Drawing.Image.FromFile(randomimage);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
