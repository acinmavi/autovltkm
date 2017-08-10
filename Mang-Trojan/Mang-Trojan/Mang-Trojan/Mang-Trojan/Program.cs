using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SoftwareLocker;

namespace Mang_Trojan
{
    static class Program
    {
        private const string PASSWORD = "123";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TrialMaker t = new TrialMaker("RAT1", Application.StartupPath + "\\RegFile.reg",
               Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RAT.dbf",
               "Phone: +841682699970\nMobile: +84972253758",
                30,7 , PASSWORD);

            byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63,
            4, 54, 87, 56, 123, 10, 3, 62,
            7, 9, 20, 36, 37, 21, 101, 57};
            t.TripleDESKey = MyOwnKey;

            TrialMaker.RunTypes RT = t.ShowDialog();
            bool is_trial;
            if (RT != TrialMaker.RunTypes.Expired)
            {
                if (RT == TrialMaker.RunTypes.Full)
                    is_trial = false;
                else
                    is_trial = true;

                Application.Run(new form.Main(is_trial));
            }
           
            //Application.Run(new form.Main(true));
            
            
        }
    }
}
