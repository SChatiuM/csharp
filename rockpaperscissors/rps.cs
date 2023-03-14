using System;
using System.Collections.Generic;

namespace RPS
{
	class Program
	{
		public static void Main(string[] args)
		{
			begin:
			Console.ForegroundColor=ConsoleColor.Yellow; Console.WriteLine("Select an item: 0-Rock, 1-Scissors, 2-Paper, Exit-to exit"); Console.ResetColor();
			string a=Console.ReadLine();
			int aa;
			bool bl=int.TryParse(a,out aa);
			if(bl)
			{ 
				string AI=Selector.AISelect(),UI=Selector.UISelect(aa);
				Console.WriteLine("AI choose:\t{0}\nUI choose:\t{1}",AI,UI);
				if(AI==UI) { Console.ForegroundColor=ConsoleColor.Blue; Console.WriteLine("Drawn"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Rock" && UI=="Scissors") { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("AI won"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Scissors" && UI=="Rock") { Console.ForegroundColor=ConsoleColor.Green; Console.WriteLine("UI won"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Scissors" && UI=="Paper") { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("AI won"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Paper" && UI=="Scissors") { Console.ForegroundColor=ConsoleColor.Green; Console.WriteLine("UI won"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Paper" && UI=="Rock") { Console.ForegroundColor=ConsoleColor.Red; Console.WriteLine("AI won"+"\n"); Console.ResetColor(); goto begin; }
				if(AI=="Rock" && UI=="Paper") { Console.ForegroundColor=ConsoleColor.Green; Console.WriteLine("UI won"+"\n"); Console.ResetColor(); goto begin; }
			}
			if(a=="exit" || a=="Exit") goto end;
			Console.ForegroundColor=ConsoleColor.Magenta; Console.WriteLine("Not aviable"+"\n"); Console.ResetColor(); goto begin;
			end:;
		}
	}
}
