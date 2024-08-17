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
        private readonly HttpClient _httpClient;

        //public TodoesController()
        //{

        //}


        public TodoesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }






        // GET: Todoes
        public async Task<IActionResult> Index()
        {

            return View(await GetPostsAsync());
        }

        public async Task<List<User>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/users?select=firstName,id,lastName");
            response.EnsureSuccessStatusCode();
            var Users = await response.Content.ReadFromJsonAsync<UserList>();
            return Users.Users;
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
        public async Task<IActionResult> Create([Bind("id,firstName,lastName")] User todo)
        {
            if (ModelState.IsValid)
            {
                CreatePostAsync(todo);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }



        






        public async Task<User> CreatePostAsync(User newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("https://dummyjson.com/users?select=firstName,id,lastName", newPost);
            response.EnsureSuccessStatusCode();
            var createdPost = await response.Content.ReadFromJsonAsync<User>();
            return createdPost;
        }
    }
}
