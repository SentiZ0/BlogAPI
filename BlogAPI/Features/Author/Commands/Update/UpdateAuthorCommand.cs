using MediatR;

namespace BlogAPI.Features.Author.Commands.Update
{
    public class UpdateAuthorCommand : IRequest<UpdateAuthorCommandResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public int Age { get; set; }
        public string Hobby { get; set; }

        public string Job { get; set; }
    }
}
