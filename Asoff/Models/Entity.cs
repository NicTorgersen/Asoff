using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asoff.Models
{
    class Entity
    {
        public float Health { get; set; }

        public List<KeyValuePair<string, int>> StatPoints;
        public string Name { get; set; }
        public Location Location { get; set; }

        public Entity()
        {
            this.GenerateStatPoints();
        }

        public void GenerateStatPoints()
        {
            List<KeyValuePair<string, int>> stats = new List<KeyValuePair<string, int>>();
            string[] statNames = { "Intelligence", "Strength", "Agility", "Defense" };

            for (int i = 0; i < statNames.Length; i++)
            {
                stats.Add( new KeyValuePair<string, int>(statNames[i], new Random().Next(1, 10)) );
            }
        }

        public int GetStatPoint(string statPointName)
        {
            KeyValuePair<string, int> statPoint = StatPoints.Find(s => s.Key == statPointName);

            return statPoint.Value;
        }

    }
}
