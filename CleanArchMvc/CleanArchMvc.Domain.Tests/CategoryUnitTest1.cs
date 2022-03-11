using System;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid Parameters")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Negative Id")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value!");
        }

        [Fact]
        public void CreateCategory_WithShortName_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters!");
        }

        [Fact]
        public void CreateCategory_WithFieldNameNull_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, Name field is required!");
        }

        [Fact]
        public void CreateCategory_WithFieldNameEmpty_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, Name field is required!");
        }
    }
}