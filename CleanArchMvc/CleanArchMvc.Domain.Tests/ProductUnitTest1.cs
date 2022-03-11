using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Maça do amor", "Maça top de bola", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithImageNull_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Maça do amor", "Maça top de bola", 9.99m, 10, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithImageNullRefence_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Maça do amor", "Maça top de bola", 9.99m, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "Ma", "Maça top de bola", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters!");
        }
        
        [Fact]
        public void CreateProduct_WithFieldNameNull_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Maça top de bola", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name field is required!");
        }

        [Fact]
        public void CreateProduct_WithFieldNameEmpty_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, "", "Maça top de bola", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, Name field is required!");
        }

        [Fact]
        public void CreateProduct_WithFieldDescriptionEmpty_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Maça do amor", "", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, Description field is required!");
        }
        
        [Fact]
        public void CreateProduct_WithFieldDescriptionNull_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Maça do amor", null, 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, Description field is required!");
        }

        [Fact]
        public void CreateProduct_WithShortDescription_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "Maça do amor", "Maça", 9.99m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description, too short, minimum 5 characters!");
        }

        [Fact]
        public void CreateProduct_WithInvalidPriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Maça do amor", "Maçaasdasda", -1m, 10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value!");
        }

        [Fact]
        public void CreateProduct_WithInvalidStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Maça do amor", "Maçadasdasd", 9.99m, -10, "imagepontopngtop");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value!");
        }

        [Fact]
        public void CreateProduct_WithInvalidImageValue_DomainExceptionInvalidImage()
        {
            Action action = () => new Product(1, "Maça do amor", "Maçadasda", 9.99m, 10, "kkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkimagepontopngtopkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image value!");
        }
    }
}
