using Microsoft.Extensions.DependencyInjection;
using AssignmentManagement.Core.Interfaces;
using AssignmentManagement.Core.Models;
using AssignmentManagement.UI.Services;
using AssignmentManagement.Core.Services;

var services = new ServiceCollection();
services.AddSingleton<IAppLogger, ConsoleAppLogger>();
services.AddSingleton<IAssignmentFormatter, AssignmentFormatter>();
services.AddSingleton<IAssignmentService, AssignmentService>();

var provider = services.BuildServiceProvider();
var service = provider.GetRequiredService<IAssignmentService>();

// Use the service to add an assignment
var assignment = new Assignment { Title = "Console Demo", Description = "Test from console" };
service.Add(assignment);

// Format and print
var formatter = provider.GetRequiredService<IAssignmentFormatter>();
Console.WriteLine(formatter.Format(assignment));
