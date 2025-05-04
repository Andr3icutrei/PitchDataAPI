using Microsoft.Extensions.DependencyInjection;
using PitchData.Core.Services.Interfaces;
using PitchData.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitchData.Core
{
    public static class DIConfig
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerService, PlayerService>();
            services.AddScoped<INationalTeamService, NationalTeamService>();
            services.AddScoped<IClubTeamService, ClubTeamService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IInternationalTrophyService, InternationalTrophyService>();
            services.AddScoped<IClubTrophyService, ClubTrophyService>();

            return services;
        }

    }
}
