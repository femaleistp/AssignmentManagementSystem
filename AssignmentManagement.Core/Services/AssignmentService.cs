using AssignmentManagement.Core.Interfaces;
using AssignmentManagement.Core.Models;

namespace AssignmentManagement.Core.Services
{
    public class AssignmentService : IAssignmentService
    {

        private readonly List<Assignment> _assignments = new List<Assignment>();
        private readonly IAssignmentFormatter _formatter;
        private readonly IAppLogger _logger;

        public AssignmentService(IAppLogger logger, IAssignmentFormatter formatter)
        {
            _logger = logger;
            _formatter = formatter;
        }


        public IEnumerable<Assignment> GetAll()
        {
            return _assignments;
        }

        public Assignment? GetAssignment(Guid id)
        {
            return _assignments.FirstOrDefault(a => a.Id.Equals(id));
        }   

        public Assignment Add(Assignment assignment)
        {
            _assignments.Add(assignment);
            _logger.Log($"Added: {_formatter.Format(assignment)}");
            return assignment;
        }   

        public Assignment? Update(Assignment assignment)
        {
            var existingAssignment = GetAssignment(assignment.Id);
            if (existingAssignment != null)
            {
                existingAssignment.Description = assignment.Description;
                existingAssignment.IsCompleted = assignment.IsCompleted;
                _logger.Log($"Updated: {_formatter.Format(existingAssignment)}");
                return existingAssignment;
            }
            return null;
        }

        public void Delete(Guid id)
        {
            var assignment = GetAssignment(id);
            if (assignment != null)
            {
                _assignments.Remove(assignment);
                _logger.Log($"Deleted: {_formatter.Format(assignment)}");
            }
        }


    }
}
