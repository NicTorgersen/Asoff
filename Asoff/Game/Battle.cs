using Asoff.Models;
using Asoff.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asoff
{
    class Battle
    {

        private Player _player;
        private Enemy _enemy;
        private bool _playersTurn;

        public Battle(Player player, Enemy enemy)
        {
            this._player = player;
            this._enemy = enemy;
        }
        public void StartBattle()
        {
            if (_player.GetStatPoint("Agility") > _enemy.GetStatPoint("Defense"))
            {

            }
        }

        public void Attack()
        {
            
        }

        public void EndTurn()
        {

        }

        public void EndBattle()
        {

        }
    }
}
