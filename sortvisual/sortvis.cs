using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Threading;

namespace SortirovkaVizual
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
			
			pb1=pictureBox1;
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			pictureBox1.BackColor=Color.White;
			button1.Text="Abort";
			button2.Text="Start";
		}
		
		public static Thread th0=new Thread(_process);
		public static PictureBox pb1;
		public static List<int>lst=new List<int>();
		public static double swapcount=0;
		
		public static void _process()
		{
			init();
			Thread.Sleep(1000);
			sort();
			MessageBox.Show("Swap count: "+swapcount.ToString()+"\nElements count: "+lst.Count.ToString());
		}
		
		public static void viz()
		{
			Graphics g=pb1.CreateGraphics();
			
			Pen p=new Pen(Color.Black);
			
			g.Clear(Color.White);
			
			
			int R=255,G=0,B=0;
			for(int i=0;i<lst.Count;i++)
			{	g.DrawLine(new Pen(Color.FromArgb(R,G,B)),i,0,i,lst[i]);	if(i%(pb1.Width/255)==0) R--;	}
		}
		public static void init()
		{
			Random r=new Random();
			for(int i=0;i<pb1.Width;i++)
			{
					loop:
				var a=r.Next(0,pb1.Width);
				if(!lst.Contains(a)) lst.Add(a);
				else goto loop;
			}
			viz();
		}
		public static void sort()
		{
			var array=lst.ToArray();
			for(int i=0;i<array.Length;i++)
			{
				for(int j=0;j<array.Length-1;j++)
					if(array[j]>array[j+1]) Swap(ref array[j],ref array[j+1]);
				lst=array.ToList();
				viz();
			}
		}
		public static void Swap<T>(ref T lhs, ref T rhs)
		{
		    T temp;
		    temp = lhs;
		    lhs = rhs;
		    rhs = temp;
		    swapcount++;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			th0.Abort();
		}
		void Button2Click(object sender, EventArgs e)
		{
			th0.Start();
		}
	}
}
