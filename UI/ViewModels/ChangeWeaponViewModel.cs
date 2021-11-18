using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Commands;
using UI.Models;

namespace UI.ViewModels
{
    public class ChangeWeaponViewModel
    {
        private readonly Weapon oldWeapon;

        public event Action<Weapon, Weapon> WeaponChanged;

        public ChangeWeaponViewModel(Weapon weapon)
        {
            ChangeWeaponCommand = new RelayCommand(ChangeWeapon);
            Types = Enum.GetNames(typeof(WeaponType));
            oldWeapon = weapon;
            Name = weapon.Name;
            Type = weapon.Type;
            AmmoCount = weapon.AmmoCount;
            AmmoSize = weapon.AmmoSize;
        }

        public string Name { get; set; }

        public WeaponType Type { get; set; }

        public Array Types { get; }

        public int AmmoCount { get; set; }

        public string AmmoSize { get; set; }

        public IRelayCommand ChangeWeaponCommand { get; }

        private void ChangeWeapon(object obj)
        {
            WeaponChanged.Invoke(oldWeapon, new Weapon(Name, Type, AmmoCount, AmmoSize));

            var window = obj as Window;
            window.Close();
        }
    }
}
