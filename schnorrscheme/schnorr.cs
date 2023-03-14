using System;
using System.Collections.Generic;

namespace Shnorr
{
	class Program
	{
		public static void Main(string[] args)
		{
				begin:
			Console.Clear();
			int start=1000,p,q,alpha,a,r,x,y;
			double beta,gamma,srv;
			bool istrue=true;
			nmb(start);
			p=prime[rnd.Next(0,prime.Count)];
			q=PrimeDiv(p-1);
			foralpha(p,q);
			if(alphas.Count==0)goto begin;
			alpha=alphas[rnd.Next(0,alphas.Count)];
			if(q-2<=1)goto begin;
			a=rnd.Next(1,q-2);
			beta=Math.Pow(Rev(alpha,p),a)%p;
			r=rnd.Next(1,q-2);
			gamma=Math.Pow(alpha,r)%p;
			x=rnd.Next(1,q-1);
			y=(a*x+r)%p;
			srv=(Math.Pow(alpha,y)%p*Math.Pow(beta,x)%p)%p;
			if(gamma==srv) istrue=true;
			else istrue=false;
			
			Console.WriteLine("p={0}\tq={1}\talpha={2}\ta={3}\tbeta={4}\nr={5}\tgamma={6}\tx={7}\ty={8}\n{9}\n{10}",p,q,alpha,a,beta,r,gamma,x,y,srv,istrue);
			
			Console.ReadKey(true);
		}
		
		public static List<int>prime=new List<int>(), alphas=new List<int>();
		public static Random rnd=new Random();
		
		public static void nmb(int a)
		{
			for(int i=2;i<a;i++)
				if(IsPrime(i)) prime.Add(i);
		}
		
		public static bool IsPrime(int a)
		{
			bool flag=true;
            for (int i = 2; i < a; i++)
                if (a % i == 0) flag = false;
			return flag;
		}
		
		public static int PrimeDiv(int a)
		{
				loop:
			int q=prime[rnd.Next(0,prime.IndexOf(a+1))];
			if(a%q==0) return q;
			else goto loop;
		}
		
		public static void foralpha(int mod, int q)
		{
			for(int i=0;i<mod;i++)
				for(int j=1;j<q;j++)
					if(Math.Pow(i,j)%mod!=1 && Math.Pow(i,q)%mod==1) if(!alphas.Contains(i)) alphas.Add(i);
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
