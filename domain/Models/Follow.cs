using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class Follow
    {


        public int Id { get; set; }
        [ForeignKey("OwnerUser")]
        public string User { get; set; }
        public ApplicationUser OwnerUser { get; set; }
        [ForeignKey("TargetUser")]
        public string TargetUserFollow { get; set; }

        public ApplicationUser TargetUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}
