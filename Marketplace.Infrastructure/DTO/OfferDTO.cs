using System;
using System.Collections.Generic;
using System.Text;

namespace Marketplace.Infrastructure.DTO
{
    public class OfferDTO
    {
        public int OfferId { get; set; }
        public String Name { get; set; }
        public String AuthorName { get; set; }
        public double Price { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }

        public int ProfileId { get; set; }
        public ProfileDTO Profile { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
        public List<CommentDTO> Comments { get; set; }

        //public static implicit operator OfferDTO(OfferDTO v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
