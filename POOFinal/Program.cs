namespace POOFinal
{
    using System;
    using System.Text.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;


     public class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}