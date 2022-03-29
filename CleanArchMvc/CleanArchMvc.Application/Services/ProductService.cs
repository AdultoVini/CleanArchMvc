using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            //var productEntities = await _productRepository.GetProducts();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productEntities);
            var productQuery = new GetProductsQuery();
            if(productQuery == null)
            {
                throw new Exception($"Entity could not be loaded");
            }
            var result = await _mediator.Send(productQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Add(ProductDTO productDTO)
        {
            //var productEntity =  _mapper.Map<Product>(productDTO);
            //await _productRepository.Create(productEntity);
            var productEntity = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productQuery = new ProductRemoveCommand(id.Value);

            if (productQuery == null)
                throw new Exception($"Could not found product.");

             await _mediator.Send(productQuery);

        }

        public async Task<ProductDTO> GetById(int? id)
        {
            //var productEntity = await _productRepository.GetById(id);
            //return _mapper.Map<ProductDTO>(productEntity);
            var productQuery = new GetProductByIdQuery(id.Value);

            if (productQuery == null)
                throw new Exception($"Could not found product.");

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    var productQuery = new GetProductByIdQuery(id.Value);

        //    if (productQuery == null)
        //        throw new Exception($"Could not found product.");

        //    var result = await _mediator.Send(productQuery);
        //    return _mapper.Map<ProductDTO>(result);
        //}


        public async Task Update(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productEntity);
        }
    }
}
