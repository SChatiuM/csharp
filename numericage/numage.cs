using System;
using System.Collections.Generic;
using System.Numerics;
using System.Linq;

namespace NumericAge //277777788888899 is 11 age
{
	class Program
	{
		public static void Main(string[] args)
		{
			loop:
						
			for(BigInteger a=BigInteger.Pow(277777788888899,100);a<=BigInteger.Multiply((BigInteger)double.MaxValue,(BigInteger)double.MaxValue);a++)
			{
					lst=a.ToString().ToList();
					Console.WriteLine(a);
					MulAge(lst);
					Obnul();
					Console.WriteLine();
			}
			
		}
		
		public static BigInteger number;
		public static List<char>lst=new List<char>();
		public static ulong Result=0;
		
		public static void Zapoln()
		{
			GetFakeRandomWithoutZero();
			string nmbr=number.ToString();
			lst=nmbr.ToList();
		}
		
		public static void Obnul()
		{
			Result=0;
		}
		
		public static void GetFakeRandomWithoutZero()
		{
			loop:
			
			number=BigInteger.Multiply((new Random().Next()),(new Random().Next()));
			string str=number.ToString();
			if(str.Contains("0")) goto loop;
		}
		
		public static void MulAge(List<char>a)
		{
			BigInteger NextNumber=1;
			for(int i=0;i<a.Count;i++)
				NextNumber*=BigInteger.Parse(a[i].ToString());
			Result++;
			Console.WriteLine(Result+"\t"+NextNumber);
			string str=NextNumber.ToString();
			lst=str.ToList();
			if(lst.Count!=1) MulAge(lst);
		}
		
		public static void AddAge(List<char>a)
		{
			BigInteger NextNumber=0;
			for(int i=0;i<a.Count;i++)
				NextNumber+=BigInteger.Parse(a[i].ToString());
			Result++;
			Console.WriteLine(Result+"\t"+NextNumber);
			string str=NextNumber.ToString();
			lst=str.ToList();
			if(lst.Count!=1) AddAge(lst);
		}
	}
}
