using Xunit;
using AssignmentManagement.Core.Models;

namespace AssignmentManagement.Tests;

public class AssignmentTests
{
    [Fact]
    public void Assignment_SetProperties_ShouldStoreCorrectValues()
    {
        var assignment = new Assignment
        {
            Title = "Read Chapter 2",
            Description = "Summarize key points",
            IsCompleted = false
        };

        Assert.Equal("Read Chapter 2", assignment.Title);
        Assert.Equal("Summarize key points", assignment.Description);
        Assert.False(assignment.IsCompleted);
    }

    [Fact]
    public void Assignment_MarkAsComplete_SetsIsCompletedToTrue()
    {
        var assignment = new Assignment
        {
            Title = "Task",
            Description = "Do something",
            IsCompleted = false
        };

        assignment.IsCompleted = true;

        Assert.True(assignment.IsCompleted);
    }
}
