﻿using AutoMapper;
using FluentValidation;
using Shop.Api.Validations;
using Shop.Application.Services;
using Shop.Contract.Dtos;
using Shop.Contract.Interfaces.Repositories;
using Shop.Contract.Interfaces.Services;
using Shop.Persistence.Repositories;

namespace Shop.Api.Helper
{
    public static class DiRegister
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryService>();
        }
        public static void AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CategoryRequest>, CategoryRequestValidator>();
        }
        public static void AddAoutomapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
