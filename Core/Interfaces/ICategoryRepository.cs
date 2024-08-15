using Core.Entities;

namespace Core.Interfaces
{
    public  interface ICategoryRepository
    {
        List<Category> GetData();
        Category? GetById(string id);

        Category Create(Category category);
    }
}
