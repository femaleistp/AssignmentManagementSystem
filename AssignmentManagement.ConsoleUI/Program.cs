using AssignmentLibrary;

try
{
    // This will fail validation because title is blank
    var assignment = new Assignment("", "This will fail");
}
catch (ArgumentException ex)
{
    Console.WriteLine("Validation failed!");
    Console.WriteLine("Message: " + ex.Message);
}

Console.WriteLine("Press Enter to exit.");
Console.ReadLine(); // Keeps the console window open
