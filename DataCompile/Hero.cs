using System;
using System.IO;
using System.Linq;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace DataCompile
{
    public class Hero
    {
        [Key]
        public string Name { get; set; }
        //public float CurStr;
        //public float CurAgi;
        //public float CurInt;
        //public float MovSpeed;
        //public float DaySightRange;
        //public float NightSightRange;
        //public float AtkTime;
        //public float DmgLower;
        //public float DmgUpper;
        //public float AtkPt;
        //public int Level;
        public float BaseStr { get; set; }
        public float BaseAgi { get; set; }
        public float BaseInt { get; set; }
        public float LvUpStr { get; set; }
        public float LvUpAgi { get; set; }
        public float LvUpInt { get; set; }
        public float BaseMovSpeed { get; set; }
        public float BaseDaySightRange { get; set; }
        public float BaseNightSightRange { get; set; }
        public float BaseArmor { get; set; }
        public float BaseAtkTime { get; set; }
        public float BaseDmgLower { get; set; }
        public float BaseDmgUpper { get; set; }
        public float BaseAtkPt { get; set; }

        public Hero()
        {
            
        }

    }
}
