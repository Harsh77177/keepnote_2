using Keep_Note4.Context;
using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        KeepDbContext _context;
        public CategoryRepo(KeepDbContext context)
        {
            _context = context;
        }
        public Category CreateCategory(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int categoryId)
        {
            var obj = _context.categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (obj != null)
            {
                _context.categories.Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Category> GetAllCategoriesByUserId(int userId)
        {
            return _context.categories.Where(x => x.users.UserId == userId).ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            var obj = _context.categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (obj != null)
                return obj;
            return null;
        }

        public bool UpdateCategory(Category category)
        {
            var obj = _context.categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (obj != null)
            {
                obj.CategoryName = category.CategoryName;
                obj.CategoryDescription = category.CategoryDescription;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
