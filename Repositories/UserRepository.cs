using authentication_jwt.Models;

namespace authenticacao_jwt.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>(){
            new() { Id = 1, UserName = "batman", Password = "123", Role = "manager" },
            new() { Id = 2, UserName = "robin", Password = "123", Role = "employee"}
           };
            return users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
        }
    }
}