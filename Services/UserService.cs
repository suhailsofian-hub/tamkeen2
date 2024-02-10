namespace WebApi.Services;
using WebApi.data;
using WebApi.Entities;

public interface IUserService
{
    User Authenticate(string username, string password);
    Task<IEnumerable<User>> GetAll();
}

public class UserService : IUserService
{

    private readonly ADBContext _dbContext;
    public UserService(ADBContext dbContext)
    {
        _dbContext = dbContext;
    }

    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    };

    public  User Authenticate(string username, string password)
    {
        // wrapped in "await Task.Run" to mimic fetching user from a db
      //  var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));
        var user =  _dbContext.Users.SingleOrDefault(x => x.Username == username && x.Password == password);
        // on auth fail: null is returned because user is not found
        // on auth success: user object is returned
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        // wrapped in "await Task.Run" to mimic fetching users from a db
        return await Task.Run(() => _users);
    }

    //public async Task<IEnumerable<BlogPost>> GetAllPost()
   // {
        // wrapped in "await Task.Run" to mimic fetching users from a db
      //  return await _dbContext.BlogPosts;
  //  }
    //public async Task<BlogPost> GetPostById()
    //{
        // wrapped in "await Task.Run" to mimic fetching users from a db
      //  return;
   // }
   // public async Task<BlogPost> CreatePost()
   // {
        // wrapped in "await Task.Run" to mimic fetching users from a db
       // return;
    //}

   // public async Task<BlogPost> UpdatePost()
    //{
        // wrapped in "await Task.Run" to mimic fetching users from a db
       // return;
   // }

    //public void DeletePost()
   // {
        // wrapped in "await Task.Run" to mimic fetching users from a db
    //    return;
   // }
}
