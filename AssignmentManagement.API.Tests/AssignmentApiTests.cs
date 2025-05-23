using Microsoft.AspNetCore.Mvc.Testing;
using System.Text;
using System.Text.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using AssignmentManagement.Core.Models;
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
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Status Code: {response.StatusCode}");
            Console.WriteLine($"Response Body: {content}");

            Assert.True(response.IsSuccessStatusCode, "API failed: " + content);
        }


        // Test to GET ALL assignments
        [Fact]
        public async Task Can_Get_Assignment()
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "Test Title", Description = "Test Description" }),
                Encoding.UTF8,
                "application/json");

            var postResponse = await _client.PostAsync("/api/Assignment", assignmentJson);
            var postContent = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"POST Status: {postResponse.StatusCode}");
            Console.WriteLine($"POST Response: {postContent}");
            Assert.True(postResponse.IsSuccessStatusCode, "POST failed: " + postContent);

            var getResponse = await _client.GetAsync("/api/Assignment/GetAll");
            var getContent = await getResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"GET Status: {getResponse.StatusCode}");
            Console.WriteLine($"GET Response: {getContent}");

            Assert.True(getResponse.IsSuccessStatusCode, "GET failed: " + getContent);
            Assert.Contains("Test Title", getContent);
        }


        // Test to DELETE an assignment
        [Fact]
        public async Task Can_Delete_Assignment()
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "Test Assignment", Description = "Test Description" }),
                Encoding.UTF8,
                "application/json");

            // POST
            var postResponse = await _client.PostAsync("/api/Assignment", assignmentJson);
            var postContent = await postResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"POST Status: {postResponse.StatusCode}");
            Console.WriteLine($"POST Response: {postContent}");
            Assert.True(postResponse.IsSuccessStatusCode, "POST failed: " + postContent);

            // ✅ Deserialize the created assignment to get its ID
            var createdAssignment = JsonSerializer.Deserialize<Assignment>(
                postContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.NotNull(createdAssignment);
            var id = createdAssignment.Id;

            // DELETE
            var deleteResponse = await _client.DeleteAsync($"/api/Assignment/{id}");
            var deleteContent = await deleteResponse.Content.ReadAsStringAsync();
            Console.WriteLine($"DELETE Status: {deleteResponse.StatusCode}");
            Console.WriteLine($"DELETE Response: {deleteContent}");
            Assert.True(deleteResponse.IsSuccessStatusCode, "DELETE failed: " + deleteContent);

            // GET
            var getResponse = await _client.GetAsync($"/api/Assignment/{id}");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
        }

        [Fact]
        public async Task Can_Create_AndRetrieve_Assignment_WithNotes_ViaApi()
        {
            var assignmentJson = new StringContent(
                JsonSerializer.Serialize(new { Title = "API Test", Description = "API Desc", Notes = "API Notes" }),
                Encoding.UTF8,
                "application/json");

            var postResponse = await _client.PostAsync("/api/Assignment", assignmentJson);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await _client.GetAsync("/api/Assignment/GetAll");
            var getBody = await getResponse.Content.ReadAsStringAsync();

            Assert.Contains("API Notes", getBody);
        }

    }
}
