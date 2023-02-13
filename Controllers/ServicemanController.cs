using AutoMapper;
using Esevice2._0.data;
using Esevice2._0.dtos;
using Esevice2._0.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esevice2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicemanController : Controller
    {
        IServicemanRepository repo;
        IMapper _mapper;

        public ServicemanController(IServicemanRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("search/{city}")]
        public async Task<ActionResult<IEnumerable<ServicemanReadDto>>> GetByCity(string city)
        {
            var servicemanList = await repo.FindByCity(city);
            if (servicemanList != null)
            {
                var sermanReadDto = _mapper.Map<IEnumerable<ServicemanReadDto>>(servicemanList);
                return Ok(sermanReadDto);
            }
            return NotFound("Serviceman of your requirement is not available");

        }
        [HttpGet ]
        [Route("search/{category}")]
      
        public async Task<ActionResult<IEnumerable<ServicemanReadDto>>> GetByCategory(string category)
        {
            var servicemanList = await repo.FindByCategory(category);
            if (servicemanList != null)
            {
                var sermanReadDto = _mapper.Map<IEnumerable<ServicemanReadDto>>(servicemanList);
                return Ok(sermanReadDto);
            }
            return NotFound("Serviceman of your requirement is not available");

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicemanReadDto>>> GetAll()
        {
            var servicemanList = await repo.FindAll();
            if (servicemanList == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<ServicemanReadDto>>(servicemanList));

        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ServicemanReadDto>> GetById(int id)
        {
            ServiceMan s = await repo.FindById(id);
            if (s != null)
            {
                return Ok(_mapper.Map<ServicemanReadDto>(s));
            }
            return NotFound("Id not FOund");

        }
        [HttpPost]
        public async Task<ActionResult<ServicemanCreateDto>> CreateNewServiceman(ServicemanCreateDto servicemanCreateDto)
        {
            ServiceMan s = _mapper.Map<ServiceMan>(servicemanCreateDto);

            var result = await repo.AddNewServiceman(s);
            if (!result)
            {
                return BadRequest("the serviceman not added");
            }
            var sermanReadDto = _mapper.Map<ServicemanReadDto>(s);
            return CreatedAtRoute(nameof(GetById), new { id = servicemanCreateDto.ServicemanId }, sermanReadDto);
        }
        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, ServicemanUpdateDto updateDto)
        {
            var sermanFound = await repo.FindById(id);
            if (sermanFound == null)
            {
                return NotFound($"Id {id} doesnt exist");
            }
            _mapper.Map(updateDto, sermanFound);//upadting of price and category is done here
            var res = await repo.UpdateServicemanDetails(sermanFound);//update product is replaced in the list
            if (res)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var sermanFound = await repo.FindById(id);
            if (sermanFound == null)
            {
                return NotFound($"Id {id} doesnt exist");
            }
            var res = await repo.DeleteServiceman(sermanFound);
            if (res)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
