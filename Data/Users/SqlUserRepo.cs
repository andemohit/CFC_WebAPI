using System;
using System.Collections.Generic;
using System.Linq;
using Branches.Data;
using Users.Models;

namespace Users.Data
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly BranchContext _context;

        public SqlUserRepo(BranchContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(b => b.id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User user)
        {
            // Nothing
        }
    }
}