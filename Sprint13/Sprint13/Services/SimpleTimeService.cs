using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprint13.Services
{
    public class SimpleTimeService : ITimeService
    {
        public string GetTimeForTomorrow()
        {
            return DateTime.Now.AddDays(1).ToString("dd/MM/yyyy");
        }
    }
}
