using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asoff.UI;
using Asoff.Models;

namespace Asoff
{
    class Game
    {
        private Player _player;
        private List<Location> _locations;
        private List<Enemy> _enemies;

        private float _defaultHealth = 10f;

        private int clientWidth;
        private int clientHeight;

        public enum NSEW { North=0, South=1, East=2, West=3 }

        public Game(int width, int height)
        {
            this.clientWidth = width;
            this.clientHeight = height;

            SetupEnemies();
            SetupLocations();
            start();
        }

        private void SetupEnemies()
        {

        }

        private void SetupLocations()
        {
            this._locations = new List<Location>();

            Location startingArea = new Location(1, "Home", "Your home, it looks like it does every day.");
            Location work = new Location(2, "Work", "You don't really like your job.");

            startingArea.AdjacentLocations.Add(work);

            this._locations.Add(startingArea);
            this._locations.Add(work);
        }

        /*
         * This function is responsible for starting the game,
         * and giving the user the start menu for when she first
         * fires it up
         */
        public void start()
        {
            initStartScreen();
            Console.ReadLine();
        }

        public void initStartScreen()
        {
            string[] menuItems = { "New Game", "Exit" };

            int selected = Drawing.DrawMenuSelection(menuItems);

            switch (selected)
            {
                case 0:
                    NewGame();
                    break;
                case 1:
                    Environment.Exit(0);
                    break;
            }

        }

        public void NewGame()
        {
            string[] _nameQuestions = 
                {
                    "Welcome to Assoff.", 
                    "Could you me hand your ID, sir?"
                };

            string[] _storyElements = 
                {
                    "Height: **ft **in",
                    "Nationality: *******"
                };

            string _name;

            _name = Drawing.AskInfo(_nameQuestions, "passport", "Name", "text");

            Drawing.DramaticEffects(_storyElements, 500, true);

            /*
             * Initialize the user with default health value
             * The first location (which will always be the starting area
             * And the name input in the passport
             */
            this._player = new Player(this._defaultHealth, _locations[0], _name);

            LevelOne();
        }

        /*
         * Player wakes up
         */
        public void LevelOne()
        {
            Drawing.DramaticEffect("A few days earlier...", 500, true);

            string[] _storyElements =
                {
                    "It's early.",
                    "You notice the sun rays through the curtains.",
                    "Better get up..."
                };

            Drawing.DrawLocationName(this._player.Location.Name, true);
            Drawing.DrawLocationDescription(this._player.Location.Description, true);
            Drawing.DramaticEffects(_storyElements);

            Console.WriteLine("");

            string[] _menuItems1 = { "Go downstairs" };

            Drawing.DrawMenuSelection(_menuItems1);

            Console.Clear();

            Downstairs();
        }

        public void Downstairs()
        {
            Drawing.DrawLocationName(_player.Location.Name, true);
            Drawing.DrawLocationDescription("You went downstairs.", true);

            string[] _storyElements = 
                {
                    "It's clean.",
                    "",
                    "",
                    "There's someone in the other room..."
                };

            Drawing.DramaticEffects(_storyElements);

            string[] _actions = 
                {
                    "Check it out",
                    "Leave"
                };

            int answer = Drawing.DrawMenuSelection(_actions);

            switch (answer)
            {
                case 0:

                    break;
                case 1:

                    break;
            }
        }

        
    }
}
