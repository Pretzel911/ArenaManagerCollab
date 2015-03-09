using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaManager
{
    class Map
    {
        public int MapLocationX { get; set; } //Current Map X Coord
        public int MapLocationY { get; set; } //Current Map Y Coord
        public string LocationDescription { get; set; } //The description of the location that the player sees
        public int WhichMenu { get; set; } //What menu will the player be using for this location//Menu 99 for starting city only
        public int AreaMonsterLevel { get; set; } //The monster level of the the location to determine which monsters can be rolled here//TODO add property to monsters for the monsters level
        public string MapEnvironment { get; set; } //Quick environment description EG: City, Grassland, Wasteland, Desert, Forest // Will be used to determine the type of monsters that spawn here//TODO implement a monsters property for where they live
                                                                                                    //TODO Monster tables by Monsterlevel and EnvironmentInhabited
                                                                                                    //Consider adding mapsubregions (example cave, town, city, tunnel) to map locations.
        public Map()
        {

        }
        public Map(string action)
        {
            if (action == "start")
            {
                GetMapStart();
            }
        }
        private void GetMapStart()
        {
            MapLocationX = 0;
            MapLocationY = 0;
            LocationDescription = "You are inside the city of Havenshire.\nTall buildings are all around you,\nincluding the battle arena where\nwarriors go to hone thier skills";
            MapEnvironment = "City";
            AreaMonsterLevel = 0;
            WhichMenu = 99;
        }
    }
}
