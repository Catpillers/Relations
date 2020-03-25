using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using AutoMapper;
using Relations.API.Dto;
using Relations.Dal.Models;

namespace Relations.API.Mapper
{
    public class AutoMapperProfiles : Profile
    { 
        public AutoMapperProfiles()
        {
            CreateMap<Relation, RelationToDisplayDto>()
                .ConvertUsing(_ => new RelationToDisplayDto()
                {
                    Id = _.Id,
                    Name = _.Name,
                    FullName = _.FullName,
                    EmailAddress = _.EmailAddress,
                    TelephoneNumber = _.TelephoneNumber,
                    CountryName = _.RelationAddresses.FirstOrDefault().Country.Name,
                    City = _.RelationAddresses.FirstOrDefault().City,
                    Street = _.RelationAddresses.FirstOrDefault().Street,
                    Number = _.RelationAddresses.FirstOrDefault().Number,
                    PostalCode = _.RelationAddresses.FirstOrDefault().PostalCode
                });
        }
    }
}
