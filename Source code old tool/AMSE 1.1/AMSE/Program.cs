using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AMSE
{
    static class Program
    {
        public static SelectBoxItemArrayList Pokeabw1List;
        public static SelectBoxItemArrayList Pokeabw2List;
        public static SelectBoxItemArrayList PokeabwmoveList;

        public static void LoadList()
        {
            Pokeabw1List = OpenCsv("poke_a_bw.csv");
            Pokeabw2List = OpenCsv("poke_a_bw2.csv");
            PokeabwmoveList = OpenCsv("poke_a_move_bw.csv");
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
                string[] strArray2 = strArray[i].Split(new char[] { ';'});
                if (!string.IsNullOrEmpty(strArray2[0]))
                {
                    string[] strArray3 = strArray2[0].Split(new char[] { ',','\t' });
                    list.Add(strArray3[2],strArray3[1], int.Parse(strArray3[0]));
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
