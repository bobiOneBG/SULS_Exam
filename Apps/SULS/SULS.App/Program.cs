namespace SULS.App
{
    using SIS.MvcFramework;
    using SULS.Data;
    using System;

    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine(DateTime.UtcNow);

            WebHost.Start(new StartUp());
        }
    }
}