using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using REST_API.Dto;
using REST_API.Interfaces;
using REST_API.Models;
using REST_API.Repository;
using System.Collections.Generic;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IedzīvotājsController : Controller
    {
        private readonly IIedzīvotājs _iedzīvotājsRepository;
        private readonly IMapper _mapper;

        public IedzīvotājsController(IIedzīvotājs iedzīvotājsRepository, IMapper mapper)
        {
            _iedzīvotājsRepository = iedzīvotājsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Iedzīvotājs>))]

        public IActionResult GetIedzīvotāji()
        {
            var iedzīvotāji = _mapper.Map<List<Iedzīvotājs>>(_iedzīvotājsRepository.GetIedzīvotāji());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(iedzīvotāji);
        }

        [HttpGet("{iedzīvotājsId}")]
        [ProducesResponseType(200, Type = typeof(Iedzīvotājs))]
        [ProducesResponseType(400)]
        public IActionResult GetIedzīvotājs(int iedzīvotājsId)
        {
            if (!_iedzīvotājsRepository.IedzīovtājsExists(iedzīvotājsId))
                return NotFound();

            var iedzīvtājs = _mapper.Map<IedzīvotājsDto>(_iedzīvotājsRepository.GetIedzīvotājs(iedzīvotājsId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(iedzīvtājs);
        }

        [HttpGet("{dzivoklisId}/iedzivotaji")]
        [ProducesResponseType(200, Type = typeof(Iedzīvotājs))]
        [ProducesResponseType(400)]
        public IActionResult GetIedzīvotājusByDzivoklisId(int dzivoklisId)
        {
            var iedzīvotājus = _mapper.Map < List<IedzīvotājsDto>>(_iedzīvotājsRepository.GetIedzīvotājusByDzivoklisId(dzivoklisId));
            return Ok(iedzīvotājus);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateIedzīvotājs([FromQuery] int dzivoklis, [FromBody] IedzīvotājsDto iedzivotajsCreate)
        {
            if (iedzivotajsCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var iedzīvotājaMap = _mapper.Map<Iedzīvotājs>(iedzivotajsCreate);

            if (!_iedzīvotājsRepository.CreateIedzīvotājs(dzivoklis, iedzīvotājaMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja grizi saglabajot");
                return StatusCode(500, ModelState);
            }

            return Ok(iedzīvotājaMap);
        }

        [HttpPut("{iedzivotajsId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateMaja(int iedzivotajsId, [FromBody] IedzīvotājsDto updateIedzivotajs)
        {
            if (updateIedzivotajs == null)
                return BadRequest(ModelState);

            if (iedzivotajsId != updateIedzivotajs.Id)
                return BadRequest(ModelState);

            if (!_iedzīvotājsRepository.IedzīovtājsExists(iedzivotajsId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var iedzivotajsMap = _mapper.Map<Iedzīvotājs>(updateIedzivotajs);

            if (!_iedzīvotājsRepository.UpdateIedzīvotājs(iedzivotajsMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi atjauninājot");
                return StatusCode(500, ModelState);
            }

            return Ok(iedzivotajsMap);
        }

        [HttpDelete("{iedzivotajsId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteMaja(int iedzivotajsId)
        {
            if (!_iedzīvotājsRepository.IedzīovtājsExists(iedzivotajsId))
            {
                return NotFound();
            }

            var iedzivotajsToDelete = _iedzīvotājsRepository.GetIedzīvotājs(iedzivotajsId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_iedzīvotājsRepository.DeleteIedzīvotājs(iedzivotajsToDelete))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi dzēšot");
            }
            return Ok(iedzivotajsToDelete);
        }
    }
}
