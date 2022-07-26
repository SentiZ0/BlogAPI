using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace BlogAPI.Features.Author.Queries.GetSingle
{
    public class GetSingleAuthorQuery : IRequest<GetSingleAuthorQueryResult>
    {
        public GetSingleAuthorQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
