using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;

namespace GrafRed
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}		
		
		public int x_MSD_1, y_MSD_1;
		public Bitmap bmp=new Bitmap(800,600), nbmp=new Bitmap(800,600), obmp=new Bitmap(800,600);
		
		void PictureBox1MouseDown(object sender, MouseEventArgs e)
		{
			x_MSD_1=e.X; p1.x=e.X;
			y_MSD_1=e.Y; p1.y=e.Y;
			obmp=nbmp;
		}

		void PictureBox1MouseMove(object sender, MouseEventArgs e)
		{

			pictureBox1.Image=bmp;
			Graphics g=Graphics.FromImage(bmp);
			

			Pen p=new Pen(colorDialog1.Color,(int)numericUpDown1.Value);
			SolidBrush b =new SolidBrush(colorDialog1.Color);
			

			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Pencil")
			{
				pictureBox1.Image=nbmp;
				bmp=obmp;
				if (e.Button == MouseButtons.Left)
					g.DrawLine(new Pen(colorDialog1.Color,1), x_MSD_1, y_MSD_1, e.X, e.Y);
				x_MSD_1 = e.X;
				y_MSD_1 = e.Y;
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Eraser")
			{
				pictureBox1.Image=nbmp;
				bmp=obmp;
				if(e.Button==MouseButtons.Left)
				{
					g.DrawLine(new Pen(Color.White,(int)numericUpDown1.Value), e.X, e.Y, x_MSD_1, y_MSD_1);
                    x_MSD_1=e.X; y_MSD_1=e.Y;
                    g.FillEllipse(new SolidBrush(Color.White),e.X-((int)numericUpDown1.Value/2),e.Y-((int)numericUpDown1.Value/2),(int)numericUpDown1.Value,(int)numericUpDown1.Value);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Rectangle")
			{	
				bmp = new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
                    if(e.X>x_MSD_1 && e.Y>y_MSD_1)
                    	g.DrawRectangle(p,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
                    else if(e.X<x_MSD_1 && e.Y<y_MSD_1)
                    	g.DrawRectangle(p,e.X,e.Y,x_MSD_1-e.X,y_MSD_1-e.Y);
                    else if(e.X>x_MSD_1 && e.Y<y_MSD_1)
                    	g.DrawRectangle(p,x_MSD_1,e.Y,e.X-x_MSD_1,y_MSD_1-e.Y);
                    else if(e.X<x_MSD_1 && e.Y>y_MSD_1)
                    	g.DrawRectangle(p,e.X,y_MSD_1,x_MSD_1-e.X,e.Y-y_MSD_1);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="FillRectangle")
			{
				bmp = new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
                    if(e.X>x_MSD_1 && e.Y>y_MSD_1)
                    	g.FillRectangle(b,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
                    else if(e.X<x_MSD_1 && e.Y<y_MSD_1)
                    	g.FillRectangle(b,e.X,e.Y,x_MSD_1-e.X,y_MSD_1-e.Y);
                    else if(e.X>x_MSD_1 && e.Y<y_MSD_1)
                    	g.FillRectangle(b,x_MSD_1,e.Y,e.X-x_MSD_1,y_MSD_1-e.Y);
                    else if(e.X<x_MSD_1 && e.Y>y_MSD_1)
                    	g.FillRectangle(b,e.X,y_MSD_1,x_MSD_1-e.X,e.Y-y_MSD_1);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Ellipse")
			{
				bmp = new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					g.DrawEllipse(p,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="FillEllipse")
			{
				bmp = new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
                    g.FillEllipse(b,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Brush")
			{
				pictureBox1.Image=nbmp;
				bmp=obmp;
				if (e.Button==MouseButtons.Left)
                {
                    g.DrawLine(p, e.X, e.Y, x_MSD_1, y_MSD_1);
                    x_MSD_1=e.X; y_MSD_1=e.Y;
                    g.FillEllipse(b,e.X-((int)numericUpDown1.Value/2),e.Y-((int)numericUpDown1.Value/2),(int)numericUpDown1.Value,(int)numericUpDown1.Value);
                }
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Line")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					g.DrawLine(p,x_MSD_1,y_MSD_1,e.X,e.Y);
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Text")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Right)
				{
					string a=richTextBox1.Text;
					g.DrawString(a,fontDialog1.Font,b,new PointF(e.X,e.Y));
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:liniyabrezenhema")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					int x, y, dx, dy;
	            	double f, count;
		            dx = Math.Abs(e.X - x_MSD_1);
		            dy = Math.Abs(e.Y - y_MSD_1);
		            f = dy - dx / 2;
		            x = x_MSD_1;
		            y = y_MSD_1;
		            g.DrawRectangle(p, x, y, 1, 1);
		            if(e.X>x_MSD_1)
		            if (e.Y<y_MSD_1)
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f < 0)
		                        {
		                            y -= 1;
		                            f -= (dy - dx);
		                        }
		
		                        else f -= dy;
		                        x++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f < 0)
		                        {
		                            x += 1;
		                            f -= (dx - dy);
		                        }
		
		                        else f -= dx;
		                        y--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		            }
		            else {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f > 0)
		                        {
		                            y += 1;
		                            f += (dy - dx);
		                        }
		
		                        else f += dy;
		                        x++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f > 0)
		                        {
		                            x += 1;
		                            f = (dx - dy);
		                        }
		
		                        else f = dx;
		                        y++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		            }
		            else
		            if (e.Y < y_MSD_1)
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f < 0)
		                        {
		                            y -= 1;
		                            f -= (dy - dx);
		                        }
		
		                        else f -= dy;
		                        x--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f < 0)
		                        {
		                            x -= 1;
		                            f -= (dx - dy);
		                        }
		
		                        else f -= dx;
		                        y--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		            }
		            else
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f > 0)
		                        {
		                            y += 1;
		                            f += (dy - dx);
		                        }
		
		                        else f += dy;
		                        x--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f > 0)
		                        {
		                            x -= 1;
		                            f = (dx - dy);
		                        }
		
		                        else f = dx;
		                        y++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                    }
		                }
		            }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:okruznostbrezenhema")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					double dx, dy, d, x0, y0, r,x,y;
		            dx = Math.Abs(x_MSD_1 - e.X); dy = Math.Abs(y_MSD_1 - e.Y);
		            if (dx > dy)
		                d = dy;
		            d = dx;
		            x0 = e.X - (e.X - x_MSD_1) / 2;
		            y0 = e.Y - (e.Y - y_MSD_1) / 2;
		            r = d / 2;
		            x = x0;
		           	y =y0+ r+0.5;
		            while(y-y0>=x-x0)
		            {
		                if ((x - x0) * (x - x0) + (y - y0) * (y - y0) - r * r >= 0)
		                 y--;
		                x++;
		                g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                g.DrawRectangle(p, (int)x, (int)(y0 + (y0 - y)), 1, 1);
		                g.DrawRectangle(p, (int)(x0 - (x - x0)), (int)y, 1, 1);
		                g.DrawRectangle(p, (int)(x0 - (x - x0)), (int)(y0 + (y0 - y)), 1, 1);
		                g.DrawRectangle(p, (int)(x0 + (y0 - y)), (int)(y0 + (x - x0)), 1, 1);
		                g.DrawRectangle(p, (int)(x0 + (y0 - y)), (int)(y0 - (x - x0)), 1, 1);
		                g.DrawRectangle(p, (int)(x0 - (y0 - y)), (int)(y0 + (x - x0)), 1, 1);
		                g.DrawRectangle(p, (int)(x0 - (y0 - y)), (int)(y0 - (x - x0)), 1, 1);
		            }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:DDA")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					double dx, dy, x, y, count, x2 = e.X, y2 = e.Y, x1=x_MSD_1, y1=y_MSD_1;
		            x = x_MSD_1; 
		            y = y_MSD_1;
					dx = x2 - x_MSD_1;
		            dy = y2 - y_MSD_1;
		            count = dx;
		            g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		           
		            if(Math.Abs(dx)>Math.Abs(dy))
		            if(dy>0)
		            if (dx>0)
		                while (count > 0)
		                {
		                    count--;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        y++;
		                    x++;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        y++;
		                    x--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
		            else
		                 if (dx > 0)
		                
		                while (count > 0)
		                {
		                    count--;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        y--;
		                    x++;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        y--;
		                    x--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
		
		
		            else
		
		                count = dy;
		            if (dy > 0)
		                if (dx > 0)
		                    while (count > 0)
		                    {
		                        count--;
		                        if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                            x++;
		                        y++;
		                        g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                    }
		                else
		                    while (count > 0)
		                    {
		                        count--;
		                        if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                            x--;
		                        y++;
		                        g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                    }
		            else
		                 if (dx > 0)
		                
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        x++;
		                    y--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        x--;
		                    y--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1);
		                }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:otsechotrez")
			{
				bmp=new Bitmap(nbmp);
				if(e.Button==MouseButtons.Left)
				{
					p2.x=e.X; p2.y=e.Y;
					
					g.DrawLine(p,p1.x,p1.y,p2.x,p2.y);
				}
			}
		}
		
		
		void PictureBox1MouseUp(object sender, MouseEventArgs e)
		{
			
			pictureBox1.Image=nbmp;
			Graphics g=Graphics.FromImage(nbmp);
			
			Font f=fontDialog1.Font;
			Pen p=new Pen(colorDialog1.Color,(int)numericUpDown1.Value);
			Pen invp=new Pen(invert(colorDialog1.Color),(int)numericUpDown1.Value);
			SolidBrush b=new SolidBrush(colorDialog1.Color);
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Rectangle")
			{
				if(e.X>x_MSD_1 && e.Y>y_MSD_1)
                    g.DrawRectangle(p,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
				bmp=nbmp;
                if(e.X<x_MSD_1 && e.Y<y_MSD_1)
                    g.DrawRectangle(p,e.X,e.Y,x_MSD_1-e.X,y_MSD_1-e.Y);
                bmp=nbmp;
                if(e.X>x_MSD_1 && e.Y<y_MSD_1)
                    g.DrawRectangle(p,x_MSD_1,e.Y,e.X-x_MSD_1,y_MSD_1-e.Y);
                bmp=nbmp;
                if(e.X<x_MSD_1 && e.Y>y_MSD_1)
                    g.DrawRectangle(p,e.X,y_MSD_1,x_MSD_1-e.X,e.Y-y_MSD_1);
                bmp=nbmp;
			}

			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="FillRectangle")
			{
                if(e.X>x_MSD_1 && e.Y>y_MSD_1)
                    g.FillRectangle(b,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
                bmp=nbmp;
                if(e.X<x_MSD_1 && e.Y<y_MSD_1)
                    g.FillRectangle(b,e.X,e.Y,x_MSD_1-e.X,y_MSD_1-e.Y);
                bmp=nbmp;
                if(e.X>x_MSD_1 && e.Y<y_MSD_1)
                    g.FillRectangle(b,x_MSD_1,e.Y,e.X-x_MSD_1,y_MSD_1-e.Y);
                bmp=nbmp;
                if(e.X<x_MSD_1 && e.Y>y_MSD_1)
                    g.FillRectangle(b,e.X,y_MSD_1,x_MSD_1-e.X,e.Y-y_MSD_1);
                bmp=nbmp;
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Ellipse")
			{
				g.DrawEllipse(p,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
				bmp=nbmp;
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="FillEllipse")
			{
				g.FillEllipse(b,x_MSD_1,y_MSD_1,e.X-x_MSD_1,e.Y-y_MSD_1);
				bmp=nbmp;
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Text")
			{
				if(e.Button==MouseButtons.Left)
				{
					string a=richTextBox1.Text;
					g.DrawString(a,f,b,new PointF(x_MSD_1,y_MSD_1));
					bmp=nbmp;
				}
			}
			
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Line")
			{
				if(e.Button==MouseButtons.Left)
				{
					g.DrawLine(p,x_MSD_1,y_MSD_1,e.X,e.Y);
					bmp=nbmp;
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:liniyabrezenhema")
			{
				if(e.Button==MouseButtons.Left)
				{
					int x, y, dx, dy;
	            	double f1, count;
		            dx = Math.Abs(e.X - x_MSD_1);
		            dy = Math.Abs(e.Y - y_MSD_1);
		            f1 = dy - dx / 2;
		            x = x_MSD_1;
		            y = y_MSD_1;
		            g.DrawRectangle(p, x, y, 1, 1);
		            bmp=nbmp;
		            if(e.X>x_MSD_1)
		            if (e.Y<y_MSD_1)
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 < 0)
		                        {
		                            y -= 1;
		                            f1 -= (dy - dx);
		                        }
		
		                        else f1 -= dy;
		                        x++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 < 0)
		                        {
		                            x += 1;
		                            f1 -= (dx - dy);
		                        }
		
		                        else f1 -= dx;
		                        y--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		            }
		            else {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 > 0)
		                        {
		                            y += 1;
		                            f1 += (dy - dx);
		                        }
		
		                        else f1 += dy;
		                        x++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 > 0)
		                        {
		                            x += 1;
		                            f1 = (dx - dy);
		                        }
		
		                        else f1 = dx;
		                        y++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		            }
		            else
		            if (e.Y < y_MSD_1)
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 < 0)
		                        {
		                            y -= 1;
		                            f1 -= (dy - dx);
		                        }
		
		                        else f1 -= dy;
		                        x--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 < 0)
		                        {
		                            x -= 1;
		                            f1 -= (dx - dy);
		                        }
		
		                        else f1 -= dx;
		                        y--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		            }
		            else
		            {
		                if (dx > dy)
		                {
		                    count = dx;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 > 0)
		                        {
		                            y += 1;
		                            f1 += (dy - dx);
		                        }
		
		                        else f1 += dy;
		                        x--;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		                else
		                {
		                    count = dy;
		                    while (count > 0)
		                    {
		                        count -= 1;
		                        if (f1 > 0)
		                        {
		                            x -= 1;
		                            f1 = (dx - dy);
		                        }
		
		                        else f1 = dx;
		                        y++;
		                        g.DrawRectangle(p, x, y, 1, 1);
		                        bmp=nbmp;
		                    }
		                }
		            }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:okruznostbrezenhema")
			{
				if(e.Button==MouseButtons.Left)
				{
					double dx, dy, d, x0, y0, r,x,y;
		            dx = Math.Abs(x_MSD_1 - e.X); dy = Math.Abs(y_MSD_1 - e.Y);
		            if (dx > dy)
		                d = dy;
		            d = dx;
		            x0 = e.X - (e.X - x_MSD_1) / 2;
		            y0 = e.Y - (e.Y - y_MSD_1) / 2;
		            r = d / 2;
		            x = x0;
		           	y =y0+ r+0.5;
		            while(y-y0>=x-x0)
		            {
		                if ((x - x0) * (x - x0) + (y - y0) * (y - y0) - r * r >= 0)
		                 y--;
		                x++;
		                g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)x, (int)(y0 + (y0 - y)), 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 - (x - x0)), (int)y, 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 - (x - x0)), (int)(y0 + (y0 - y)), 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 + (y0 - y)), (int)(y0 + (x - x0)), 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 + (y0 - y)), (int)(y0 - (x - x0)), 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 - (y0 - y)), (int)(y0 + (x - x0)), 1, 1); bmp=nbmp;
		                g.DrawRectangle(p, (int)(x0 - (y0 - y)), (int)(y0 - (x - x0)), 1, 1); bmp=nbmp;
		            }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:DDA")
			{
				if(e.Button==MouseButtons.Left)
				{
					double dx, dy, x, y, count, x2 = e.X, y2 = e.Y, x1=x_MSD_1, y1=y_MSD_1;
		            x = x_MSD_1; 
		            y = y_MSD_1;
					dx = x2 - x_MSD_1;
		            dy = y2 - y_MSD_1;
		            count = dx;
		            g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		           
		            if(Math.Abs(dx)>Math.Abs(dy))
		            if(dy>0)
		            if (dx>0)
		                while (count > 0)
		                {
		                    count--;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        y++;
		                    x++;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        y++;
		                    x--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
		            else
		                 if (dx > 0)
		                
		                while (count > 0)
		                {
		                    count--;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        y--;
		                    x++;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        y--;
		                    x--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
		
		
		            else
		
		                count = dy;
		            if (dy > 0)
		                if (dx > 0)
		                    while (count > 0)
		                    {
		                        count--;
		                        if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                            x++;
		                        y++;
		                        g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                    }
		                else
		                    while (count > 0)
		                    {
		                        count--;
		                        if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                            x--;
		                        y++;
		                        g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                    }
		            else
		                 if (dx > 0)
		                
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) > 0)
		                        x++;
		                    y--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
		            else
		                while (count < 0)
		                {
		                    count++;
		                    if ((dy * x - dx * y + dx * y1 - dy * x1) < 0)
		                        x--;
		                    y--;
		                    g.DrawRectangle(p, (int)x, (int)y, 1, 1); bmp=nbmp;
		                }
				}
			}
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="KGIG:otsechotrez")
			{
				if(e.Button==MouseButtons.Left)
				{
					p2.x=e.X; p2.y=e.Y;
					if(cohen_sutherland(re,p1,p2)==0 || cohen_sutherland(re,p1,p2)<0)
					{
						if(cohen_sutherland(re,p1,p2)==0) g.DrawLine(invp,p1.x,p1.y,p2.x,p2.y);bmp=nbmp;
						if(cohen_sutherland(re,p1,p2)<0) g.DrawLine(Pens.Green,p1.x,p1.y,p2.x,p2.y);bmp=nbmp;
					}
				}
			}
		}

		
		void Button1Click(object sender, EventArgs e)
		{
			colorDialog1.ShowDialog();
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{
			Bitmap cls=new Bitmap(800,600);
			Graphics g=Graphics.FromImage(cls);
			g.Clear(Color.White);
			bmp=cls; nbmp=cls; obmp=cls;
		}
		
		
		void Button3Click(object sender, EventArgs e)
		{
			fontDialog1.ShowDialog();
		}

		
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{						
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Pencil")
			   numericUpDown1.Enabled=false;
			else
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="Text")
			{
				richTextBox1.Visible=true;
				numericUpDown1.Enabled=false;
			}
			else 
			
			if(comboBox1.GetItemText(comboBox1.SelectedItem)=="FillRectangle" || comboBox1.GetItemText(comboBox1.SelectedItem)=="FillEllipse")
				numericUpDown1.Enabled=false;
			else {numericUpDown1.Enabled=true; richTextBox1.Visible=false;}
		}
		
		
		void MainFormLoad(object sender, EventArgs e)
		{
			comboBox1.SelectedItem="Cursor";
			button2.PerformClick();
		}
		
		
		void SaveClick(object sender, EventArgs e)
		{
			SaveFileDialog sfd=new SaveFileDialog();
			sfd.Title="Save";
			sfd.OverwritePrompt=true;
			sfd.Filter="Image files (*.bmp)|*.bmp|GrafRedFormat (*.grf)|*.grf|All files (*.*)|*.*";
			sfd.DefaultExt="bmp";
			if(sfd.ShowDialog()==DialogResult.OK)
				nbmp.Save(sfd.FileName);
		}
		
		
		void OpenClick(object sender, EventArgs e)
		{
			Bitmap img;
			OpenFileDialog ofd=new OpenFileDialog();
			ofd.Title="Open";
			ofd.Filter="Image files(*.bmp)|*.bmp|GrafRedFormat (*.grf)|*.grf|All files (*.*)|*.*";
			if(ofd.ShowDialog()==DialogResult.OK)
			{
				img=new Bitmap(ofd.FileName);
				bmp=img;
			}
			nbmp=new Bitmap(bmp);
			pictureBox1.Image=nbmp;
			pictureBox1.Refresh();
		}
		

		
		void DrawRectangleToolStripMenuItemClick(object sender, EventArgs e)
		{
			pictureBox1.Image=bmp;
			Graphics g=Graphics.FromImage(bmp);
			g.DrawRectangle(Pens.Black,100,50,300,250);
			re.x_min=100; re.y_min=50; re.x_max=400; re.y_max=300;
		}
		
		point p1=new point(),p2=new point();
		rect re=new rect();
		public class point
		{
			public int x;
			public int y;
		}

		
		public class rect
		{
			public int x_min;
			public int y_min;
			public int x_max;
			public int y_max;
		}

		public static int cohen_sutherland(rect r, point a, point b)
		{
			int code_a; 
			int code_b;
			int code;
			point c; 
	
			code_a = (((a.x < r.x_min) ? DefineConstants.LEFT : 0) + ((a.x > r.x_max) ? DefineConstants.RIGHT : 0) + ((a.y < r.y_min) ? DefineConstants.BOT : 0) + ((a.y > r.y_max) ? DefineConstants.TOP : 0));
			code_b = (((b.x < r.x_min) ? DefineConstants.LEFT : 0) + ((b.x > r.x_max) ? DefineConstants.RIGHT : 0) + ((b.y < r.y_min) ? DefineConstants.BOT : 0) + ((b.y > r.y_max) ? DefineConstants.TOP : 0));
	
			
			while ((code_a | code_b) != 0)
			{
				
				if ((code_a & code_b) != 0)
				{
					return -1;
				}
	
				
				if (code_a != 0)
				{
					code = code_a;
					c = a;
				}
				else
				{
					code = code_b;
					c = b;
				}
	
				
				if ((code & DefineConstants.LEFT) != 0)
				{
					c.y += (a.y - b.y) * (r.x_min - c.x) / (a.x - b.x);
					c.x = r.x_min;
				}
				else if ((code & DefineConstants.RIGHT)!=0)
				{
					c.y += (a.y - b.y) * (r.x_max - c.x) / (a.x - b.x);
					c.x = r.x_max;
				} 
				else if ((code & DefineConstants.BOT)!=0)
				{
					c.x += (a.x - b.x) * (r.y_min - c.y) / (a.y - b.y);
					c.y = r.y_min;
				}
				else if ((code & DefineConstants.TOP)!=0)
				{
					c.x += (a.x - b.x) * (r.y_max - c.y) / (a.y - b.y);
					c.y = r.y_max;
				}
	
				
				if (code == code_a)
				{
					a = c; 
					code_a = (((a.x < r.x_min) ? DefineConstants.LEFT : 0) + ((a.x > r.x_max) ? DefineConstants.RIGHT : 0) + ((a.y < r.y_min) ? DefineConstants.BOT : 0) + ((a.y > r.y_max) ? DefineConstants.TOP : 0));
				}
				else
				{
								b = c;
					code_b = (((b.x < r.x_min) ? DefineConstants.LEFT : 0) + ((b.x > r.x_max) ? DefineConstants.RIGHT : 0) + ((b.y < r.y_min) ? DefineConstants.BOT : 0) + ((b.y > r.y_max) ? DefineConstants.TOP : 0));
				}
			}
	
			return 0;
		}
		
		internal static class DefineConstants
		{
			public const int LEFT = 1; 
			public const int RIGHT = 2; 
			public const int BOT = 4; 
			public const int TOP = 8; 
		}
		
		public Color invert(Color c)
		{
		  return Color.FromArgb(c.A, 0xFF - c.R, 0xFF - c.G, 0xFF - c.B);
		}
	}
}
