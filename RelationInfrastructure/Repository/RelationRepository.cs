using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.API.ViewModels;
using Relations.Dal.Data;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;
using Relations.Dal.ModelsToModify;



namespace Relations.Dal.Repository
{
    public class RelationRepository : AsyncRepository<Relation>, IRelationRepository
    {
        public RelationRepository(DataContext context) : base(context){}

        public async Task<PaginatedList<Relation>> GetRelationList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder)
        {
            int pageSize = 5;
            if (string.IsNullOrWhiteSpace(sortField))
            {
                sortField = "name";
            }
            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                sortOrder = "asc";
            }

            var relationsQuery = _context.Set<Relation>()
                .Include(_ => _.RelationCategories)
                .Include(_ => _.RelationAddresses)
                .ThenInclude(_ => _.Country)
                .Where(_ => _.IsDisabled != true).OrderByDynamic(sortField, sortOrder.ToUpper());

            //var relationVm = new RelationVm()
            //{
            //    Id = relationsQuery.Single().Id,
            //    RelationCategoryId = relationsQuery.Single().RelationCategories.First().CategoryId,
            //    CountryId = relationsQuery.Single().RelationAddresses.First().CountryId,
            //    Name = relationsQuery.Single().Name,
            //    FullName = relationsQuery.Single().FullName,
            //    EmailAddress = relationsQuery.Single().EmailAddress,
            //    TelephoneNumber = relationsQuery.Single().TelephoneNumber,
            //    CountryName = relationsQuery.Single().RelationAddresses.First().CountryName,
            //    City = relationsQuery.Single().RelationAddresses.First().City,
            //    Street = relationsQuery.Single().RelationAddresses.First().Street,
            //    Number = relationsQuery.Single().RelationAddresses.First().Number,
            //    PostalCode = relationsQuery.Single().RelationAddresses.First().PostalCode
            //};

            if (categoryId == null)
            {
                return await PaginatedList<Relation>.CreateAsync(relationsQuery, pageNumber ?? 1, pageSize);
            }

            return await PaginatedList<Relation>.CreateAsync(relationsQuery
                    .Where(_ => _.RelationCategories.FirstOrDefault().CategoryId == categoryId), pageNumber ?? 1, pageSize);
        }

        public async Task AddRelation(AddRelationModel relationModel)
        {
            var relation = new Relation
            {
                Name = relationModel.Name,
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
          await  _context.AddAsync(relation);
          await _context.SaveChangesAsync();
        }

        public async Task UpdateRelation(UpdateRelationModel updatedRelation)
        {
            var relationToUpdate = await GetRelation(updatedRelation.Id);
            relationToUpdate.Name = updatedRelation.Name;
            relationToUpdate.FullName = updatedRelation.FullName;
            relationToUpdate.EmailAddress = updatedRelation.EmailAddress;
            relationToUpdate.TelephoneNumber = updatedRelation.TelephoneNumber;

            var relationAddress = relationToUpdate.RelationAddresses.Single();
            relationAddress.CountryId = updatedRelation.CountryId;
            relationAddress.Street = updatedRelation.Street;
            relationAddress.Number = updatedRelation.Number;
            relationAddress.PostalCode = updatedRelation.PostalCode;
            relationAddress.City = updatedRelation.City;

            var relationCategory = relationToUpdate.RelationCategories.Single();
            if (relationCategory.CategoryId != updatedRelation.RelationCategoryId)
            {
                _context.Remove(relationCategory);
                relationCategory = new RelationCategory
                {
                    CategoryId = updatedRelation.RelationCategoryId,
                    RelationId = updatedRelation.Id
                };

            }
            _context.Add(relationCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DisableRelations(IEnumerable<Guid> ids)
        {
            var relationsToUpdate = await _context.Set<Relation>().Where(_ => ids.Contains(_.Id)).ToListAsync();
            foreach (var relation in relationsToUpdate)
            {
                relation.IsDisabled = true;
            }
            await  _context.SaveChangesAsync();
        }

        public async Task<Relation> GetRelation(Guid id)
        {
            var relation = await _context.Set<Relation>()
                .Include(_ => _.RelationAddresses)
                .Include(_ => _.RelationCategories)
                .SingleAsync(_ => _.Id == id);
            return relation;
        }
    }
}