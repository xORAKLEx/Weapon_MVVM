using BLL.Models;
using DAL.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class WeaponService
    {
        private readonly WeaponSerializer weaponSerializer;

        private List<WeaponBLL> weapons;

        public WeaponService()
        {
            weaponSerializer = new WeaponSerializer();
        }

        public void Save()
        {
            weaponSerializer.Serialize(weapons.Select(x => x.ConvertToDAL()).ToList());
        }

        public List<WeaponBLL> Restore()
        {
            var weaponsDAL = weaponSerializer.Deserialize();
            weapons = new List<WeaponBLL>();
            foreach (var item in weaponsDAL)
            {
                var weapon = new WeaponBLL();
                weapon.CopyFromDAL(item);
                weapons.Add(weapon);
            }
            return weapons;
        }

        public List<WeaponBLL> GetWeapons()
        {
            return weapons;
        }

        public void AddWeapon(WeaponBLL weapon)
        {
            weapons.Add(weapon);
        }

        public void ChangeWeapon(WeaponBLL weapon, int index)
        {
            weapons.RemoveAt(index);
            weapons.Insert(index, weapon);
        }

        public void RemoveWeapon(WeaponBLL weapon)
        {
            weapons.Remove(weapon);
        }

    }
}
