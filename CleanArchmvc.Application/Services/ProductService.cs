﻿using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();

            if (productsQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if (productByIdQuery == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        //{
        //    var productByIdQuery = new GetProductByIdQuery(id.Value);

        //    if (productByIdQuery == null)
        //    {
        //        throw new Exception($"Entity could not be loaded.");
        //    }

        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task AddAsync(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductDTO, ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductDTO, ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task RemoveAsync(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if (productRemoveCommand == null)
            {
                throw new Exception($"Entity could not be loaded.");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
