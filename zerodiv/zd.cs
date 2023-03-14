using System;
using System.Collections.Generic;

namespace ZeroDiv
{
	class Program
	{
		public static void Main(string[] args)
		{
		begin:
			Console.ForegroundColor=ConsoleColor.Green;
			Console.Clear();
			Console.Write("Введите порядок кольца:"+"\t");
			ulong a=ulong.Parse(Console.ReadLine());
			List<ulong>srtnumb=new List<ulong>(), lst=new List<ulong>();
			for(ulong i=2;i<a;i++) for(ulong j=2;j<a;j++) if((i*j)%a==0) if(!srtnumb.Contains(i)) srtnumb.Add(i); srtnumb.Sort();
			for(ulong i=0;i<a;i++) for(ulong j=0;j<a;j++) if((i*j)%a==1) if(!lst.Contains(i)) lst.Add(i); lst.Sort();
			Console.Write("Делители нуля:"+"\t");
			for(int i=0;i<srtnumb.Count;i++) Console.Write(srtnumb[i]+" ");
			Console.Write("\nZ*: ");
			for(int i=0;i<lst.Count;i++) Console.Write(lst[i]+" ");
			if(Console.ReadKey().Key==ConsoleKey.R) goto begin; else goto end;
		end:
			Console.Clear();
			Console.WriteLine("Для завершения работы программы нажмите любую клавишу...");
			Console.ReadKey(true);
		}
	}
}
