using domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.DTO
{
    public class LikeDTO
    {
        public int PostId { get; set; }
       
        public string OwnerLike { get; set; }
    }
}
