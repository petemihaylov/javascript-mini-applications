using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using WebApi.Dtos;
using WebApi.Services;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        private readonly IMailService _mailService;

        public ParticipantsController(IParticipantService participantService, IMailService mailService)
        {
            _participantService = participantService;
            _mailService = mailService;
        }


        // GET api/participants
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participant>>> GetAllParticipants()
        {
            var participants = await _participantService.GetParticipantsAsync();
            if (participants != null) return Ok(participants);
            return NotFound();
        }

        // GET api/participants/{id}
        [Authorize]
        [HttpGet("{id}", Name = "GetparticipantById")]
        public async Task<ActionResult<Participant>> GetparticipantById(Guid id)
        {
            return Ok(await _participantService.GetParticipantByIdAsync(id));
        }

        // POST api/partisipant
        [HttpPost]
        public async Task<IActionResult> AddParticipant(ParticipantDto participantDto)
        {
            if(_mailService.IsValidEmail(participantDto.Email))
            {
                var participant = _participantService.AddParticipant(participantDto);

                if(participant != null)
                {
                    await _mailService.SendMailAsync(participant.Email, "Wedding's day ", $"{participant.FirstName} {participant.LastName}");
                    return Ok(participant);
                }
            }

            return BadRequest(participantDto);
        }

        // PUT api/participants/{id}
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateParticipant(ParticipantDto participantDto)
        {
            var participant = await _participantService.UpdateParticipantAsync(participantDto);
            return participant != null ? Ok(participant) : BadRequest();
        }


        // DELETE api/participants/{id}
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Participant>> DeleteParticipant(Guid id)
        {
            var participant = await _participantService.DeleteParticipantAsync(id);
            return participant != null ? Ok(participant) : BadRequest();
        }
    }
}