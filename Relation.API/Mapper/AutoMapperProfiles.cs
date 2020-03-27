using System.Linq;
using AutoMapper;
using Relation.API.Models;
using Relations.Dal.Models;

namespace Relation.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Relations.Dal.Models.Relation, RelationVm>()
                .ForMember(_ => _.CountryName, opt => opt.MapFrom(_ => _.RelationAddresses.FirstOrDefault().Country.Name))
                .ForMember(_ => _.RelationCategoryId, opt => opt.MapFrom(_ => _.RelationCategories.FirstOrDefault().CategoryId))
                .ForMember(_ => _.City, opt => opt.MapFrom(_ => _.RelationAddresses.FirstOrDefault().City))
                .ForMember(_ => _.Street, opt => opt.MapFrom(_ => _.RelationAddresses.FirstOrDefault().Street))
                .ForMember(_ => _.Number, opt => opt.MapFrom(_ => _.RelationAddresses.FirstOrDefault().Number))
                .ForMember(_ => _.PostalCode, opt => opt.MapFrom(_ => _.RelationAddresses.FirstOrDefault().PostalCode));

            CreateMap<Category, CategoryVm>();
        }
    }
}