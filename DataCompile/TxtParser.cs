using System;
using System.IO;
using System.Collections.Generic;

namespace DataCompile
{
    public class TxtParser
    {

        static public List<Hero> ParseHeroes(string path)
        {
            List<Hero> result = new List<Hero>();
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    result.Add(new Hero());
                    // Name
                    result[i].Name = line.Substring(8);
                    // Strength
                    line = sr.ReadLine();
                    string tempStr = line.Substring(5);
                    result[i].BaseStr = (float)Convert.ToDouble(tempStr.Remove(2));
                    result[i].LvUpStr = (float)Convert.ToDouble(tempStr.Substring(4));
                    // Agility
                    line = sr.ReadLine();
                    tempStr = line.Substring(5);
                    result[i].BaseAgi = (float)Convert.ToDouble(tempStr.Remove(2));
                    result[i].LvUpAgi = (float)Convert.ToDouble(tempStr.Substring(4));
                    // Intelligence
                    line = sr.ReadLine();
                    tempStr = line.Substring(5);
                    result[i].BaseInt = (float)Convert.ToDouble(tempStr.Remove(2));
                    result[i].LvUpInt = (float)Convert.ToDouble(tempStr.Substring(4));
                    // Movement speed
                    line = sr.ReadLine();
                    result[i].BaseMovSpeed = (float)Convert.ToDouble(line.Substring(16));
                    // Sight range
                    line = sr.ReadLine();
                    tempStr = line.Substring(13);
                    string[] spStr = tempStr.Split('^');
                    result[i].BaseDaySightRange = (float)Convert.ToDouble(spStr[0]);
                    result[i].BaseNightSightRange = (float)Convert.ToDouble(spStr[1]);
                    // Armor
                    line = sr.ReadLine();
                    result[i].BaseArmor = (float)Convert.ToDouble(line.Substring(7));
                    // Base Attack Time
                    line = sr.ReadLine();
                    result[i].BaseAtkTime = (float)Convert.ToDouble(line.Substring(18));
                    // Damage
                    line = sr.ReadLine();
                    tempStr = line.Substring(8);
                    result[i].BaseDmgLower = (float)Convert.ToDouble(tempStr.Remove(2));
                    result[i].BaseDmgUpper = (float)Convert.ToDouble(tempStr.Substring(5));
                    // Attack point
                    line = sr.ReadLine();
                    result[i].BaseAtkPt = (float)Convert.ToDouble(line.Substring(14));
                    // Reading out the space
                    line = sr.ReadLine();
                    i += 1;
                }

            }
            return result;
        }

        static public List<Item> ParseItems(string path)
        {
            List<Item> result = new List<Item>();
            return result;
        }
}
}
