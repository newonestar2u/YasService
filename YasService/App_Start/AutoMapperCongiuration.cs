namespace YasService
{
    using AutoMapper;
    using Models;

    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(a =>
            {
                a.CreateMissingTypeMaps = true;
                a.CreateMap<Employee, Employee>();
                a.CreateMap<Order, Order>();
                a.CreateMap<User, User>();
                a.CreateMap<Permission, Permission>();
                a.CreateMap<TeamPermission, TeamPermission>();
                a.CreateMap<Customer, Customer>();
                a.CreateMap<OrderLine, OrderLine>();
                a.CreateMap<Product, Product>();
            });
        }
    }
}