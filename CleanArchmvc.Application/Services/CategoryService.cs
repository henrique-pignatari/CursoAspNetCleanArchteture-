﻿using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIdAsync(int? id)
        {
            var categryEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categryEntity);
        }

        public async Task AddAsync(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.CreateAsync(categoryEntity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.UpdateAsync(categoryEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            var categoryEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoryEntity);
        }
    }
}
