using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Review.Application.Commands
{
    public class AddReviewCommand : IRequest<Guid>
    {
        public Guid BusinessId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
