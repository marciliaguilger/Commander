using System.Collections.Generic;
using AutoMapper;
using commander.Data;
using commander.Models;
using Commander.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace commander.Controllers
{
    //api/commands

    //[Route("api/[controller]")] >> desta forma se a classe mudar de nome a rota tb muda.
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            // return Ok(commandItems);
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public  ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null)
                
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            
            return NotFound();
        }
        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            //commands profile -> mapeado
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commanReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return Ok(commanReadDto);
        }

    }
}