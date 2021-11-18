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
    public class AddWeaponViewModel
    {
        public event Action<Weapon> WeaponCreated;

        public AddWeaponViewModel()
        {
            AddWeaponCommand = new RelayCommand(AddWeapon);
            Types = Enum.GetNames(typeof(WeaponType));
        }

        public string Name { get; set; }

        public WeaponType Type { get; set; }

        public Array Types { get; }

        public int AmmoCount { get; set; }

        public string AmmoSize { get; set; }

        public IRelayCommand AddWeaponCommand { get; }

        private void AddWeapon(object obj)
        {
            WeaponCreated.Invoke(new Weapon(Name, Type, AmmoCount, AmmoSize));

            var window = obj as Window;
            window.Close();
        }
    }
}
