using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TextRPG
{
    public class EnemyDatabase : MonoBehaviour
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public static EnemyDatabase Instance { get; set; }

        public List<IBaddie> Baddies { get; set; }
        // Start is called before the first frame update
        private void Awake()
        {
            Instance = this;
            foreach (Enemy enemy in GetComponents<Enemy>())
            {
                Debug.Log("Found enemy!");
                Enemies.Add(enemy);
            }
        }

        public Enemy GetRandomEnemy()
        {
            return Enemies[Random.Range(0, Enemies.Count)];
        }
    }
}
