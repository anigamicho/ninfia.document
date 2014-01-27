using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace APSV
{
    static class Program
    {
        public static SelectBoxItemArrayList PokeList;
        public static SelectBoxItemArrayList itemlist;
        public static SelectBoxItemArrayList movelist;
        public static SelectBoxItemArrayList naturelist;

        public static void LoadList()
        {
            PokeList = OpenCsv("apse_pokelist.csv");
            itemlist = OpenCsv("apse_item2list.csv");
            movelist = OpenCsv("apse_move.csv");
            naturelist = OpenCsv("apse_pnature.csv");
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
                    list.Add(strArray3[1], int.Parse(strArray3[0]));
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
