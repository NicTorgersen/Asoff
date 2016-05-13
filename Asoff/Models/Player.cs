using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asoff.Models
{
    class Player : Entity
    {
        public int WorkEthic { get; set; }
        public bool IsDead { get; set; }

        private int[] baseRandom = { 1, 10 };

        public Player(float health, Location currentLocation, string userName) : base()
        {
            this.Health = health;
            this.Location = currentLocation;
            this.Name = userName;

            this.WorkEthic = new Random().Next(this.baseRandom[0], this.baseRandom[1]);
        }

    }
}
