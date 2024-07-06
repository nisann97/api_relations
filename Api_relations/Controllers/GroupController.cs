using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.DTOs.Groups;
using Service.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_relations.Controllers
{
    [Route("api/[controller]/[action]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {

            _groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateDto request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _groupService.CreateAsync(request);
            return CreatedAtAction(nameof(Create), new { response = "Success" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _groupService.GetAllAsync());

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _groupService.GetByIdAsync(id));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithStudents()
        {
            return Ok(await _groupService.GetAllWithStudentsAsync());

        }

       
    }


    }

