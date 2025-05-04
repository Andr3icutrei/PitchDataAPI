using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PitchData.Core.Dtos;
using PitchData.Core.Dtos.Requests;
using PitchData.Database.Entities;

namespace PitchData.Core.Mapping
{
    public static class CoachMappingExtension
    {
        public static Coach ToEntity(this AddCoachRequest coachDto)
        {
            Coach coach = new Coach();

            coach.FirstName = coachDto.FirstName;
            coach.LastName = coachDto.LastName;
            coach.CareerWins = coachDto.CareerWins;
            coach.CareerDraws = coachDto.CareerDraws;
            coach.CareerLosses = coachDto.CareerLosses;
            coach.Nationality = coachDto.Nationality;

            return coach;
        }
    }
}
