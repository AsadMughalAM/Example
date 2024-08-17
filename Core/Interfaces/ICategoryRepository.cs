using Core.Entities;

namespace Core.Interfaces
{
    public  interface ICategoryRepository
    {
        List<Category> GetData();
        Category Create(Category category);
        Category Update(Category category);
    }
}
