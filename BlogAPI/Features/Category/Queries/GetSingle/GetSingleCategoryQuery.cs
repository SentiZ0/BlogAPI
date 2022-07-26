using BlogAPI.Features.Category.Queries.GetSingle;
using MediatR;

namespace BlogAPI.Features.Category.Queries.Get
{
    public class GetSingleCategoryQuery : IRequest<GetSingleCategoryQueryResult>
    {
        public int Id { get; set; }

        public GetSingleCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
