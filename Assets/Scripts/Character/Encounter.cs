using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TextRPG
{
    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }
        public Chest Chest { get; set; }

        [SerializeField]
        Player player;

        [SerializeField]
        Button[] dynamicControls;

        public delegate void OnEnemyDieHandler();
        public static OnEnemyDieHandler OnEnemyDie;

        private void Start()
        {
            OnEnemyDie += Loot;
        }

        public void ResetDynamicControls()
        {
            foreach (Button button in dynamicControls)
            {
                button.interactable = false;
            }
        }

        public void StartCombat()
        {
            this.Enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
            UIController.OnEnemyUpdate(this.Enemy);
        }

        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void OpenChest()
        {
            Chest chest = player.Room.Chest;
            if (chest.Trap)
            {
                player.TakeDamage(5);
                Journal.Instance.Log("It was a trap! You took 5 dmg!");
            }
            else if (chest.Heal)
            {
                player.TakeDamage(-7);
                Journal.Instance.Log("It's contais healing spell! You gained 7 energy!");
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                player.Room.Chest = null;
                Journal.Instance.Log("You find an enemy in the chest!");
                player.Investigate();
            }
            else
            {
                player.Gold += chest.Gold;
                player.AddItem(chest.Item);
                UIController.OnPlayerStatChange();
                UIController.OnPlayerInventoryChange();
                Journal.Instance.Log("You found: " + chest.Item + " and <color=#56FC7FF>" + chest.Gold + "gold</color>");
            }
            player.Room.Chest = null;
            dynamicControls[3].interactable = false;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defense));
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defense));
            Journal.Instance.Log("<color=#59ffa1>You Attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>The enemy retaliated, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

        public void Flee()
        {
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defense) * 0.5f));
            player.Room.Enemy = null;
            UIController.OnEnemyUpdate(null);
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#59ffa1>You Attacked, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
        }

        public void ExitFloor()
        {
            StartCoroutine(player.world.GenrateFloor());
            player.Floor += 1;
            Journal.Instance.Log("You found an exit to another floor" + player.Floor);
        }

        public void Loot()
        {
            player.AddItem(this.Enemy.Inventory[0]);
            player.Gold += this.Enemy.Gold;
            Journal.Instance.Log(string.Format("<color=#56FC7FF>You've slain {0}. Searching the carcass, you find a {1} and {2} golds!</color>", 
                this.Enemy.Description, this.Enemy.Inventory[0], this.Enemy.Gold));
            player.Room.Enemy = null;
            player.Room.Empty = true;
            UIController.OnEnemyUpdate(this.Enemy);
            player.Investigate();

        }
    }
}
