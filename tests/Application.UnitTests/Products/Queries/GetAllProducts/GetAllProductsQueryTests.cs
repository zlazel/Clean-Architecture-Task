using AutoMapper;
using Canteen.Application.Products.Models;
using Canteen.Application.Products.Queries;
using Clean_Architecture_Task.Application.UnitTests.Common;
using Clean_Architecture_Task.Infrastructure.Persistence;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Clean_Architecture_Task.Application.UnitTests.Products.Queries.GetProducts
{
    [Collection("QueryTests")]
    public class GetAllProductsQueryTests
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllProductsQueryTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public async Task Handle_ReturnsCorrectVmAndListCount()
        {
            var query = new GetAll();

            var handler = new GetAll.Handler(_context, _mapper);

            var result = await handler.Handle(query, CancellationToken.None);

            result.ShouldBeOfType<List<ProductLiDto>>();
            result.Count.ShouldBe(6);

        }
    }
}
