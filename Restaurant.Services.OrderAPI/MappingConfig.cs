using AutoMapper;

namespace Restaurant.Services.OrderAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration ReisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

            });

            return mappingConfig;
        }
    }
}
