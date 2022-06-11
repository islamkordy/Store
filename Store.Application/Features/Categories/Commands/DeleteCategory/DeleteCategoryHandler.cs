using AutoMapper;
using Domain.Entities;
using MediatR;
using Store.Application.Contract.Persistence;

namespace Store.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);

            await categoryRepository.DeleteAsync(category);

            return new DeleteCategoryCommandResponse { Success = true};
        }
    }
}
