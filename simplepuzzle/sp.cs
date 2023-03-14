using System;
using System.Windows.Forms;

namespace SimplePuzzle
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			int param;
			textBox1.Visible=true;
			if(textBox1.Text=="CodeWord") param=1;
			else if(textBox1.Text=="STEAM") param=2;
			else if(textBox1.Text=="Quake III: Team Arena") param=3;
			else if(textBox1.Text=="PSP") param=4;
			else if(textBox1.Text=="GTA 3") param=5;
			else param=0;
			if(param==1) { MessageBox.Show("Ok. First part is complete."+"\n"+"Now you need to study the secret inscriptions in previously unknown text documents...");
				System.IO.File.AppendAllText("C:\\qwe.txt","Vmxab1YyRkhSWGxXVjJSVVZsZDRTMVF5Ykhwa1IxWm9ZbGRPZG1KWE1URmliV3d3WlZNMWFtSXlN VU5XVm5CWVVtNVNTbEpWV2pWWCBiR014WVVFOVBRPT0="); }
			if(param==2) MessageBox.Show("Great! You solved it."+"\n"+"But you sure you didn't miss anything? ;-)");
			if(param==3) { MessageBox.Show("Well done, you found the secret! Or not?!");
				System.IO.File.AppendAllText("C:\\qwe.txt","\n"+"Hello again!"); }
			if(param==4) { MessageBox.Show("An easter egg!");
				System.IO.File.AppendAllText("C:\\qwe.txt","\n"+"WW91IHdlcmVudCBzdXBwb3NlZCB0byBiZSBhYmxlIHRvIGdldCBoZXJlIHlvdSB"); }
			if(param==5) MessageBox.Show("Well well well, somebody like to find a secrets. Good job!");
		}
		
		//Code words: CodeWord | STEAM | Quake III: Team Arena | PSP | GTA 3
		
		void MainFormLoad(object sender, EventArgs e)
		{
			textBox1.Visible=false;
		}
	}
}
