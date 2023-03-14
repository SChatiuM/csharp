using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Authorization
{
	public partial class MainForm : Form
	{
		public MainForm()
		{ InitializeComponent(); }
		
		public static string user="username.txt", psw="password.txt";
		public static int pswlng=5;
		
		void setoffline()
		{
			label3.ForeColor=Color.Red; label3.Text="Offline"; button2.Enabled=false; button1.Enabled=true;
		}
		void setonline()
		{
			label3.ForeColor=Color.Green; label3.Text="Online"; button1.Enabled=false; button2.Enabled=true;
		}
		void denied()
		{
			MessageBox.Show("Access denied");
			setoffline();
		}
		void granted()
		{
			MessageBox.Show("Access granted");
			setonline();
		}
		bool usercheck(TextBox tb)
		{
			StreamReader sr=new StreamReader(user);
			List<string>lst=new List<string>();
			string line;
			while((line=sr.ReadLine())!=null)
				lst.Add(line);
			sr.Close();
			if(lst.Contains(tb.Text)) return true;
			else return false;
		}
		
		bool passcheck()
		{
			if(textBox2.Text.Length<pswlng) return false;
			StreamReader srp=new StreamReader(psw), sru=new StreamReader(user);
			List<string>lstp=new List<string>(), lstu=new List<string>(); List<int>temp=new List<int>();
			string linep, lineu;
			while((linep=srp.ReadLine())!=null)
				lstp.Add(linep);
			srp.Close();
			while((lineu=sru.ReadLine())!=null)
				lstu.Add(lineu);
			sru.Close();
			if(lstp.Contains(textBox2.Text))
			{
				int psword=lstp.IndexOf(textBox2.Text), usrord=lstu.IndexOf(textBox1.Text);
				if(psword==usrord) return true;
				else return false;
			}
			else return false;
		}
		void register()
		{
			if(usercheck(textBox3)==true){ MessageBox.Show("This username is already taken"); goto end; }
			if(textBox4.Text.Length<pswlng){ MessageBox.Show("Insufficient password length\nYou need 5 symbols or more"); goto end; }
			StreamReader sru=new StreamReader(user), srp=new StreamReader(psw);
			StreamWriter swu=new StreamWriter(user), swp=new StreamWriter(psw);
			List<string>lstu=new List<string>(), lstp=new List<string>();
			string lineu, linep;
			while((lineu=sru.ReadLine())!=null)
				lstu.Add(lineu);
			while((linep=sru.ReadLine())!=null)
				lstp.Add(linep);
			sru.Close(); srp.Close();
			lstu.Add(textBox3.Text);
			lstp.Add(textBox4.Text);
			for(int i=0;i<lstu.Count;i++)
				swu.WriteLine(lstu[i]);
			for(int i=0;i<lstp.Count;i++)
				swp.WriteLine(lstp[i]);
			swu.Close(); swp.Close();
			end:;
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			setoffline();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(usercheck(textBox1)==false || passcheck()==false) denied();
			else granted();
		}
		void Button2Click(object sender, EventArgs e)
		{
			setoffline();
		}
		void Button3Click(object sender, EventArgs e)
		{
			register();
		}
	}
}
