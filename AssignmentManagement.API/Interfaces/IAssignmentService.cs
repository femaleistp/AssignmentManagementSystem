using AssignmentManagement.API.Models;  
namespace AssignmentManagement.API.Interfaces
{
    public interface IAssignmentService // Interface for assignment service
    {
        IEnumerable<Assignment> GetAll(); // Get method to retrieve all assignments
        Assignment? GetAssignment(string title); // Get method to retrieve a specific assignment by title
        Assignment Add(Assignment assignment);  // Add method to create a new assignment
        Assignment Update(Assignment assignment); // Update method to modify an existing assignment
        void Delete(string title); // Delete method to remove an assignment by title
    }
}
