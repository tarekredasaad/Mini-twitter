using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public enum statusPost
    {
        New,
        Retweet
    }
    public class tweetPost
    {
        public int id { get; set; }
        public string content { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int? Likes { get; set; }
        public virtual List<Like>? Like { get; set; }
        public int? Replies { get; set; }
        public virtual List<Reply>? Reply { get; set; }
        public statusPost status { get; set; }
        public int ?retweetId { get; set; }
        [ForeignKey("retweetId")]
        public virtual tweetPost Retweet { get; set; }

        public virtual List<tweetPost> Reposts { get; set; }


    }
}
