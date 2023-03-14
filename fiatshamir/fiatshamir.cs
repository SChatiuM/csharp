using System;
using System.Collections.Generic;

namespace FiatShamir
{
	class Program
	{
		public static void Main(string[] args)
		{
			int start=1000,p,q,n,a,r,x;
			double b,gamma,y,srv;
			bool istrue=true;
			nmb(start);
			p=lst[rnd.Next(0,lst.Count)];
			q=lst[rnd.Next(0,lst.Count)];
			n=p*q;
			a=A(n);
			if(a==0){Console.WriteLine("Error in calculation a");goto end;}
			b=Math.Pow(Rev(a,n),2)%n;
			r=rnd.Next(1,n-1);
			gamma=Math.Pow(r,2)%n;
			x=rnd.Next(0,1);
			y=(r*Math.Pow(a,x))%n;
			srv=(Math.Pow(y,2)*Math.Pow(b,x))%n;
			if(srv==gamma)istrue=true;
			else istrue=false;
			
			Console.WriteLine("p={0}\tq={1}\tn={2}\na={3}\tb={4}\nr={5}\tgamma={6}\tx={7}\ty={8}\n{9}\n{10}",p,q,n,a,b,r,gamma,x,y,srv,istrue);
			
				end:
			Console.ReadKey(true);
		}
		
		public static List<int> lst=new List<int>();
		public static Random rnd=new Random();
		
		public static void nmb(int a)
		{
			for(int i=2;i<a;i++)
				if(IsPrime(i)) lst.Add(i);
		}
		
		public static bool IsPrime(int a)
		{
			bool flag=true;
            for (int i = 2; i < a; i++)
                if (a % i == 0) flag = false;
			return flag;
		}
		
		public static int A(int n)
		{
			int x,y,i;
			i=rnd.Next(1,n);
			if(NOD(i,n,out x,out y)==1) return i;
			return 0;
		}
		
		public static int NOD(int a,int b,out int x,out int y)
		{
			if(a==0){ x=0; y=1; return b; }
			int x1,y1,d=NOD(b%a,a,out x1,out y1);
			x=y1-(b/a)*x1; y=x1; return d;
		}
		
		public static int Rev(int a,int p)
		{
			int revr=0;
			for(int i=0;i<p;i++)
				if((Math.BigMul(a,i))%p==1) revr=i;
			return revr;
		}
	}
}
