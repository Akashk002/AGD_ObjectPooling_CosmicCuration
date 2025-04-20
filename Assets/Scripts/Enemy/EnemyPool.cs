using CosmicCuration.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static CosmicCuration.Bullets.BulletPool;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyView enemyView;
        private EnemyScriptableObject enemyScriptableObject;
        private List<PooledEnemy> pooledEnemys = new List<PooledEnemy>();

        public EnemyPool(EnemyView EnemyView, EnemyScriptableObject enemyScriptableObject)
        {
            this.enemyView = EnemyView;
            this.enemyScriptableObject = enemyScriptableObject;
        }
        public EnemyController GetEnemy()
        {
            if (pooledEnemys.Count > 0)
            {
                PooledEnemy pooledEnemy = pooledEnemys.Find(item => !item.isUsed);
                if (pooledEnemy != null)
                {
                    pooledEnemy.isUsed = true;
                    return pooledEnemy.enemy;
                }
            }
            return CreateNewPooledEnemy();
        }

        private EnemyController CreateNewPooledEnemy()
        {
            PooledEnemy PooledEnemy = new PooledEnemy();
            PooledEnemy.enemy = new EnemyController(enemyView, enemyScriptableObject.enemyData);
            PooledEnemy.isUsed = true;
            pooledEnemys.Add(PooledEnemy);
            return PooledEnemy.enemy;
        }

        public void ReturnToEnemyPool(EnemyController returnEnemy)
        {
            PooledEnemy pooledEnemy = pooledEnemys.Find(item => item.enemy.Equals(returnEnemy));
            pooledEnemy.isUsed = false;
        }

        public class PooledEnemy
        {
            public EnemyController enemy;
            public bool isUsed;
        }
    }
}
