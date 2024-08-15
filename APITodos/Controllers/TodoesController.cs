using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using APITodos.Services.JsonPlaceholderService;
using APITodos.Models;
using Newtonsoft.Json;

namespace APITodos.Controllers
{
    public class TodoesController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public TodoesController()
        {
           
        }


        //public TodoesController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        // GET: Todoes
        public async Task<IActionResult> Index()
        {

            return View(await GetPostsAsync());
        }

        

        // GET: Todoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,firstName,lastName")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                CreatePostAsync(todo);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(todo);
        }





        public async Task<List<Todo>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/docs/todos");
            response.EnsureSuccessStatusCode();
            var posts = await response.Content.ReadFromJsonAsync<List<Todo>>();
            int i = 4;
            return posts;
        }


        


        public async Task<Todo> CreatePostAsync(Todo newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("https://dummyjson.com/docs/todos", newPost);
            response.EnsureSuccessStatusCode();
            var createdPost = await response.Content.ReadFromJsonAsync<Todo>();
            return createdPost;
        }
    }
}
