using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Battle
{
    class Player
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int Health { get; set; }
        public string Weapon { get; set; }
        public int Damage { get; set; }
        public ArrayList Inventory { get; set; }
    }
}
