using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataCompile
{
    public class Item
    {
        /// <summary>
        /// Properties
        /// </summary>
        [Key]
        public string Name { get; set; }

        public float Gold { get; set; }

        public string MovementSpeed { get; set; }
        public string SelectedAttribute { get; set; }
        public string AttackSpeed { get; set; }
        public string Damage { get; set; }
        public string AllAttributes { get; set; }
        public string Health { get; set; }
        public string Mana { get; set; }
        public string HPRegeneration { get; set; }
        public string Strength { get; set; }
        public string Armor { get; set; }
        public string Intelligence { get; set; }
        public string Agility { get; set; }
        public string ManaRegeneration { get; set; }
        public string Evasion { get; set; }
        public string MagicResistance { get; set; }
        public string SpellAmplification { get; set; }
        public string ManacostandManalossReduction { get; set; }
    }
}
