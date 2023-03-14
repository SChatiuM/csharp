using System;
using System.IO;
using System.Collections.Generic;

namespace PassGen
{
	class Program
	{
		public static int numOfSmallChars,numOfBigChars,numOfNumbers;
		public static char[]password;
		public static Random rand=new Random();
		public static string filename="temp.txt",filename2="passwords.txt";
		public static List<string>lst=new List<string>();
		
		public static void Shuffle<T>(T[] arr)
		{
		    for (int i=arr.Length-1;i>=1;i--)
		    {
		        int j=rand.Next(i+1);
		        T tmp=arr[j];
		        arr[j]=arr[i];
		        arr[i]=tmp;
		    }
		}
		
		public static void Normalize(int passLength)
		{
			StreamReader sr=new StreamReader(filename);
			StreamWriter sw=new StreamWriter(filename2);
			string text=sr.ReadToEnd(),line;
			sr.Close();
			int q=0;
			while(q!=text.Length)
			{
				line=text.Substring(q,passLength);
				lst.Add(line);
				q+=passLength;
			}
			for(int i=0;i<lst.Count;i++)
				sw.WriteLine(lst[i]);
			sw.Close();
		}
		
		public static void Main(string[] args)
		{
			displayMessage();
			Console.ReadKey(true);
		}
		
		public static void displayMessage()
    	{
			int passLenght,numOfPasswords;
			Console.WriteLine("Enter the password length to generate: ");
			passLenght=int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the number of passwords to generate: ");
	        numOfPasswords=int.Parse(Console.ReadLine());
	        Console.WriteLine("\n"+"Will be generated {0} passwords length {1} ... ",numOfPasswords,passLenght);
	        StreamWriter sw=new StreamWriter(filename);
			for (int k=0;k<numOfPasswords;k++) 
	            for (int i=0;i<passLenght;++i) 
	            {
	                numOfChars(passLenght);
	                passGenerator(passLenght);
	                sw.Write(password[i]);
	            }
			sw.Close();
			Normalize(passLenght);
	        Console.WriteLine("\n\n"+"Passwords have been successfully generated and written to a file"+"\n");
    	}
		
		public static void passGenerator(int passLenght)
	    {
			password=new char[passLenght];
	        for (int i=0;i<numOfNumbers;++i)
	        	password[i]=(char)(rand.Next()%10+48);
	        for (int i=numOfNumbers;i<numOfNumbers+numOfBigChars;++i)
	        	password[i]=(char)(rand.Next()%26+65);
	        for (int i=numOfNumbers+numOfBigChars;i<passLenght;++i)
	        	password[i]=(char)(rand.Next()%26+97);
	        Shuffle(password);
	    }
		
		public static void numOfChars(int passLenght)
	    {
			numOfSmallChars=rand.Next()%passLenght;
	        int charRandEnd=passLenght-numOfSmallChars;
	        numOfBigChars=rand.Next()%charRandEnd;
	        numOfNumbers=passLenght-numOfSmallChars-numOfBigChars;
	    }
	}
}
