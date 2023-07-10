using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REST_API.Dto;
using REST_API.Interfaces;
using REST_API.Models;
using REST_API.Repository;
using System.Collections.Generic;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DzīvoklisController : Controller
    {
        private readonly IDzīvoklis _dzīvoklisRepository;
        private readonly IMapper _mapper;
        private readonly IMāja _majaRepository;
        private readonly IIedzīvotājs _iedzīvotājsRepository;

        public DzīvoklisController(IDzīvoklis dzīvoklisRepository, IMapper mapper ,
            IMāja majaRepository, IIedzīvotājs iedzīvotājsRepository
            )
        {
            _dzīvoklisRepository = dzīvoklisRepository;
            _mapper = mapper;
            _majaRepository = majaRepository;
            _iedzīvotājsRepository = iedzīvotājsRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Dzīvoklis>))]

        public IActionResult GetDzīvokļi()
        {
            var dzīvokļi = _mapper.Map<List<DzīvoklisDto>>(_dzīvoklisRepository.GetDzīvokļus());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dzīvokļi);
        }

        [HttpGet("{dzīvoklisId}")]
        [ProducesResponseType(200, Type = typeof(Dzīvoklis))]
        [ProducesResponseType(400)]
        public IActionResult GetDzīvoklis(int dzīvoklisId)
        {
            if (!_dzīvoklisRepository.DzīvoklisExists(dzīvoklisId))
                return NotFound();

            var dzivoklis = _mapper.Map<DzīvoklisDto>(_dzīvoklisRepository.GetDzīvoklis(dzīvoklisId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dzivoklis);
        }

        [HttpGet("mājaId/{id}")]
        [ProducesResponseType(200, Type = typeof(Dzīvoklis))]
        [ProducesResponseType(404)]
        public IActionResult GetDzīvokļiByMājaId(int id)
        {
            if (!_dzīvoklisRepository.DzīvoklisExists(id))
                return NotFound();

            var dzīvokļi = _dzīvoklisRepository.GetDzīvokļusByMajaId(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(dzīvokļi);
        }

        [HttpGet("AllDzivoklis/{majaId}")]
        [ProducesResponseType(200, Type = typeof(Dzīvoklis))]
        [ProducesResponseType(404)]
        public IActionResult GetDzīvoklisAndIedzīvotājis(int majaId)
        {
            var dzīvoklis = _dzīvoklisRepository.GetDzīvoklisAndMaja(majaId);

            if (dzīvoklis == null)
            {
                return NotFound();
            }

            return Ok(dzīvoklis);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDzīvoklis([FromQuery] int iedzivotajs,[FromBody] DzīvoklisDto dzivoklisCreate)
        {
            if (dzivoklisCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var majaid = _majaRepository.GetMājas()
                .FirstOrDefault(m => m.Id == dzivoklisCreate.MājaId);

            if (majaid == null)
            {
                ModelState.AddModelError("", "Tāds mājas ID neeksistē");
                return StatusCode(422, ModelState);
            }

            var dzivoklisMap = _mapper.Map<Dzīvoklis>(dzivoklisCreate);


            if (!_dzīvoklisRepository.CreateDzīvoklis(iedzivotajs, dzivoklisMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja grizi saglabajot");
                return StatusCode(500, ModelState);
            }

            return Ok(dzivoklisMap);
        }

        [HttpPut("{dzivoklisId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdateMaja(int dzivoklisId, [FromBody] DzīvoklisDto updateDzivoklis)
        {
            if (updateDzivoklis == null)
                return BadRequest(ModelState);

            if (dzivoklisId != updateDzivoklis.Id)
                return BadRequest(ModelState);

            if (!_dzīvoklisRepository.DzīvoklisExists(dzivoklisId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var dzivoklisMap = _mapper.Map<Dzīvoklis>(updateDzivoklis);

            if (!_dzīvoklisRepository.UpdateDzīvoklis(dzivoklisMap))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi atjauninājot");
                return StatusCode(500, ModelState);
            }

            return Ok(dzivoklisMap);
        }

        [HttpDelete("{dzivoklisId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult DeleteMaja(int dzivoklisId)
        {
            if (!_dzīvoklisRepository.DzīvoklisExists(dzivoklisId))
            {
                return NotFound();
            }

            var dzivoklisToDelete = _dzīvoklisRepository.GetDzīvoklis(dzivoklisId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            if (!_dzīvoklisRepository.DeleteDzīvoklis(dzivoklisToDelete))
            {
                ModelState.AddModelError("", "Kaut kas nogāja greizi dzēšot");
            }
            return Ok(dzivoklisToDelete);
        }
    }
}
