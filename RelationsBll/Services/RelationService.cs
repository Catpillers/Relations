using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;

namespace Relations.Bll.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relations;
       
        public RelationService( IRelationRepository relations)
        { 
            _relations = relations;
        }

        public async Task<IEnumerable<Relation>> GetRelationsList(Guid? categoryId)
        {
            return await _relations.GetRelationList(categoryId);
        }

        public async Task AddRelation(AddRelationModel relationModel)
        {
            var relation = new Relation
            {
                Name =  relationModel.Name,
                FullName = relationModel.FullName,
                EmailAddress = relationModel.EmailAddress,
                TelephoneNumber = relationModel.TelephoneNumber,
            };
            
            relation.RelationAddresses = new List<RelationAddress>
            {
                new RelationAddress
                {
                    RelationId = relation.Id,
                    City = relationModel.City,
                    Street = relationModel.Street,
                    Number = relationModel.Number,
                    PostalCode = relationModel.PostalCode,
                    AddressTypeId = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    CountryId = relationModel.CountryId
                }
            };

            var category = new Category
            {
                Id = relationModel.RelationCategoryId
            };

            relation.RelationCategories = new List<RelationCategory>
            {
                new RelationCategory
                {
                    RelationId = relation.Id,
                    CategoryId = category.Id
                }
            };
            await _relations.Add(relation);
        }
        
        public async Task<IEnumerable<Relation>> DisableRelation(IEnumerable<Guid> relationIds)
        {
            return await _relations.UpdateRelations(relationIds);
        }
    }
}
