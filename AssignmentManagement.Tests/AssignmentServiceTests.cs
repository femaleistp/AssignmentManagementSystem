using Xunit;
using AssignmentManagement.Core.Models;
using AssignmentManagement.Core.Services;
using AssignmentManagement.Core.Interfaces;

namespace AssignmentManagement.Tests;

public class AssignmentServiceTests
{

    private class FakeLogger : IAppLogger
    {
        public void Log(string message)
        {
            // Fake logging
        }
    }

    private class FakeFormatter : IAssignmentFormatter
    {
        public string Format(Assignment assignment)
        {
            return $"{assignment.Title}: {assignment.Description}";
        }
    }

    [Fact]
    public void GetAll_ShouldReturnOnlyIncompleteAssignments_WhenFiltered()
    {
        // Arrange
        var service = new AssignmentService(new FakeLogger(), new FakeFormatter());
        var a1 = new Assignment { Title = "Incomplete Task", Description = "Do something", IsCompleted = false };
        var a2 = new Assignment { Title = "Completed Task", Description = "Do something else", IsCompleted = true };

        service.Add(a1);
        service.Add(a2);

        // Act
        var result = service.GetAll().Where(a => !a.IsCompleted).ToList();

        // Assert
        Assert.Single(result);
        Assert.Equal("Incomplete Task", result[0].Title);
    }
}
