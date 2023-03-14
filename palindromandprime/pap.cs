using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Palindrom
{
	class Program
	{
		public static void th0(object o)
		{
			int N=(int)o;
			Numb(N);
		}
		
		public static void th1()
		{
			for(int i=0;i<Numbers.Count;i++)
				if(IsPrime(Numbers[i])) Primes.Add(Numbers[i]);
		}
		
		public static void th2()
		{
			for(int i=0;i<Primes.Count;i++)
				if(IsPal(Primes[i])) Palindroms.Add(Primes[i]);
			for(int i=0;i<Palindroms.Count;i++)
				Console.WriteLine(Palindroms[i]);
		}
		
		public static void Main(string[] args)
		{
			Console.Write("N=");
			int N=int.Parse(Console.ReadLine());
			
			Numb(N);
			for(int i=0;i<Numbers.Count;i++)
				if(IsPrime(Numbers[i])) Primes.Add(Numbers[i]);
			for(int i=0;i<Primes.Count;i++)
				Console.WriteLine(Primes[i]);
			for(int i=0;i<Primes.Count;i++)
				if(IsPal(Primes[i])) Palindroms.Add(Primes[i]);
			for(int i=0;i<Palindroms.Count;i++)
				Console.WriteLine(Palindroms[i]);
			
			thr0=new Thread(th0); thr1=new Thread(th1); thr2=new Thread(th2);
			
			Console.ReadKey(true);
		}
		
		public static List<int> Numbers=new List<int>(),Primes=new List<int>(),Palindroms=new List<int>();
		public static Thread thr0,thr1,thr2;
		
		public static void Numb(int N)
		{
			for(int i=2;i<=N;i++)
				Numbers.Add(i);
		}
		
		public static bool IsPrime(int a)
		{
			bool flag=true;
			for(int i=2;i<a;i++)
				if(a%i==0) flag=false;
			return flag;
		}
		
		public static bool IsPal(int a)
		{
			string number=a.ToString();
			string reversal=new string(number.ToCharArray().Reverse().ToArray());
			if(number==reversal) return true; else return false;
		}
	}
}
