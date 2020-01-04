using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle
{
    class Enemy
    {
        private string Name;
        private string Weapon;
        private int Health;
        private int Damage;

        public Enemy(string ename, string eweapon, int ehealth, int edamage)
        {
            Name = ename;
            Weapon = eweapon;
            Health = ehealth;
            Damage = edamage;
        }

        public string GetName() {
            return Name;
        }

        public string GetWeapon()
        {
            return Weapon;
        }

        public int GetHealth()
        {
            return Health;
        }

        public int GetDamage()
        {
            return Damage;
        }

        public void SetHealth(int changeHealth)
        {
            Health = changeHealth;
        }
    }
}
