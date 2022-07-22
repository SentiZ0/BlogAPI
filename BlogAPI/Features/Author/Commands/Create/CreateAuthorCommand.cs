using MediatR;

namespace BlogAPI.Features.Author.Commands.Create
{
    public class CreateAuthorCommand : IRequest<CreateAuthorCommandResult>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        public string Hobby { get; set; }

        public string Job { get; set; }
    }
}
