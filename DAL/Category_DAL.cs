using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

public class Category_DAL
{
    public List<Category> GetAllCategories()
    {
        using (var context = new Cafe_Context())
        {
            return context.Categories.ToList();
        }
    }

    public void AddCategory(Category category)
    {
        using (var context = new Cafe_Context())
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }
    }

    public void UpdateCategory(Category category)
    {
        using (var context = new Cafe_Context())
        {
            var existingCategory = context.Categories.Find(category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.CategoryID = category.CategoryID;
                existingCategory.CategoryName = category.CategoryName;
                context.SaveChanges();
            }
        }
    }

    public void DeleteCategory(string categoryId)
    {
        using (var context = new Cafe_Context())
        {
            var category = context.Categories.Find(categoryId);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
