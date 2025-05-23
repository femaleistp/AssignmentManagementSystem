namespace AssignmentManagement.Core.Models
{
    public class Assignment
    {
        public Guid Id { get; } = Guid.NewGuid();  // this is fine as read-only

        public string Title { get; private set; } = string.Empty;         
        public string Description { get; private set; } = string.Empty;   
        public bool IsCompleted { get; private set; } = false;        
        public string? Notes { get; private set; } = string.Empty; // Optional field for additional notes

        public Assignment(string title, string description, bool isCompleted = false, string? notes = null)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            Notes = notes;
        }

        public Assignment() { }

        public void Update(string description, bool isCompleted, string? notes)
        {
            Description = description;
            IsCompleted = isCompleted;
            Notes = notes;
        }


    }
}
