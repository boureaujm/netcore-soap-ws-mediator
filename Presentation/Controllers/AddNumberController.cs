using System.Reflection;
using System.ServiceModel;
using System.Threading.Tasks;
using Application.AddNumbers;
using log4net;
using MediatR;

namespace Presentation.Controllers
{
    [ServiceContract]
    public interface IAddNumberController
    {
        [OperationContract]
        Task<int> Add(int value1, int value2);
    }

    public class AddNumberController : IAddNumberController
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IMediator _mediator;

        public AddNumberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<int> Add(int value1, int value2)
        {
            var getAddNumbersQuery = CreateAddNumbersQuery(value1, value2);

            _logger.Debug($"Request : value1 = {value1} value2 = {value2}");

            var result = await _mediator.Send(getAddNumbersQuery);

            _logger.Debug($"Response : result = {result.Result}");

            return result.Result;
        }

        private IRequest<GetAddNumberDto> CreateAddNumbersQuery(int value1, int value2)
        {
            var query = new GetAddNumberQuery() {Value1 = value1, Value2 = value2};
            return query;
        }
    }
}