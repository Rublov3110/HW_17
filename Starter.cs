using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_17
{
    public class Starter
    {
        private Logger _logger;
        private Becap _becap;
        public Starter()
        {
            _logger = new Logger();
            _becap = new Becap();
            _logger.DoBecapEvent += OnDoBecap;
        }

        public async void WriteMetodAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                string method1 = "Metod1" + " " + i;
                await _logger.WriteFileAsync(method1);
                string method2 = "Method2" + " " + i;
                await _logger.WriteFileAsync(method2);
            }
        }

        public void OnDoBecap()
        {
            _becap.WriteBecap();
        }
    }
}
