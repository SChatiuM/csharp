using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace RPSForm
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			UICount=0; AICount=0;
			SetScore();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public static string UIChoise, AIChoise;
		public static ulong UICount, AICount;
		
		void Button1Click(object sender, EventArgs e)
		{
			UIChoise="Rock";
			pictureBox1.BackgroundImage=imageList1.Images[0];
			Checking();
		}
		void Button2Click(object sender, EventArgs e)
		{
			UIChoise="Scissors";
			pictureBox1.BackgroundImage=imageList1.Images[1];
			Checking();
		}
		void Button3Click(object sender, EventArgs e)
		{
			UIChoise="Paper";
			pictureBox1.BackgroundImage=imageList1.Images[2];
			Checking();
		}
		
		void Checking()
		{
			AIChoise=Selector.AISelect();
			AIPicturing();
			if(UIChoise!=AIChoise)
				if(Selector.IsUIWin(AIChoise,UIChoise))
					{ label3.ForeColor=Color.Green; label3.Text="UI is winner"; UICount++; }
				else { label3.ForeColor=Color.Red; label3.Text="AI is winner"; AICount++; }
			else { label3.ForeColor=Color.Magenta; label3.Text="Drawn game"; }
			SetScore();
		}
		
		void AIPicturing()
		{
			if(AIChoise=="Rock") pictureBox2.BackgroundImage=imageList1.Images[0];
			if(AIChoise=="Scissors") pictureBox2.BackgroundImage=imageList1.Images[1];
			if(AIChoise=="Paper") pictureBox2.BackgroundImage=imageList1.Images[2];
		}
		
		void SetScore()
		{
			label1.Text=String.Format("UI:\t{0}",UICount);
			label2.Text=String.Format("{0}\t:AI",AICount);
		}
	}
}
