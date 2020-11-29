using System;
using System.Collections.Generic;
using System.Linq;
using Branches.Data;
using Categories.Models;

namespace Categories.Data
{
    public class SqlCategoryRepo : ICategoryRepo
    {
        private readonly BranchContext _context;
        
        public SqlCategoryRepo(BranchContext context)
        {
            _context = context;
        }
        
        public void CreateCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _context.Categories.Remove(category);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(b => b.id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCategory(Category category)
        {
            // Nothing
        }
    }
}