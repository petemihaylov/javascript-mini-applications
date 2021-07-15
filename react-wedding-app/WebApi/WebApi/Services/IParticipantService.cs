using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Models;
using WebApi.Dtos;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IParticipantService
    {
        public Participant AddParticipant(ParticipantDto p);

        Task<Participant> AddParticipantAsync(ParticipantDto p);

        public Participant DeleteParticipant(Guid id);

        Task<Participant> DeleteParticipantAsync(Guid id);

        public Participant GetParticipantById(Guid id);

        Task<Participant> GetParticipantByIdAsync(Guid id);

        public IQueryable<Participant> GetParticipants();

        Task<IQueryable<Participant>> GetParticipantsAsync();

        public Participant UpdateParticipant(ParticipantDto p);

        Task<Participant> UpdateParticipantAsync(ParticipantDto p);
    }
}