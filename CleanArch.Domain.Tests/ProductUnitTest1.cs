using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product")]
        public void CreateProduct_WhithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product Negative Id Value")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product 1", "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product Empty Name Value")]
        public void CreateProduct_MissingNameValue_DomainExceptionNameRequired()
        {
            Action action = () => new Product(1, "", "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product Null Name Value")]
        public void CreateProduct_NullNameValue_DomainExceptionNameRequired()
        {
            Action action = () => new Product(1, null, "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Product Short Description Value")]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "Product 1", "Desc", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Create Product Empty Description Value")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionDescriptionRequired()
        {
            Action action = () => new Product(1, "Product 1", "", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product Null Description Value")]
        public void CreateProduct_NullDescriptionValue_DomainExceptionDescriptionRequired()
        {
            Action action = () => new Product(1, "Product 1", null, 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Create Product Negative Price Value")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product 1", "Description", -9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create Product Negative Stock Value")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product 1", "Description", 9.99m, -100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create Product Empty Image Value")]
        public void CreateProduct_MissingImageValue_NotThrowDomainExceptionImageRequired()
        {
            Action action = () => new Product(1, "Product 1", "Description", 9.99m, 100, "");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
                
        }

               
        [Fact(DisplayName = "Create Product Long Image Value")]
        public void CreateProduct_LongImageValue_DomainExceptionImageLength()
        {
            Action action = () => new Product("Product 1", "Description", 9.99m, 100, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo long");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Update Product")]
        public void UpdateProduct_WhithValidParameters_ResultObjectValidState()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", 9.99m, 100, "product image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Update Product Short Name Value")]
        public void UpdateProduct_ShortNameValue_DomainExceptionShortName()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Pr", "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Update Product Empty Name Value")]
        public void UpdateProduct_MissingNameValue_DomainExceptionNameRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("", "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Product Null Name Value")]
        public void UpdateProduct_NullNameValue_DomainExceptionNameRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update(null, "Description", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Update Product Short Description Value")]
        public void UpdateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Desc", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Too short, minimum 5 characters");
        }

        [Fact(DisplayName = "Update Product Empty Description Value")]
        public void UpdateProduct_MissingDescriptionValue_DomainExceptionDescriptionRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "", 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Update Product Null Description Value")]
        public void UpdateProduct_NullDescriptionValue_DomainExceptionDescriptionRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", null, 9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact(DisplayName = "Update Product Negative Price Value")]
        public void UpdateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", -9.99m, 100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Update Product Negative Stock Value")]
        public void UpdateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", 9.99m, -100, "product image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Update Product Empty Image Value")]
        public void UpdateProduct_MissingImageValue_NotThrowDomainExceptionImageRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", 9.99m, 100, "");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
                
        }

        [Fact(DisplayName = "Update Product Null Image Value")]
        public void UpdateProduct_NullImageValue_DomainExceptionImageRequired()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", 9.99m, 100, null);
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Image is required");
        }

        [Fact(DisplayName = "Update Product Long Image Value")]
        public void UpdateProduct_LongImageValue_DomainExceptionImageLength()
        {
            var product = new Product(1, "Product 1", "Description", 9.99m, 100, "product image");
            Action action = () => product.Update("Product 1", "Description", 9.99m, 100, "product image toooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo long");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Too long, maximum 250 characters");
        }
    }
}