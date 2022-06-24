using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HW_17
{
    public class Logger
    {
        private int _logsMadeAmoutn = 0;
        private int _nBacap;
        private StringBuilder _log;
        private string _pathFile = @"C:\Users\Timmy\OneDrive\Рабочий стол\A-Level\Новая папка\HW_17\File\log.txt";

        public Logger()
        {
            var configFile = File.ReadAllText(@"C:\Users\Timmy\OneDrive\Рабочий стол\A-Level\Новая папка\HW_17\Config\config.json");
            var config = JsonConvert.DeserializeObject<Config>(configFile);
            int? nLimit = config?.Logger?.Limit;
            _nBacap = nLimit.GetValueOrDefault();
            _log = new StringBuilder();
        }

        public delegate void DoBecapHandler();
        public event DoBecapHandler? DoBecapEvent;

        public async Task WriteFileAsync(string method)
        {
           _log.AppendLine(method);
           Console.WriteLine(method);
           await Task.Run(() => File.WriteAllText(_pathFile, _log.ToString()));
           _logsMadeAmoutn++;
           if (_logsMadeAmoutn == _nBacap)
            {
                DoBecap();
                _logsMadeAmoutn = 0;
            }
        }

        public void DoBecap()
        {
            DoBecapEvent?.Invoke();
        }
    }
}
