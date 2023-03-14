using System;
using System.Collections.Generic;

class Selector
{
	public static List<string>Variant=new List<string>(){"Rock","Scissors","Paper"};
	public static Random rnd=new Random();
	
	public static string AISelect()
	{
		return Variant[rnd.Next(0,3)];
	}
	
	public static string UISelect(int number)
	{
		string str;
		if(number<0 || number>2)
			str="Error";
		else str=Variant[number];
		return str;
	}
	
	public static bool IsUIWin(string AI,string UI)
	{
		if(AI=="Rock" && UI=="Scissors") return false;
		if(AI=="Scissors" && UI=="Rock") return true;
		if(AI=="Scissors" && UI=="Paper") return false;
		if(AI=="Paper" && UI=="Scissors") return true;
		if(AI=="Paper" && UI=="Rock") return false;
		if(AI=="Rock" && UI=="Paper") return true;
		return false;
	}
}
