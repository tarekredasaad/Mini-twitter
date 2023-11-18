using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.DTO
{
    public class ReplyDTO
    {
        public string contentReply { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set;}
    }
}
