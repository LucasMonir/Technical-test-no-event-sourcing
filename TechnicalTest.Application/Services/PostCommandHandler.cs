using TechnicalTest.Application.Abstractions.Persistence;
using TechnicalTest.Application.Abstractions.Repositories;
using TechnicalTest.Application.Abstractions.Services;
using TechnicalTest.Application.Commands;
using TechnicalTest.Domain;

namespace TechnicalTest.Application.Services
{
    internal class PostCommandHandler(IPostRepository postRepository,
        IAuthorResolver authorResolver,
        IUnitOfWork unitOfWork)
        : IPostCommandHandler
    {
        private readonly IPostRepository _postRepository = postRepository;
        private readonly IAuthorResolver _authorResolver = authorResolver;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePostCommand command)
        {
            Guid authorId = await _authorResolver.ResolveAsync(command);

            var post = Post.Create(
                authorId,
                command.Title,
                command.Description,
                command.Content
            );

            await _postRepository.CreatePostAsync(post);
            await _unitOfWork.CommitAsync();

            return post.Id;
        }
    }
}
