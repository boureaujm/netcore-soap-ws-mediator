using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.AddNumbers
{
    public class GetAddNumberQueryHandler : IRequestHandler<GetAddNumberQuery, GetAddNumberDto>
    {
        private readonly IAddNumbersService _addNumbersService;

        public GetAddNumberQueryHandler(IAddNumbersService addNumbersService)
        {
            _addNumbersService = addNumbersService;
        }

        public async Task<GetAddNumberDto> Handle(GetAddNumberQuery request, CancellationToken cancellationToken)
        {
            var fibonacciDto = await _addNumbersService.GetAddNumbersSum(request.Value1, request.Value2);
            return fibonacciDto;
        }
    }
}