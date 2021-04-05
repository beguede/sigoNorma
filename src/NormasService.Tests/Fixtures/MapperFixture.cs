using AutoMapper;

namespace NormasService.Tests.Fixtures
{
    public class MapperFixture
    {
        public IMapper Mapper { get; }

        public MapperFixture()
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(new Application.Mapping.NormaMap());
            });

            Mapper = config.CreateMapper();
        }
    }
}
