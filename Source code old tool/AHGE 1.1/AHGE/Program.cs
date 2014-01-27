using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Percobaan
{
    internal static class Program
    {
        public static SelectBoxItemArrayList PokeList;
        public static SelectBoxItemArrayList loc1List;
        public static SelectBoxItemArrayList ItemList;

        public static void LoadList()
        {
            PokeList = OpenCsv("Poke_2_bw_hdgr.csv");
            ItemList = OpenCsv("Item_bw2.csv");
            loc1List = OpenCsv("Locate_bw2_1.csv");
        }
        [STAThread]
        static void Main()
        {
            LoadList();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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
                    list.Add(strArray3[1], int.Parse(strArray3[0]), strArray3[2]);
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
