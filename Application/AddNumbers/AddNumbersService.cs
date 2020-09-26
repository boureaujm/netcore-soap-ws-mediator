using System.Threading.Tasks;

namespace Application.AddNumbers
{
    public class AddNumbersService : IAddNumbersService
    {
        private readonly IAddNumbersRepository _addNumbersRepository; 
        
        public AddNumbersService(IAddNumbersRepository addNumbersRepository)
        {
            _addNumbersRepository = addNumbersRepository;
        }
        
        public Task<GetAddNumberDto> GetAddNumbersSum(int value1, int value2)
        {
            return _addNumbersRepository.GetAddNumbersSum(value1, value2);
        }
    }
}