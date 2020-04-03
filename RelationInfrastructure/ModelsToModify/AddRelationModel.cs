using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Relations.API.ViewModels
{
    public class AddRelationModel
    {
        public Guid RelationCategoryId { get; set; }
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string PostalCode { get; set; }
    }
}
