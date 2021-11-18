using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Serializers
{
    public class WeaponSerializer
    {
        
        public void Serialize(List<WeaponDAL> weapons)
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("weapons.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, weapons);
            }
        }

        public List<WeaponDAL> Deserialize()
        {
            var formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("weapons.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    var weapons = (List<WeaponDAL>)formatter.Deserialize(fs);

                    return weapons ?? new List<WeaponDAL>();
                }
                catch (Exception)
                {

                    return new List<WeaponDAL>();
                }
                
            }
        }

    }
}
