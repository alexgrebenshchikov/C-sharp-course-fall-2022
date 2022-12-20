using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw15.Task3
{
    public class Client
    {
        private string Name { get; }


        public Client(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return "Client(" + Name + ")";
        }
    }
}
