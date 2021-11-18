using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Weapon
    {
        public Weapon()
        {
        }

        public Weapon(string name, WeaponType type, int ammoCount, string ammoSize)
        {
            Name = name;
            Type = type;
            AmmoCount = ammoCount;
            AmmoSize = ammoSize;
        }

        public string Name { get; set; }

        public WeaponType Type { get; set; }

        public int AmmoCount { get; set; }

        public string AmmoSize { get; set; }

        public WeaponBLL ConvertToBLL()
        {
            return new WeaponBLL (Name, (int)Type, AmmoCount, AmmoSize);
        }

        public void CopyFromBLL(WeaponBLL weaponBLL)
        {
            Name = weaponBLL.Name;
            Type = (WeaponType)weaponBLL.Type;
            AmmoCount = weaponBLL.AmmoCount;
            AmmoSize = weaponBLL.AmmoSize;
        }
    }
}
