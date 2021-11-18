using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WeaponBLL
    {
        public WeaponBLL()
        {
        }

        public WeaponBLL(string name, int type, int ammoCount, string ammoSize)
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

        public WeaponDAL ConvertToDAL()
        {
            return new WeaponDAL(Name, Type, AmmoCount, AmmoSize);
        }

        public void CopyFromDAL(WeaponDAL weaponDAL)
        {
            Name = weaponDAL.Name;
            Type = weaponDAL.Type;
            AmmoCount = weaponDAL.AmmoCount;
            AmmoSize = weaponDAL.AmmoSize;
        } 
    }
}
