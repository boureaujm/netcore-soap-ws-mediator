using System.Collections.Generic;
using MediatR;

namespace Application.AddNumbers
{
    public class GetAddNumberQuery: IRequest<GetAddNumberDto>
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
    }
}