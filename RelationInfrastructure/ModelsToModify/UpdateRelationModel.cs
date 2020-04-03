using System;

namespace Relations.Dal.ModelsToModify
{
   public class UpdateRelationModel
   {
        public Guid Id { get; set; }
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
