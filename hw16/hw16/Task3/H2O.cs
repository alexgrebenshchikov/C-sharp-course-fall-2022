using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw16.Task3
{
    public class H2O
    {
        public H2O()
        {
        }

        public void Hydrogen(Action releaseHydrogen)
        {
            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();
        }

        public void Oxygen(Action releaseOxygen)
        {
            // releaseOxygen() outputs "O". Do not change or remove this line.
            releaseOxygen();
        }
    }
}
