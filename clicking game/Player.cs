using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clicking_game
{
    /// <summary>
    /// read Player info.
    /// </summary>
    class Player
    {

        public int Coins()
        {
            return new UserDataAPI().handleSimpleVars()[0];
        }
        public int Multiplier()
        {
            return new UserDataAPI().handleSimpleVars()[1];
        }
        public int APSpeed()
        {
            return new UserDataAPI().handleSimpleVars()[2];
        }
        public bool OwnsAutoClick()
        {
            return new UserDataAPI().handleConVars()[1];
        }
        public bool HasAddonsEnabled()
        {
            return new UserDataAPI().handleConVars()[0];
        }
    }
}
