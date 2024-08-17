

namespace APITodos.Models
{
    public class User
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }


    public class UserList
    {
        public List<User> Users { get; set; }

    }

}
