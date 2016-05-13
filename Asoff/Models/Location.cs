using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asoff.Models
{
    class Location
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Enemy> Enemies { get; set; }

        /*
         * Used to clarify locations adjacent to this location 
         * (locations that can be travelled to from this)
         */
        public List<Location> AdjacentLocations;

        public Location(int id, string name, string description, List<Location> adjacent = null)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;

            if (adjacent == null)
            {
                AdjacentLocations = new List<Location>();
            }
            else
            {
                AdjacentLocations = adjacent;
            }
            
        }

        public Location GetAdjacentLocationByName(string search)
        {
            return AdjacentLocations.Find(loc => loc.Name == search);
        }

    }
}
