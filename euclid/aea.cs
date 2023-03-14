using System;
using System.Collections.Generic;

namespace RAE
{
	class Program
	{
		public static void Main(string[] args)
		{
			long a=11*(2*12-5),b=23*(12-5),n=15*12-11,p=947,d=24,q=193,x,y,ans=NOD(a,b,out x,out y);
			Console.WriteLine("НОД({0},{1})={2}",a,b,ans);
			
			Console.WriteLine("\nDecomposition coefficients\nfor {0}: {2}\tfor {1}: {3}",a,b,x,y);
			Console.WriteLine("\n"+a+"*"+x+" + "+b+"*"+y+" = "+ans+"\n");
			
			if(ans==1 && x<0){ long revx=x; while(revx<0) revx=revx+p; Console.WriteLine("Inverse element to {0}: {1}={2}(mod{3})",a,x,revx,p); }
			else if(ans==1 && x>p){ long revx=x; while(revx>p) revx=revx-p; Console.WriteLine("Inverse element to {0}: {1}(mod{2})",a,revx,2); }
			else if(ans==1) Console.WriteLine("Inverse element to {0}: {1}(mod{2})",a,x,p);
			
			Console.WriteLine("\nLegendre Symbol: ({0}/{1})={2}",a,p,lej(a,p));
			
			Console.WriteLine("\nx^2={0}(mod{1})",d,q);
			for(int i=0;i<srav(d,q).Count;i++)
				Console.Write("x={0}\t",srav(d,q)[i]);
			
			Console.WriteLine("\n");
			Console.ReadKey(true);
		}
		
		public static long NOD(long a,long b,out long x,out long y)
		{
			if(a==0){ x=0; y=1; return b; }
			long x1,y1,d=NOD(b%a,a,out x1,out y1);
			x=y1-(b/a)*x1; y=x1; return d;
		}
		
		public static double lej(long a,long p)
		{
			double q=1,w=1;
			for(int i=1;i<=((p-1)/2);i++)
			{
				for(int j=1;j<=i;j++)
					q=(q*a)%p;
				w=(w*q)%p;
			}
			if(w==p-1) return -1;
			else return w;
		}
		
		public static List<double> srav(long d,long q)
		{
			List<double>lst=new List<double>();
			for(int i=0;i<q;i++)
			{
				if(Math.Pow(i,2)%q==d) lst.Add(i);
			}
			return lst;
		}
	}
}
