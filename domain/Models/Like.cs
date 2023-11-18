using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class Like
    {
        public int Id { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public tweetPost Post { get; set; }
        [ForeignKey("User")]
        public string OwnerLike { get; set; }
        public ApplicationUser User { get; set; }
    }
}
