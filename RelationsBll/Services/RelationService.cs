using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Relations.API.ViewModels;
using Relations.Bll.Interfaces;
using Relations.Dal.Helpers;
using Relations.Dal.Interfaces;
using Relations.Dal.Models;
using Relations.Dal.ModelsToModify;
using Relations.Dal.Repository;

namespace Relations.Bll.Services
{
    public class RelationService : IRelationService
    {
        private readonly IRelationRepository _relations;
        private readonly ICountryRepository _countryRepository;
        
       
        public RelationService( IRelationRepository relations, ICountryRepository countryRepository)
        {
            _relations = relations;
            _countryRepository = countryRepository;
        }

        public RelationService()
        {
        }

        public async Task<PaginatedList<RelationVm>> GetRelationsList(Guid? categoryId, int? pageNumber, string sortField, string sortOrder)
        {
            return await _relations.GetRelationList(categoryId, pageNumber, sortField, sortOrder);
        }

        public async Task AddRelation(AddRelationModel relationModel)
        {
            var country = await _countryRepository.GetById(relationModel.CountryId);
            var maskedPostalCode = ApplyMask(relationModel.PostalCode, country.PostalCodeFormat);
            relationModel.PostalCode = maskedPostalCode;
            await _relations.AddRelation(relationModel);
        }

        public async Task UpdateRelation(UpdateRelationModel modelToUpdate)
        {
            var country = await _countryRepository.GetById(modelToUpdate.CountryId);
            var maskedPostalCode = ApplyMask(modelToUpdate.PostalCode, country.PostalCodeFormat);
            modelToUpdate.PostalCode = maskedPostalCode;
            await _relations.UpdateRelation(modelToUpdate);
        }

        public async Task DisableRelation(IEnumerable<Guid> relationIds)
        {
            
            await _relations.DisableRelations(relationIds);
        }

        public string ApplyMask(string value, string mask)
        {
            if (string.IsNullOrEmpty(mask) || string.IsNullOrEmpty(value)) return value;

            var result = new StringBuilder();

            var valueIterator = 0;

            foreach (var item in mask)
            {
                switch (item)
                {
                    case 'N':
                    {
                        if (char.IsDigit(value[valueIterator]))
                        {
                            result.Append(value[valueIterator]);

                            valueIterator++;
                        }
                        else return value;

                        break;
                    }
                    case 'L':
                    {
                        if (char.IsLetter(value[valueIterator]))
                        {
                            result.Append(char.ToUpper(value[valueIterator]));

                            valueIterator++;
                        }
                        else return value;

                        break;
                    }
                    case 'l':
                    {
                        if (char.IsLetter(value[valueIterator]))
                        {
                            result.Append(char.ToLower(value[valueIterator]));

                            valueIterator++;
                        }
                        else return value;

                        break;
                    }
                    default:
                    {
                        result.Append(item);
                        if (!char.IsLetterOrDigit(value[valueIterator]))
                        {
                            if (value[valueIterator] == item)
                            {
                                valueIterator++;
                            }
                            else return value;
                        }
                        break;
                    }
                }
            }
            return value.Length == valueIterator ? result.ToString() : value;
        }


    }
}
