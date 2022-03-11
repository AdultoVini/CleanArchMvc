﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }



        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value!");
            this.Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name, Name field is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters!");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid description, Description field is required!");
            DomainExceptionValidation.When(description.Length < 5, "Invalid description, too short, minimum 5 characters!");
            DomainExceptionValidation.When(price < 0, "Invalid price value!");
            DomainExceptionValidation.When(stock < 0, "Invalid stock value!");
            DomainExceptionValidation.When(image?.Length > 250, "Invalid image value!");
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Stock = stock;
            this.Image = image;
        }
    }
}
