using System.Collections.Generic;
using Categories.Models;

namespace Categories.Data
{
    public interface ICategoryRepo
    {
        bool SaveChanges();
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}