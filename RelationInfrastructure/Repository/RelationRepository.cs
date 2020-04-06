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

        public async Task<PaginatedList<RelationVm>> GetRelationList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder)
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
                .Where(_ => _.IsDisabled != true)
                .Select(_ => new RelationVm
                {   Id= _.Id,
                    RelationCategoryId = _.RelationCategories.Single().CategoryId,
                    CountryId = _.RelationAddresses.First().CountryId,
                    Name = _.Name,
                    FullName = _.FullName,
                    EmailAddress = _.EmailAddress,
                    TelephoneNumber = _.TelephoneNumber,
                    CountryName = _.RelationAddresses.First().Country.Name,
                    City = _.RelationAddresses.First().City,
                    Street = _.RelationAddresses.First().Street,
                    Number = _.RelationAddresses.First().Number,
                    PostalCode = _.RelationAddresses.First().PostalCode
                }).OrderByDynamic(sortField, sortOrder.ToUpper());

            if (categoryId == null)
            {
                return await PaginatedList<RelationVm>.CreateAsync(relationsQuery, pageNumber ?? 1, pageSize);
            }
            //.Where(_ => _.RelationCategories.FirstOrDefault().CategoryId == categoryId), pageNumber ?? 1, pageSize);
            return await PaginatedList<RelationVm>.CreateAsync(relationsQuery.Where(_ => _.RelationCategoryId == categoryId), pageNumber ?? 1, pageSize);
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