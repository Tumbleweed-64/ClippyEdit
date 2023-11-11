namespace Clippy;
using System.IO;
using System.Text;
#nullable disable warnings

// Note to other devs: You can edit the theme by changing the colors in my terrible theme function.
// If you want your changes saved permanently please make a pull request.
// API coming soon to make things easier.

public partial class Form1 : Form
{
	public PictureBox pictureBox1;
	public Label label1;
	public Label label2;
	public TextBox textBox1;
	public OpenFileDialog openFileDialog1;
	public Button button1;
	public SaveFileDialog saveFileDialog1;
	public Button button2;
	public Button button3;
	public Button button4;
	
    public Form1()
    {
		CreateMyPic();
		this.Controls.SetChildIndex(pictureBox1, 1);
		CreateClippyText();
		this.Controls.SetChildIndex(label1, 0);
		CreateTextBox();
		MakeOpenButton();
		MakeSaveButton();
		MakeThemeButton();
		MakeClippyButton();
		InitializeComponent();
		this.WindowState = FormWindowState.Maximized;
    }
	
	public void CreateMyPic()
	{
		pictureBox1 = new PictureBox();
		pictureBox1.Image = Image.FromFile("Clippy_notext.png");
		pictureBox1.Size = new Size(260, 616);
		pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
		pictureBox1.Location = new Point(30, 45);
		this.Controls.Add(pictureBox1);
	}
	
	public void CreateTextBox()
	{
		textBox1 = new TextBox();
		textBox1.AcceptsTab = true;
		textBox1.Font = new Font("Arial", 10);
		textBox1.WordWrap = false;
		textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		textBox1.Size = new Size(950, 600);
		textBox1.Location = new Point(330, 45);
		textBox1.Multiline = true;
		this.Controls.Add(textBox1);
		
	}
	
	// button1 is the "Open..." button
	
	public void MakeOpenButton()
	{
		openFileDialog1 = new OpenFileDialog();
		button1 = new Button();
		button1.Size = new Size(50,23);
		button1.Location = new Point(5,5);
		button1.Text = "Open...";
		button1.Click += new EventHandler(button1_Click);
		this.Controls.Add(button1);
	}
	
