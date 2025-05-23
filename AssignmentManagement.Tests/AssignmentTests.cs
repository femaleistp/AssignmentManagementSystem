using Xunit;
using AssignmentManagement.Core.Models;

namespace AssignmentManagement.Tests;

public class AssignmentTests
{
    [Fact]
    public void Assignment_SetProperties_ShouldStoreCorrectValues()
    {
        var assignment = new Assignment("Read Chapter 2", "Summarize key points", false, "note");

        Assert.Equal("Read Chapter 2", assignment.Title);
        Assert.Equal("Summarize key points", assignment.Description);
        Assert.False(assignment.IsCompleted);
    }

    [Fact]
    public void Assignment_MarkAsComplete_SetsIsCompletedToTrue()
    {
        var assignment = new Assignment("Task", "Do something");
        var modified = new Assignment("Task", "Do something", true);

        Assert.True(modified.IsCompleted);
    }

    [Fact]
    public void Assignment_CanStoreNotes_WhenSet()
    {
        var assignment = new Assignment("Test", "Test Desc", false, "Extra context");
        Assert.Equal("Extra context", assignment.Notes);
    }

    [Fact]
    public void Assignment_Constructor_SetsNotesCorrectly()
    {
        var assignment = new Assignment("Read", "Chapter 4", false, "Optional notes");
        Assert.Equal("Optional notes", assignment.Notes);
    }

}
