using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace DataCompile
{
    public class Item:DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
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

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
    }
}
