using Microsoft.EntityFrameworkCore;
using UserAuthenticationSystem.Data;
using UserAuthenticationSystem.model;

namespace UserAuthenticationSystem.services
{
    public class UserService:IUserService
    {
        public readonly ApDbContext dbContext;
        public UserService(ApDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> RegisterUser(User user)
        {
            var users = await dbContext.Users.ToListAsync();
            foreach(User _user in users)
            {
                if (user.Email == _user.Email)
                {
                    return false;
                }
            }
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<User> Login(string email, string password) { 
        
        var userExist=await dbContext.Users.FirstOrDefaultAsync(u=>u.Email==email && u.Password==password);
            if(userExist==null)
            {
                return null;
            }
            return userExist;
        }
    }
}
