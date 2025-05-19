using Xunit;
using AssignmentManagement.Core.Models;
using AssignmentManagement.UI.Services;

namespace AssignmentManagement.Tests;

public class AssignmentFormatterTests
{
    [Fact]
    public void Format_ShouldReturnExpectedOutput()
    {
        // Arrange
        var formatter = new AssignmentFormatter();
        var assignment = new Assignment
        {
            Title = "Format Test",
            Description = "Check formatting",
            IsCompleted = true
        };

        // Act
        var result = formatter.Format(assignment);

        // Assert
        Assert.Contains("Format Test", result);
        Assert.Contains("Check formatting", result);
        Assert.Contains("Completed", result);
    }
}
