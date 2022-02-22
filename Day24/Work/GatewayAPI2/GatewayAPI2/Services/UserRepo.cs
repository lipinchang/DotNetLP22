using GatewayAPI2.Models;

namespace GatewayAPI2.Services
{
    public class UserRepo : IRepo<string, User>
    {
        static List<User> _users = new List<User>()
        {
            new User(){Username="Ramu",Password="1234"}
        };

        public async Task<User> Add(User item)
        {
            _users.Add(item);
            return item;
        }

        public async Task<User> Delete(string key)
        {
            var usr = await Get(key);
            if (usr != null)
            {
                _users.Remove(usr);
                return usr;
            }
            return null;
        }

        public async Task<User> Get(string key)
        {
            var usr = _users.SingleOrDefault(u => u.Username == key);
            return usr;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return _users.ToList(); ;
        }

        public async Task<User> Update(User item)
        {
            var usr = await Get(item.Username);
            if (usr != null)
            {
                usr.Password = item.Password;
                return usr;
            }
            return null;
        }
    }
}
