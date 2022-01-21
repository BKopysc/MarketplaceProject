using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.Commands
{
    public class UpdateComment
    {
        //public int CommentId { get; set; }
        public String Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public String AuthorName { get; set; }

        //public int OfferId { get; set; }
        //public Offer Offer { get; set; }
    }
}
