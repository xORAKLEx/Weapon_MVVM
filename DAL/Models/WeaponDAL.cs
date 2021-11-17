using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class WeaponDAL
    {
        public WeaponDAL()
        {
        }

        public WeaponDAL(string name, int type, int ammoCount, string ammoSize)
        {
            Name = name;
            Type = type;
            AmmoCount = ammoCount;
            AmmoSize = ammoSize;
        }

        public string Name { get; set; }

        public int Type { get; set; }

        public int AmmoCount { get; set; }

        public string AmmoSize { get; set; }
    }
}
