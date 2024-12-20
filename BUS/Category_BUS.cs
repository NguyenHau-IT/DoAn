using DAL;
using DAL.Entities;
using System.Collections.Generic;

public class Category_BUS
{
    private readonly Category_DAL category_DAL = new Category_DAL();

    public List<Category> GetAllCategories()
    {
        return category_DAL.GetAllCategories();
    }

    public void AddCategory(Category category)
    {
        category_DAL.AddCategory(category);
    }

    public void UpdateCategory(Category category)
    {
        category_DAL.UpdateCategory(category);
    }

    public void DeleteCategory(string categoryId)
    {
        category_DAL.DeleteCategory(categoryId);
    }
}
