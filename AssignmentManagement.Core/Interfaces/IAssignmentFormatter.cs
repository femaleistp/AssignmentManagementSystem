using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentManagement.Core.Models;

namespace AssignmentManagement.Core.Interfaces
{
    public interface IAssignmentFormatter
    {
        string Format(Assignment assignment);
    }
}
