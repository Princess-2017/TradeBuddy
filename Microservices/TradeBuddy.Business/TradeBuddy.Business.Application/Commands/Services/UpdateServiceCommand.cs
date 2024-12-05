using MediatR;
using System;
using System.Collections.Generic;


namespace TradeBuddy.Business.Application.Commands.Services
{
    public class UpdateServiceCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public decimal Price { get; set; }
        public int StartHour { get; set; }
        public int StartMinute { get; set; }
        public int EndHour { get; set; }
        public int EndMinute { get; set; }
        public List<string> ServiceLocationTypeIds { get; set; }
    }

}
