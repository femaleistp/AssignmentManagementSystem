using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using AssignmentManagement.API.Models;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;


namespace AssignmentManagement.API.Tests
{
    public class AssignmentApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly WebApplicationFactory<Program> _factory;

        public AssignmentApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        // Test to POST a new assignment    
        [Fact] 
        public async Task Can_Create_Assignment()  
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "Test Assignment", Description = "Test Description" }),
                Encoding.UTF8,
                "application/json");

            var response = await _client.PostAsync("/api/Assignment", assignmentJson);
            response.EnsureSuccessStatusCode();
        }

        // Test to GET ALL assignments
        [Fact] 
        public async Task Can_Get_Assignment()
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "Test Title", Description = "Test Description" }),
                Encoding.UTF8,
                "application/json");
            var response = await _client.PostAsync("/api/Assignment", assignmentJson);
            response.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/api/Assignment/GetAll");
            getResponse.EnsureSuccessStatusCode();
            var responseBody = await getResponse.Content.ReadAsStringAsync();
            Assert.Contains("Test Title", responseBody);
        }

        // Test to DELETE an assignment
        [Fact]
        public async Task Can_Delete_Assignment()  
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "Test Assignment", Description = "Test Description" }),
                Encoding.UTF8,
                "application/json");
            var response = await _client.PostAsync("/api/Assignment", assignmentJson);
            response.EnsureSuccessStatusCode();
            var deleteResponse = await _client.DeleteAsync("/api/Assignment/Test Assignment");
            deleteResponse.EnsureSuccessStatusCode();
            var getResponse = await _client.GetAsync("/api/Assignment/Test Assignment");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);

        }
    }
}
