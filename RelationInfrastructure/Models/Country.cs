using System;
using System.Collections.Generic;

namespace Relations.Dal.Models
{
    public class Country : EntityWithId
    {
        public Country()
        {
            CreatedAt = DateTime.Now;
            CreatedBy = "Evangelion";
            IsDisabled = false;
            IsDefault = false;
        }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Iso31662 { get; set; }
        public string Iso31663 { get; set; }
        public Guid? DefaultVatId { get; set; }
        public string PostalCodeFormat { get; set; }
        public ICollection<RelationAddress> RelationAddresses { get; set; }
    }
}