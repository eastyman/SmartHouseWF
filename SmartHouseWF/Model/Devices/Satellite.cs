using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class Satellite : Device, ITVsourced
    {
        public Satellite(string name)
            : base(name)
        {
            this.name = name;
        }
        public string Identify()
        {
            return "Спутниковый тюнер " + this.ToString();
        }
    }
}
