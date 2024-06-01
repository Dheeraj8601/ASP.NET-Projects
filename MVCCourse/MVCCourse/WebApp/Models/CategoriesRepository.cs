using WebApp.Models;

namespace WebApp.Models
{
    public static class CategoriesRepository
    {
        // Static list of categories initialized with some default values
        public static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage 1" },
            new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
            new Category { CategoryId = 3, Name = "Meat", Description = "Meat" },
        };

        // Method to add a new category to the list
        public static void AddCategory(Category category)
        {
            // Find the current maximum CategoryId in the list
            var maxId = _categories.Max(x => x.CategoryId);

            // Set the new category's CategoryId to one greater than the current maximum
            category.CategoryId = maxId + 1;

            // Add the new category to the list
            _categories.Add(category);
        }

        public static List<Category> GetAllCategories() => _categories;

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    Description = category.Description,
                };
            }
            return null;
        }


        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if(category != null )
            {
                _categories.Remove(category);
            }
        }
    }
}
