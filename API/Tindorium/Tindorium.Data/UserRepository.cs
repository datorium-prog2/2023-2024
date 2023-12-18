using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Tindorium.Data
{
    public class UserRepository
    {
        private TindoriumDbContext _dbContext;
        public UserRepository(TindoriumDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public List<User> Get()
        {
            return _dbContext.Users.ToList();
        }
    }
}
