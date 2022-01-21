using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.WebApp.Models
{
    public class CommentVM
    {
        public int CommentId { get; set; }
        public String Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public String AuthorName { get; set; }

        public int OfferId { get; set; }
        //public Offer Offer { get; set; }
    }
}
