using Keep_Note4.Model;

namespace Keep_Note4.Repository
{
    public interface ICategoryRepo
    {
        Category CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int categoryId);
        Category GetCategoryById(int categoryId);
        List<Category> GetAllCategoriesByUserId(int userId);

    }
}
