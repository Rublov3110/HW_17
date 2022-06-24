using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HW_17
{
    public class Becap
    {
        private string _pathFile = @"C:\Users\Timmy\OneDrive\Рабочий стол\A-Level\Новая папка\HW_17\Becap\";
        public void WriteBecap()
        {
            DateTime now = DateTime.Now;
            string fileNameDest = _pathFile + "Log_Becap_" + now.ToString("dd_MM_yyyy_hh_mm_ss") + Stopwatch.GetTimestamp() + ".txt";
            File.Copy("log.txt", fileNameDest);
        }
    }
}
