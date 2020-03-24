using System;

namespace Relations.Dal.Models
{
    public class RelationCategory
    {
        public Guid Id { get; set; }
        public Guid RelationId { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public Relation Relation { get; set; }
        
    }
}
