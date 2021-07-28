using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class Raccon : Enemy
    {
        public Enemy Enemy { get; set; }
        public Player Player { get; set; }
        public Walrus Walrus { get; set; }
        // Start is called before the first frame update
        void Start()
        {
            Energy = 10;
            MaxEnergy = 10;
            Attack = 7;
            Defense = 3;
            Gold = 20;
            Description = "Racoon";
            Inventory.Add("Bandit Mask");
        }
    }
}
