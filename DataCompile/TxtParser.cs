using System;
using System.IO;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

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
            List<string> properties = new List<string>();
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Item temp = new Item();
                    temp.Name = line.Substring(7);
                    temp.Gold = (float)Convert.ToDouble(sr.ReadLine().Replace(",",string.Empty));
                    while ((line = sr.ReadLine()) != "")
                    {
                        line = line.Substring(2);
                        int i = 0;
                        while(line[i]!=' ')
                        {
                            i += 1;
                        }
                        string value = line.Remove(i);
                        string propertyName = line.Substring(i).Replace(" ", string.Empty);
                        properties.Add(propertyName);
                        typeof(Item).GetProperty(propertyName).SetValue(temp, value);
                    }
                    result.Add(temp);
                }
            }
            properties = properties.Distinct().ToList();
            using(StreamWriter sw = new StreamWriter("properties.txt"))
            {
                foreach(var s in properties)
                {
                    sw.WriteLine(s);
                }
            }
            return result;
        }
}
}
