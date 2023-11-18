using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class Reply
    {

        public int Id { get; set; }
        public string contentReply { get; set; }
        public int PostId { get; set; }
        public tweetPost Post { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
