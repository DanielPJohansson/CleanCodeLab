using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuessingGameCollection.GameComponents
{
    public interface IGameStrategy
    {
        public string GenerateRandomGoal();

    }
}