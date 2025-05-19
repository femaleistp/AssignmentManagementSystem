using AssignmentManagement.Core.Models;  
namespace AssignmentManagement.Core.Interfaces
{
    public interface IAssignmentService // Interface for assignment service
    {
        IEnumerable<Assignment> GetAll(); // Get method to retrieve all assignments
        Assignment? GetAssignment(Guid id); // Get method to retrieve a specific assignment by Guid
        Assignment Add(Assignment assignment);  // Add method to create a new assignment
        Assignment? Update(Assignment assignment); // Update method to modify an existing assignment
        void Delete(Guid id); // Delete method to remove an assignment by Guid
    }
}
