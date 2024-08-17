using System.Net.Http.Json;
using APITodos.Models;

namespace APITodos
{
    public class JsonPlaceholderService
    {
        private readonly HttpClient _httpClient;

        public JsonPlaceholderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/docs/todos");
            response.EnsureSuccessStatusCode();
            var posts = await response.Content.ReadFromJsonAsync<List<User>>();
            return posts;
        }

        public async Task<User> GetPostAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://dummyjson.com/docs/todos/{id}");
            response.EnsureSuccessStatusCode();
            var post = await response.Content.ReadFromJsonAsync<User>();
            return post;
        }

        public async Task<User> CreatePostAsync(User newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("https://dummyjson.com/docs/todos", newPost);
            response.EnsureSuccessStatusCode();
            var createdPost = await response.Content.ReadFromJsonAsync<User>();
            return createdPost;
        }

        public async Task UpdatePostAsync(int id, User updatedPost)
        {
            var response = await _httpClient.PutAsJsonAsync($"https://dummyjson.com/docs/todos/{id}", updatedPost);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeletePostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"https://dummyjson.com/docs/todos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }

    
}
