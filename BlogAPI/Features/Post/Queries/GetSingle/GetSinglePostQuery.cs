using MediatR;

namespace BlogAPI.Features.Post.Queries.GetSingle
{
    public class GetSinglePostQuery : IRequest<GetSinglePostQueryResult>
    {
        public int Id { get; set; }

        public GetSinglePostQuery(int id)
        {
            Id = id;
        }
    }
}