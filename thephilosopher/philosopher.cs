using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
 
namespace ConsoleApplication2
{
    class Program
    {
        static List<Fork> fork = new List<Fork>();
        static List<Philosopher> ph = new List<Philosopher>();
 
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
                fork.Add(new Fork());
            for (int i = 0; i < 5; i++)
                ph.Add(new Philosopher((i + 1).ToString(), i));
 
            Thread t1 = new Thread(ph[0].Start);
            Thread t2 = new Thread(ph[1].Start);
            Thread t3 = new Thread(ph[2].Start);
            Thread t4 = new Thread(ph[3].Start);
            Thread t5 = new Thread(ph[4].Start);
 
            t1.Start(fork);
            t2.Start(fork);
            t3.Start(fork);
            t4.Start(fork);
            t5.Start(fork);
        }
    }
 
    public class Philosopher
    {
        bool isHunger = false;
        string philosopherName;
        int number;
        bool isDeath = false;
 
        public Philosopher(string Name, int number)
        {
            philosopherName = Name;
            this.number = number;
        }
 
        void GetFork(List<Fork> fork)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimer);
            timer.Interval = 3000;
            Console.WriteLine("Philosopher {0} waiting forks", philosopherName);
            timer.Start();
            Monitor.Enter(fork);
            try
            {
                if (isDeath)
                    return;
                int first = number;
                int second = (number == fork.Count - 1) ? 0 : number + 1;
                if (!fork[first].IsUsing && !fork[second].IsUsing)
                {
                    Console.WriteLine("Philosopher {0} getting forks ({1})", philosopherName, timer.Enabled);
                    timer.Stop();
                    timer.Dispose();
                    fork[first].IsUsing = true;
                    fork[second].IsUsing = true;
                    Console.WriteLine("Philosopher {0} eating.", philosopherName);
                    Console.WriteLine("Forks with numbers {0} and {1} are using.", first + 1, second + 1);
                    Thread.Sleep(250);
                    fork[first].IsUsing = false;
                    fork[second].IsUsing = false;
                }
            }
            finally
            {
                Monitor.Exit(fork);
            }
        }
 
        void OnTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("AAAAAAAA!!!!!!!!!\n Philosopher {0} is death!!!!!!!! T_T", philosopherName);
            Console.ResetColor();
            isDeath = true;
            ((System.Timers.Timer)sender).Stop();            
        }
 
        public void Start(object obj)
        {
            while (true)
            {
                Thread.Sleep(2000 + number * 1000);
                ChangeStatus();
                if (isHunger)
                    GetFork((List<Fork>)obj);
                if (isDeath)
                {
                    return;
                }
            }
        }
 
        void ChangeStatus()
        {
            isHunger = !isHunger;
            if (!isHunger)
                Console.WriteLine("Philosopher {0} thinking.", philosopherName);
        }
    }
 
    public class Fork
    {
        bool isUsing = false;
 
        public bool IsUsing 
        {
            get { return isUsing; }
            set { isUsing = value; }
        }
    }
}
