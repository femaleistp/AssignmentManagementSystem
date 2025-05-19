namespace AssignmentManagement.Core.Models
{
    public class Assignment
    {
        public Guid Id { get; } = Guid.NewGuid();  // this is fine as read-only

        public string Title { get; set; } = string.Empty;         // ✅ MUST have 'set'
        public string Description { get; set; } = string.Empty;   // ✅ MUST have 'set'
        public bool IsCompleted { get; set; } = false;            // ✅ MUST have 'set'
    }
}
