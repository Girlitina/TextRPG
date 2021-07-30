using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public interface IBaddie
    {
        void Cry();
        string Description { get; set; }
    }
    public class Enemy : Character, IBaddie
    {
        public string Description { get; set; }
        public override void TakeDamage(int amount)
        {
            base.TakeDamage(amount);
            UIController.OnEnemyUpdate(this);
            Debug.Log("This also happens, but only on enemy! Not other characters.");
        }

        public void Cry()
        {

        }
        public override void Die()
        {
            Encounter.OnEnemyDie();
            Energy = MaxEnergy;
            Debug.Log("Character die, was enemy.");
        }
    }
}
