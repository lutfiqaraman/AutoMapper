using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AuthorDTO, AuthorModel>()
                .ForMember(
                    destModel => destModel.Address, 
                    map => map.MapFrom(SourceModel => new Address
                    {
                        City    = SourceModel.City,
                        State   = SourceModel.State,
                        Country = SourceModel.Country
                    }));
            });

            IMapper iMapper = config.CreateMapper();

            var source = new AuthorDTO()
            {
                Id          = 1,
                FirstName   = "Joydip",
                LastName    = "Kanjilal",
                City        = "Amman",
                State       = "Amman",
                Country     = "Jordan"
            };

            var printModel = iMapper.Map<AuthorDTO, AuthorModel>(source);

            Console.WriteLine(
                "Author Name: " + printModel.FirstName      + " "   + printModel.LastName + "\n" +
                "City: "        + printModel.Address.City   + "\n"  +
                "Country: "     + printModel.Address.Country
                );


            Console.ReadLine();
        }
    }
}
 