	public void button1_Click(object sender, EventArgs e)
	{
		if (openFileDialog1.ShowDialog() == DialogResult.OK)
		{
			using (Stream stream = openFileDialog1.OpenFile())
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					textBox1.Text = reader.ReadToEnd();
				}
			}
		}
	}
	
	// button2 is the "Save" button
	
	public void MakeSaveButton()
	{
		button2 = new Button();
		button2.Size = new Size(40,23);
		button2.Location = new Point(55, 5);
		button2.Text = "Save";
		button2.Click += new EventHandler(button2_Click);
		this.Controls.Add(button2);
	}
	
	public void button2_Click(object sender, EventArgs e)
	{
		saveFileDialog1 = new SaveFileDialog();
		string filePath = openFileDialog1.FileName;
		if (filePath == "")
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter saveStream = new StreamWriter(saveFileDialog1.FileName, false))
				{
					saveStream.Write(textBox1.Text);
				}
			}
		}
		else
		{
			File.WriteAllText(filePath, textBox1.Text);
		}
	}
	
	// button3 is the theme button
	
	public void MakeThemeButton()
	{
		button3 = new Button();
		button3.Text = "Light mode";
		button3.Location = new Point(95, 5);
		button3.Size = new Size(45, 23);
		button3.Click += new EventHandler(button3_Click);
		this.Controls.Add(button3);
	}
	
	public void button3_Click(object sender, EventArgs e)
	{
		if (button3.Text == "Dark mode")
		{
			button3.Text = "Light mode";
			this.BackColor = Color.FromArgb(255,240,240,240);
			button1.BackColor = Color.FromArgb(255, 255, 255, 255);
			button2.BackColor = Color.FromArgb(255, 255, 255, 255);
			button3.BackColor = Color.FromArgb(255, 255, 255, 255);
			button4.BackColor = Color.FromArgb(255, 255, 255, 255);
			textBox1.BackColor = Color.FromArgb(255, 255, 255, 255);
			this.ForeColor = Color.FromArgb(255, 0, 0, 0);
			textBox1.ForeColor = Color.FromArgb(255, 0, 0, 0);
		}
		else if (button3.Text == "Light mode")
		{
			button3.Text = "Dark mode";
			this.BackColor = Color.FromArgb(255, 14, 14, 15);
			button1.BackColor = Color.FromArgb(255, 28, 29, 30);
			button2.BackColor = Color.FromArgb(255, 28, 29, 30);
			button3.BackColor = Color.FromArgb(255, 28, 29, 30);
			button4.BackColor = Color.FromArgb(255, 28, 29, 30);
			textBox1.BackColor = Color.FromArgb(255, 28, 29, 30);
			this.ForeColor = Color.FromArgb(255, 255, 255, 255);
			textBox1.ForeColor = Color.FromArgb(255, 255, 255, 255);
			label1.ForeColor = Color.FromArgb(255, 0, 0, 0);
		}
	}
	
	// button4 is the Clippy button
	
	public void MakeClippyButton()
	{
		button4 = new Button();
		button4.Text = "📎";
		button4.Location = new Point(140, 3);
		button4.Size = new Size(25, 28);
		button4.Click += new EventHandler(button4_Click);
		button4.Font = new Font("Arial", 14);
		this.Controls.Add(button4);
	}
	
	public void button4_Click(object sender, EventArgs e)
	{
		Random rng = new Random();
		int choice = rng.Next(0, 10);
		if (choice == 0)
		{
			DoGexJoke();
		}
		else if (choice == 1)
		{
			HotdogStand();
		}
		else if (choice == 2)
		{
			FakeError();
		}
		else if (choice == 3)
		{
			// DoBonziConversation();
		}
	}
	
	public void DoGexJoke()
	{
		string[] jokes = {"This place is weirder than 4th of July at Rick James' place.", "This place is hotter than Tom Arnold's sauna pants.", "This place is bigger than Drew Carey's bar tab.", "Reminds me of Halloween at Rip Taylor's.", "Don't take career advice from Joe Piscopo."};
		Random rng = new Random();
		string selectedJoke = jokes[rng.Next(0,jokes.Length)];
		label1.Text = selectedJoke;
	}
	
	public void HotdogStand()
	{
		Random rng = new Random();
		string[] clippyComments = {"Yikes.", "My eyes!", "Put on your sunglasses.", "This looks worse than VScode's light mode."};
		string selectedComment = clippyComments[rng.Next(0, clippyComments.Length)];
		this.BackColor = Color.FromArgb(255, 252, 248, 2);
		button1.BackColor = Color.FromArgb(255, 255, 0, 0);
		button1.ForeColor = Color.FromArgb(255, 255, 255, 255);
		button2.BackColor = Color.FromArgb(255, 255, 0, 0);
		button2.ForeColor = Color.FromArgb(255, 255, 255, 255);
		button3.BackColor = Color.FromArgb(255, 255, 0, 0);
		button3.ForeColor = Color.FromArgb(255, 255, 255, 255);
		button4.BackColor = Color.FromArgb(255, 255, 0, 0);
		button4.ForeColor = Color.FromArgb(255, 255, 255, 255);
		textBox1.BackColor = Color.FromArgb(255, 240, 0, 0);
		textBox1.ForeColor = Color.FromArgb(255, 0, 0, 0);
		label1.Text = selectedComment;
	}
	
	public void FakeError()
	{
		Random rng = new Random();
		string[] errList = {"segmentation fault (core dumped)", "Cannot implicitly convert type 'int' to 'string'", "You've been banned from gcc", "Get a job", "The compiler is tired of seeing your terrible code."};
		int index = rng.Next(0, errList.Length);
		MessageBox.Show(errList[index], "Fatal error");
	}
	
	// label1 is Clippy's text
	
	public void CreateClippyText()
	{
        label1 = new Label();
		label1.BackColor = Color.FromArgb(255,255,255,204);
		label1.Parent = pictureBox1;
		label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
		label1.Location = new Point(40, 55);
		label1.Font = new Font("Arial", 18);
		label1.Size = new Size(245, 300);
		label1.Text = "Hi, I'm Clippy! I'm here to help you with writing!";
		label1.BringToFront();
		this.Controls.Add(label1);
	}
	
	// label2 is Bonzi's text
	
	public void CreateBonziText()
	{
		label2 = new Label();
		
	}
}
