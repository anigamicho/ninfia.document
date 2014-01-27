using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AIGT
{
    static class Program
    {
        public static SelectBoxItemArrayList plbw;//pokelist bw
        public static SelectBoxItemArrayList plg4;
        public static SelectBoxItemArrayList ilbw1; //item list1
        public static SelectBoxItemArrayList ilbw2; //item list2
        public static SelectBoxItemArrayList ivl; //ivlist
        public static SelectBoxItemArrayList pgdrl; //gender
        public static SelectBoxItemArrayList pntl; //nature
        public static SelectBoxItemArrayList itrl1; 
        public static SelectBoxItemArrayList itrl2;
        public static SelectBoxItemArrayList itrl3;
        public static SelectBoxItemArrayList itrl4; 

        public static void LoadList()
        {
            Application.EnableVisualStyles();
            bool checking = false;
            if (File.Exists(Application.StartupPath + @"\data\aigt_item1list.csv")&&
                File.Exists(Application.StartupPath + @"\data\aigt_item2list.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_ivlist.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pokelist.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pokelist2.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pgender.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pnature.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist1.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist2.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist3.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist4.csv")
                )
            {
                checking = true;
            }
            else 
            {
                System.Windows.Forms.MessageBox.Show("All or one csv was not found! \r\nApplication will exit.");
                Application.Exit(); 
            }

            if (checking == true)
            {
                ilbw1 = OpenCsv("aigt_item1list.csv");
                ilbw2 = OpenCsv("aigt_item2list.csv");
                ivl = OpenCsv("aigt_ivlist.csv");
                plbw = OpenCsv("aigt_pokelist.csv");
                plg4 = OpenCsv("aigt_pokelist2.csv");
                pgdrl = OpenCsv("aigt_pgender.csv");
                pntl = OpenCsv("aigt_pnature.csv");
                itrl1 = OpenCsv("aigt_trainertradelist1.csv");
                itrl2 = OpenCsv("aigt_trainertradelist2.csv");
                itrl3 = OpenCsv("aigt_trainertradelist3.csv");
                itrl4 = OpenCsv("aigt_trainertradelist4.csv");
            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoadList();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(Application.StartupPath + @"\data\aigt_item1list.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_item2list.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_ivlist.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pokelist.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pokelist2.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pgender.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_pnature.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist1.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist2.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist3.csv") &&
                File.Exists(Application.StartupPath + @"\data\aigt_trainertradelist4.csv")
                )
            {
                if (File.Exists(Application.StartupPath + @"\data\aigt_config.ini"))
                {
                    Application.Run(new Form1());
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("config file was missing, it will using deafult config!");
                    Application.Run(new Form1());
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Some file was not found like csv file or dll file!");
                Application.ExitThread();
            }
        }

        public static SelectBoxItemArrayList OpenCsv(string fileName)
        {
            SelectBoxItemArrayList list = new SelectBoxItemArrayList();
            string[] strArray = File.ReadAllLines(DataDirectory + fileName, Encoding.GetEncoding("UTF-8"));
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strArray2 = strArray[i].Split(new char[] { ';' });
                if (!string.IsNullOrEmpty(strArray2[0]))
                {
                    string[] strArray3 = strArray2[0].Split(new char[] { ',', '\t' });
                    list.Add(strArray3[2], strArray3[1], int.Parse(strArray3[0]), strArray3[3], strArray3[4]);
                }
            }
            return list;
        }

        public static string DataDirectory
        {
            get
            {
                return (StartupPath + @"data\");
            }
        }

        public static string StartupPath
        {
            get
            {
                string startupPath = Application.StartupPath;
                if (!startupPath.EndsWith(@"\"))
                {
                    startupPath = startupPath + @"\";
                }
                return startupPath;
            }
        }

        public static string TempDirectory
        {
            get
            {
                return (StartupPath + @"tmp\");
            }
        }


    }
}
