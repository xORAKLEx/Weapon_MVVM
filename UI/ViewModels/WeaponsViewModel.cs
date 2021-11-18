using BLL.Core;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UI.Commands;
using UI.Models;

namespace UI.ViewModels
{
    public class WeaponsViewModel
    {
        private readonly WeaponService service;

        public WeaponsViewModel()
        {
            Weapons = new ObservableCollection<Weapon>();

            service = new WeaponService();

            foreach (var item in service.Restore())
            {
                var weapon = new Weapon();
                weapon.CopyFromBLL(item);
                Weapons.Add(weapon);
            }

            AddWeaponCommand = new RelayCommand(AddWeapon);
            ChangeWeaponCommand = new RelayCommand(ChangeWeapon);
            RemoveWeaponCommand = new RelayCommand(RemoveWeapon);
            CloseCommand = new RelayCommand(Close);
        }

        public ObservableCollection<Weapon> Weapons { get; }

        public IRelayCommand AddWeaponCommand { get; }

        public IRelayCommand ChangeWeaponCommand { get; }

        public IRelayCommand RemoveWeaponCommand { get; }

        public IRelayCommand CloseCommand { get; }

        private void Close(object sender)
        {
            service.Save();
            var window = sender as Window;
            window.Close();
        }

        private void RemoveWeapon(object sender)
        {
            var weapon = sender as Weapon;
            Weapons.Remove(weapon);
            service.RemoveWeapon(weapon.ConvertToBLL());
        }

        private void ChangeWeapon(object sender)
        {
            var changeViewModel = new ChangeWeaponViewModel(sender as Weapon);
            changeViewModel.WeaponChanged += ChangeViewModel_WeaponChanged;

            var window = new ChangeWeaponWindow();
            window.DataContext = changeViewModel;
            window.ShowDialog();

            changeViewModel.WeaponChanged -= ChangeViewModel_WeaponChanged;
        }

        private void ChangeViewModel_WeaponChanged(Weapon old, Weapon weapon)
        {
            var index = Weapons.IndexOf(old);
            Weapons.RemoveAt(index);
            Weapons.Insert(index, weapon);

            service.ChangeWeapon(weapon.ConvertToBLL(),index);
        }

        private void AddWeapon(object sender)
        {
            var addViewModel = new AddWeaponViewModel();
            addViewModel.WeaponCreated += AddViewModel_WeaponCreated;

            var window = new AddWeaponWindow();
            window.DataContext = addViewModel;
            window.ShowDialog();

            addViewModel.WeaponCreated -= AddViewModel_WeaponCreated;
        }

        private void AddViewModel_WeaponCreated(Weapon obj)
        {
            Weapons.Add(obj);

            service.AddWeapon(obj.ConvertToBLL());
        }
    }
}
