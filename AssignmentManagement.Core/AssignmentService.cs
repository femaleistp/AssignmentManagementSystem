using System.Collections.Generic;

namespace AssignmentLibrary;

public class AssignmentService
{
    private readonly List<Assignment> assignments = new();

    public void AddAssignment(Assignment assignment)
    {
        assignments.Add(assignment);
    }

    public List<Assignment> ListAll()
    {
        return new List<Assignment>(assignments);
    }

    public List<Assignment> ListIncomplete()
    {
        return assignments.Where(a => !a.IsCompleted).ToList();

        // notes: prior attempts below, not deleting to reference later 

        // TODO done: Return only assignments where IsCompleted is false

        //List<Assignment> incompleteAssignments = new List<Assignment>();

        //foreach (Assignment a in assignments)
        //{
        //    if (!a.IsCompleted)
        //    {
        //        incompleteAssignments.Add(a);
        //    }
        //}

        //return incompleteAssignments;

        //return new List<Assignment>(assignments.Where(a=>!a.IsCompleted));

    }
}
