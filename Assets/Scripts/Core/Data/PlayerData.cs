using System;

namespace Game.Core
{
    public class PlayerData : Singleton<PlayerData>
    {
        public float Gold = 100;
        public float Health = 100;
        public string Location = "Forest";
        public TimeSpan VIPDuration = TimeSpan.FromSeconds(45);

        public float ReservedGold;
        public float ReservedHealth;
        public string ReservedLocation;
        public TimeSpan ReservedVIPDuration;
    }
}
