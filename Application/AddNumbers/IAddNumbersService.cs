using System.Threading.Tasks;

namespace Application.AddNumbers
{
    public interface IAddNumbersService
    {
        /// <summary>
        /// return Fibonaci value
        /// simulate an async process
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        Task<GetAddNumberDto> GetAddNumbersSum(int value1, int value2);
    }
}