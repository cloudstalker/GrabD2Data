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
        [Key]
        public string Name { get; set; }

        public float Gold { get; set; }

    }
}
