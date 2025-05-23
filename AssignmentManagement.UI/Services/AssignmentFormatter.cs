using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssignmentManagement.Core.Models;
using AssignmentManagement.Core.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace AssignmentManagement.UI.Services
{
    public class AssignmentFormatter : IAssignmentFormatter
    {
        public string Format(Assignment assignment)
        {
            return $"Assignment ID: {assignment.Id}\n" +
                   $"Title: {assignment.Title}\n" +
                   $"Description: {assignment.Description}\n" +
                   $"Notes: {assignment.Notes}\n" +
                   $"Status: {(assignment.IsCompleted ? "Completed" : "Incompleted")}\n";
        }
    }
}
