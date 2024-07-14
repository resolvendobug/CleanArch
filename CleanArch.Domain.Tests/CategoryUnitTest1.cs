using CleanArch.Domain.Entities;
using FluentAssertions;

namespace CleanArch.Domain.Tests;

public class CategotyUnitTest1
{
    [Fact(DisplayName = "Create Category With Validade Parameters")]
    public void CreateCategory_WithValidadeParameters_ResultObjectValidState()
    {
        Action action = () => new Category(1, "Category Name");
        action.Should()
            .NotThrow<Validation.DomainExceptionValidation>();
    }

    [Fact(DisplayName = "Create Category Negative Id Value")]
    public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Category(-1, "Category Name");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }

    [Fact(DisplayName = "Create Category Short Name Value")]
    public void CreateCategory_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Category(1, "Ca");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Too short, minimum 3 characters");
    }

    [Fact(DisplayName = "Create Category Empty Name Value")]
    public void CreateCategory_MissingNameValue_DomainExceptionNameRequired()
    {
        Action action = () => new Category(1, "");
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact(DisplayName = "Create Category Null Name Value")]
    public void CreateCategory_NullNameValue_DomainExceptionNameRequired()
    {
        Action action = () => new Category(1, null);
        action.Should()
            .Throw<Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    
    
}