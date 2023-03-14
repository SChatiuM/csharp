using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace KrugRandomIgra
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
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
			pictureBox1.BackColor=Color.White;
			pbw=pictureBox1.Width;
			pbh=pictureBox1.Height;
			pbw2=pictureBox1.Width/2;
			pbh2=pictureBox1.Height/2;
			pbwc=pbw2-50;
			pbhc=pbh2-50;
			mp=110;
			tempx=pbwc;
			tempy=pbhc;
		}
		
		int pbw,pbh,pbw2,pbh2,pbwc,pbhc,mp,tempx,tempy;
		
		void PictureBox1Click(object sender, EventArgs e)
		{
			Graphics g=pictureBox1.CreateGraphics();
			g.Clear(Color.White);
			drawTable();
			_drawCenter();
			tempx=pbwc; tempy=pbhc;
			
			int player=0;
			while(tempx>25 && tempx<pbw-50 && tempy>25 && tempy<pbh-50)
			{					
				
				if(player==0 && calcul()==50) { drawDot(tempx,tempy+mp); player++; player%=4; }
				else { player++; player%=4; }
				if(player==1 && calcul()==50) { drawDot(tempx-mp,tempy); player++; player%=4; }
				else { player++; player%=4; }
				if(player==2 && calcul()==50) { drawDot(tempx,tempy-mp); player++; player%=4; }
				else { player++; player%=4; }
				if(player==3 && calcul()==50) { drawDot(tempx+mp,tempy); player++; player%=4; }
				else { player++; player%=4; }

			}

			if(tempx>=25 && tempx<=pbw-50 && tempy<=25) MessageBox.Show("Game over\nTop player loose");
			if(tempx>=pbw-50 && tempy>=25 && tempy<=pbh-50) MessageBox.Show("Game over\nRight player loose");
			if(tempx>=25 && tempx<=pbw-50 && tempy>=pbh-50) MessageBox.Show("Game over\nBottom player loose");
			if(tempx<=25 && tempy>=25 && tempy<=pbh-50) MessageBox.Show("Game over\nLeft player loose");
		}
		
		void drawTable()
		{
			Graphics g=pictureBox1.CreateGraphics();
			
			g.DrawRectangle(Pens.Black,Rectangle.FromLTRB(25,25,pbw-25,pbh-25));
			for(int i=25;i<pbw-25;i+=((pbw-25)/5)-5)
				g.DrawLine(Pens.Black,i,25,i,pbh-25);
			for(int i=25;i<pbh-25;i+=((pbh-25)/5)-5)
				g.DrawLine(Pens.Black,25,i,pbw-25,i);
		}
		void _drawCenter()
		{
			Graphics g=pictureBox1.CreateGraphics();
			g.FillEllipse(Brushes.Red,pbw2-50,pbh2-50,100,100);
		}
		void drawDot(int x,int y)
		{
			Thread.Sleep(100);
			Graphics g=pictureBox1.CreateGraphics();
			g.Clear(Color.White); drawTable();
			g.FillEllipse(Brushes.Red,x,y,100,100);
			tempx=x; tempy=y;
		}
		
		int calcul()
		{
			Random r=new Random();
			return r.Next(0,100);
		}
		
	}
}
