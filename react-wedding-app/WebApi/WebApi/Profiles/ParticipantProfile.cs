using AutoMapper;
using WebApi.Models;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class ParticipantsProfile : Profile
    {
        public ParticipantsProfile()
        {
            // Source to Destination
            CreateMap<ParticipantDto, Participant>();
        }
    }
}