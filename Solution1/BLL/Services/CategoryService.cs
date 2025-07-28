using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.DTOs;
using DAL;

namespace BLL.Services
{
    /// <summary>
    /// Service implementation for category operations.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var result = new List<CategoryDto>();
            foreach (var cat in categories)
            {
                result.Add(new CategoryDto { Id = cat.Id, Name = cat.Name });
            }
            return result;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var cat = await _unitOfWork.Categories.GetByIdAsync(id);
            if (cat == null) return null;
            return new CategoryDto { Id = cat.Id, Name = cat.Name };
        }

        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var cat = new Category { Name = categoryDto.Name };
            await _unitOfWork.Categories.AddAsync(cat);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var cat = await _unitOfWork.Categories.GetByIdAsync(categoryDto.Id);
            if (cat == null) return;
            cat.Name = categoryDto.Name;
            _unitOfWork.Categories.Update(cat);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var cat = await _unitOfWork.Categories.GetByIdAsync(id);
            if (cat == null) return;
            _unitOfWork.Categories.Remove(cat);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
