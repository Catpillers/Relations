using System;

namespace Relation.API.Models
{
    public class RelationVm
    {
        public Guid Id { get; set; }
        public Guid RelationCategoryId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string CountryName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int? Number { get; set; }
        public string PostalCode { get; set; }
    }
}