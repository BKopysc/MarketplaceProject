using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Core.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public String Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public String AuthorName { get; set; }

        public int OfferId { get; set; }
        public Offer Offer { get; set; }
    }
}
