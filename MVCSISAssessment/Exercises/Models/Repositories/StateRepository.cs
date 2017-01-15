using Exercises.Models.Data;
using System.Collections.Generic;
using System.Linq;

namespace Exercises.Models.Repositories
{
    public class StateRepository
    {
        private static List<State> _states;

        static StateRepository()
        {
            // sample data
            _states = new List<State>
            {
                new State { StateID=1, StateAbbreviation="KY", StateName="Kentucky" },
                new State { StateID=2, StateAbbreviation="MN", StateName="Minnesota" },
                new State { StateID=3, StateAbbreviation="OH", StateName="Ohio" },
            };
        }

        public static IEnumerable<State> GetAll()
        {
            return _states;
        }

        public static State Get(int stateID)
        {
            return _states.FirstOrDefault(c => c.StateID == stateID);
        }

        public static void Add(State state)
        {
             state.StateID = _states.Max(c => c.StateID) + 1;

            _states.Add(state);
        }

        public static void Edit(State state)
        {
            var selectedState = _states.First(c => c.StateID == state.StateID);

            selectedState.StateName = state.StateName;
            selectedState.StateAbbreviation = state.StateAbbreviation;
        }

        public static void Delete(int stateID)
        {
            _states.RemoveAll(c => c.StateID == stateID);
        }

    }
}