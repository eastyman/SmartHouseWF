using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class GameBox :Device, ITVsourced
    {
        public GameBox(string name):base(name)
        {
            this.name = name;
        }
        public string Identify()
        {
            return "GameBox "+ this.ToString();
        }
    }
}
