using System;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.UserRegisterHandlers;

namespace MovieApi.WebApi.Extensions;

public static class ServiceRegistrationExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetCategoryQueryHandler>();
        services.AddScoped<GetCategoryByIdQueryHandler>();
        services.AddScoped<CreateCategoryCommandHandler>();
        services.AddScoped<UpdateCategoryCommandHandler>();
        services.AddScoped<RemoveCategoryCommandHandler>();
        services.AddScoped<GetMovieWithCategoryQueryHandler>();

        services.AddScoped<GetMovieByIdQueryHandler>();
        services.AddScoped<GetMovieQueryHandler>();
        services.AddScoped<CreateMovieCommandHandler>();
        services.AddScoped<UpdateMovieCommandHandler>();
        services.AddScoped<RemoveMovieCommandHandler>();

        services.AddScoped<GetSeriesByIdQueryHandler>();
        services.AddScoped<GetSeriesQueryHandler>();
        services.AddScoped<CreateSeriesCommandHandler>();
        services.AddScoped<UpdateSeriesCommandHandler>();
        services.AddScoped<RemoveSeriesCommandHandler>();
        services.AddScoped<GetSeriesWithCategoryQueryHandler>();

        services.AddScoped<CreateUserRegisterCommandHandler>();



        return services;
    }
}
