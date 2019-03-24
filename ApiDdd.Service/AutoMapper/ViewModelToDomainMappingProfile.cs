using ApiDdd.Application.ViewModel;
using ApiDdd.Domain.Entities;
using ApiDdd.Domain.Entities.Admin;
using ApiDdd.Service.ViewModel;
using AutoMapper;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<UserViewModel, User>()
            .ConstructUsing(u => new User(u.Name, u.Email, u.Password));

        CreateMap<LoginViewModel, User>()
            .ConstructUsing(l => new User(null, l.Email, l.Password));

        CreateMap<LoginViewModel, Login>()
            .ConstructUsing(l => new Login(l.Email, l.Password));

        CreateMap<ProductViewModel, Product>()
            .ConstructUsing(p => new Product(p.Name, p.Amount, p.Status));
    }
}