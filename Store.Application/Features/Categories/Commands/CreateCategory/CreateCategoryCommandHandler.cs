﻿using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Common;
using Store.Application.Contract.Infrastructure;
using Store.Application.Contract.Persistence;
using Store.Application.Models;

namespace Store.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IAsyncRepository<Category> categoryRepository;
    private readonly IMapper mapper;
    private readonly IEmailService emailService;

    public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper, IEmailService emailService)
    {
        this.categoryRepository = categoryRepository;
        this.mapper = mapper;
        this.emailService = emailService;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        //if (validationResult.Errors.Count > 0)
        //    throw new Exceptions.ValidationException(validationResult);

        var category = mapper.Map<Category>(request);

        category = await categoryRepository.AddAsync(category);

        var email = new Email() { To = "islamkordy2@gmail.com", Subject = "Store .Net Project", Body = "You just created a new Category" };

        try
        {
            emailService.SendEmailAsync(email);
        }
        catch (Exception ex)
        {
            throw new Exceptions.InternalServiceError(ex.Message);
        }

        return new CreateCategoryCommandResponse{ Success = true, Id = category.Id};
    }
}
