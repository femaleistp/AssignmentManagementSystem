using Xunit;
using AssignmentLibrary;

namespace AssignmentLibrary.Tests;

public class AssignmentServiceTests
{
    [Fact]
    public void ListIncomplete_ShouldReturnOnlyAssignmentsThatAreNotCompleted()
    {
        // Arrange
        var service = new AssignmentService();
        var a1 = new Assignment("Incomplete Task", "Do something");
        var a2 = new Assignment("Completed Task", "Do something else");
        a2.MarkComplete();

        service.AddAssignment(a1);
        service.AddAssignment(a2);

        // Act
        var result = service.ListIncomplete();

        // Assert
        // This will fail until students implement ListIncomplete()
        Assert.Single(result);
        Assert.Equal("Incomplete Task", result[0].Title);
    }

    [Fact]
    public void ListIncomplete_WhenNoAssignments_ShouldReturnEmptyList()
    {
        // Arrange
        var service = new AssignmentService();

        // Act
        var result = service.ListIncomplete();

        //Assert
        Assert.Empty(result);
    }

    [Fact]
    public void ListIncomplete_WhenAllAssignmentsCompleted_ShouldReturnEmptyList()
    {
        // Arrange
        var service = new AssignmentService();
        var a1 = new Assignment("Completed Task 1", "Do something");
        var a2 = new Assignment("Completed Task 2", "Do something else");

        a1.MarkComplete();
        a2.MarkComplete();

        service.AddAssignment(a1);
        service.AddAssignment(a2);

        // Act
        var result = service.ListIncomplete();

        // Assert
        Assert.Empty(result);
    }

}
