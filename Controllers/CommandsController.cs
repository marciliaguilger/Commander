using System.Collections.Generic;
using commander.Data;
using commander.Models;
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

        public CommandsController(ICommanderRepo repository)
        {
            _repository = repository;
        }
        
        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }

        //GET api/commands/{id}
        [HttpGet("{id}")]
        public  ActionResult <Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            return Ok(commandItem);
        }

    }
}