using AutoMapper;

public class AutoMapperConfig
{
    public static MapperConfiguration Config { get; set; }

    public static void RegisterMappingsInitialize()
    {
        Mapper.Initialize(x =>
        {
            x.AddProfile<DomainToViewModelMappingProfile>();
            x.AddProfile<ViewModelToDomainMappingProfile>();
        });
    }

    public static MapperConfiguration RegisterMappings()
    {
        return new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DomainToViewModelMappingProfile());
            cfg.AddProfile(new ViewModelToDomainMappingProfile());
        });
    }
}