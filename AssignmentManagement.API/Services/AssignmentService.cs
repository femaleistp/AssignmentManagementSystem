using AssignmentManagement.API.Interfaces;
using AssignmentManagement.API.Models;

namespace AssignmentManagement.API.Services
{
    public class AssignmentService : IAssignmentService
    {

        private readonly List<Assignment> _assignments = new List<Assignment>();

        public IEnumerable<Assignment> GetAll()
        {
            return _assignments;
        }

        public Assignment? GetAssignment(string title)
        {
            return _assignments.FirstOrDefault(a => a.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }   

        public Assignment Add(Assignment assignment)
        {
            _assignments.Add(assignment);
            return assignment;
        }   

        public Assignment? Update(Assignment assignment)
        {
            var existingAssignment = GetAssignment(assignment.Title);
            if (existingAssignment != null)
            {
                existingAssignment.Description = assignment.Description;
                existingAssignment.IsCompleted = assignment.IsCompleted;
                return existingAssignment;
            }
            return null;
        }

        public void Delete(string title)
        {
            var assignment = GetAssignment(title);
            if (assignment != null)
            {
                _assignments.Remove(assignment);
            }
        }


    }
}
