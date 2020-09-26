using System.Threading.Tasks;

namespace Application.AddNumbers
{
    public interface IAddNumbersRepository
    {
        /// <summary>
        /// return Fibonaci value
        /// simulate an async process
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Task<GetAddNumberDto> GetAddNumbersSum(int value1, int value2);
    }
}