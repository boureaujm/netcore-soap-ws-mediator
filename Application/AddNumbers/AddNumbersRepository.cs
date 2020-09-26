using System.Threading.Tasks;

namespace Application.AddNumbers
{
    public class AddNumbersRepository : IAddNumbersRepository
    {
        /// <summary>
        /// return Fibonaci value
        /// simulate an async process
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public async Task<GetAddNumberDto> GetAddNumbersSum(int value1, int value2)
        {
            var t = new Task<GetAddNumberDto>(() =>  AddNumbers(value1, value2));
            t.Start();
            return await t;
        }
        
        /// <summary>
        /// Calc fibonaci value at the position 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        private GetAddNumberDto AddNumbers(int value1, int value2)
        {
            var result = value1 + value2;
            var addNumberDto = new GetAddNumberDto {Result = result};

            return addNumberDto;
        }

    
    }
}