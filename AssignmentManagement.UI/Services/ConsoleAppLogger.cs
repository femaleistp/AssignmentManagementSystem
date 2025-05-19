using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentManagement.Core.Interfaces;

namespace AssignmentManagement.UI.Services
{
    public class ConsoleAppLogger : IAppLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}
