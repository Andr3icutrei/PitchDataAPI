using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PitchData.Database.Context;
using PitchData.Database.Repositories.Interfaces;
using PitchData.Database.Repositories;
using PitchData.Database.Entities;

namespace PitchData.Database;

public static class DIConfig
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<PitchDataDatabaseContext>();
        services.AddScoped<DbContext, PitchDataDatabaseContext>();

        services.AddScoped<INationalTeamRepository, NationalTeamsRepository>();
        services.AddScoped<IClubTeamRepository, ClubTeamRepository>();

        services.AddScoped<IPlayerRepository, PlayerRepository>();

        services.AddScoped<ICoachRepository, CoachesRepository>();

        services.AddScoped<IInternationalTrophyRepository, InternationalTrophiesRepository>();
        services.AddScoped<IClubTrophyRepository, ClubTrophiesRepository>();

        return services;
    }
}