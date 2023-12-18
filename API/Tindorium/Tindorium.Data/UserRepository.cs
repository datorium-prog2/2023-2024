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

class Car
{
    private string _color;
    public string Color
    {
        get { return _color; }
        set { 
            if(value == "gray")
            {
                throw new ArgumentException("cannot set color to gray");
            }
            else
            {
                _color = value;
            }
        }
    }
}
