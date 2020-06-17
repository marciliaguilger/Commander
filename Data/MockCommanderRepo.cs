using System.Collections.Generic;
using commander.Models;

namespace commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id = 0, HowTo = "Boil an egg", Line="Boil water", Platform = "Kettle & Pan"},
                new Command{Id = 1, HowTo = "Cut bread", Line="get a knife", Platform = "Kettle & Pan"},
                new Command{Id = 2, HowTo = "Make cup of tea", Line="Place tea bad in cuple", Platform = "Kettle & Pan"}
            };

            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command{Id = 0, HowTo = "Boil an egg", Line="Boil water", Platform = "Kettle & Pan"};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}