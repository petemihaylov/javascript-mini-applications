using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Contracts;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ParticipantService(IMapper mapper, IRepositoryWrapper repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Participant AddParticipant(ParticipantDto participantDto)
        {
            var participant = _mapper.Map<Participant>(participantDto);

            participant.Id =  Guid.NewGuid();
            _repository.Participant.Create(participant);
            _repository.Save();
            return participant;
        }

        public async Task<Participant> AddParticipantAsync(ParticipantDto participantDto)
        {
            return await Task.FromResult(AddParticipant(participantDto));
        }

        public Participant DeleteParticipant(Guid id)
        {
            var participant = GetParticipantById(id);
            _repository.Participant.Delete(participant);
            _repository.Save();
            return participant;
        }

        public async Task<Participant> DeleteParticipantAsync(Guid id)
        {
            return await Task.FromResult(DeleteParticipant(id));
        }

        public Participant GetParticipantById(Guid id)
        {
            try
            {

                return _repository.Participant.FindByCondition(u => u.Id.Equals(id)).First();
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Participant> GetParticipantByIdAsync(Guid id)
        {
            return await Task.FromResult(GetParticipantById(id));
        }

        public IQueryable<Participant> GetParticipants()
        {
            return _repository.Participant.FindAll();
        }

        public async Task<IQueryable<Participant>> GetParticipantsAsync()
        {
            return await Task.FromResult(GetParticipants());
        }

        public Participant UpdateParticipant(ParticipantDto participantDto)
        {
            var participant = GetParticipantById(participantDto.Id);
            _mapper.Map(participantDto, participant);
            _repository.Participant.Update(participant);
            _repository.SaveAsync();
            return participant;
        }

        public async Task<Participant> UpdateParticipantAsync(ParticipantDto participantDto)
        {
            return await Task.FromResult(UpdateParticipant(participantDto));
        }
    }
}