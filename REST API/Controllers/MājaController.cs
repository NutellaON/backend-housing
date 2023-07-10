using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using REST_API.Dto;
using REST_API.Interfaces;
using REST_API.Models;
using REST_API.Repository;
using System.Collections.Generic;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MājaController : Controller
    {
        private readonly IMāja _mājaRepository;
        private readonly IMapper _mapper;

        public MājaController(IMāja mājaRepository, IMapper mapper)
        {
            _mājaRepository = mājaRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Māja>))]

        public IActionResult GetMājas()
        {
            var māja = _mapper.Map<List<MājaDto>>(_mājaRepository.GetMājas());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(māja);
        }

        [HttpGet("{majaId}")]
        [ProducesResponseType(200, Type = typeof(Māja))]
        [ProducesResponseType(400)]
        public IActionResult GetMāja(int majaId)
        {
            if (!_mājaRepository.MājaExists(majaId))
                return NotFound();

            var maja = _mapper.Map<MājaDto>(_mājaRepository.GetMāja(majaId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(maja);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMāja([FromBody] MājaDto majaCreate)
        {
            if (majaCreate == null)
                return BadRequest(ModelState);

            var maja = _mājaRepository.GetMājas()
                .Where(m => m.Iela.Trim().ToUpper() == majaCreate.Iela.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (maja != null)
            {
                ModelState.AddModelError("", "Māja jau eksistē");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var majaMap = _mapper.Map<Māja>(majaCreate);

            if (!_mājaRepository.CreateMāja(majaMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja grizi saglabajot");
                return StatusCode(500, ModelState);
            }

            return Ok(majaMap);
        }
        [HttpPut("{majaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateMaja(int majaId, [FromBody] MājaDto updateMaja )
        {
            if(updateMaja == null)
                return BadRequest(ModelState); 

            if(majaId != updateMaja.Id)
                return BadRequest(ModelState);

            if(!_mājaRepository.MājaExists(majaId))
                return NotFound();

            if(!ModelState.IsValid)
                return BadRequest();

            var majaMap = _mapper.Map<Māja>(updateMaja);

            if(!_mājaRepository.UpdateMāja(majaMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi atjauninājot");
                return StatusCode(500, ModelState); 
            }

            return Ok(majaMap);
        }

        [HttpDelete("{majaId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteMaja(int majaId) 
        {
            if(!_mājaRepository.MājaExists(majaId))
            {
                return NotFound();
            }

            var majaToDelete = _mājaRepository.GetMāja(majaId);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);


            if(!_mājaRepository.DeleteMāja(majaToDelete))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi dzēšot");
            }
            return Ok(majaToDelete);
        }


    }
}