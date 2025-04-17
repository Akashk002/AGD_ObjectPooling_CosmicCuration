using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
  
namespace CosmicCuration.Bullets
{
    public  class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;
        private List<PooledBullets> pooledBullets = new List<PooledBullets>();
        public BulletPool(BulletView BulletView , BulletScriptableObject bulletScriptableObject)
        {
            this.bulletView = BulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet()
        {
            if(pooledBullets.Count > 0)
            {
                PooledBullets pooledBullet = pooledBullets.Find(item => !item.isUsed);
                if (pooledBullet != null)
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bullet;
                }
            }
            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullets PooledBullet = new PooledBullets();
            PooledBullet.bullet = new BulletController(bulletView, bulletScriptableObject);
            PooledBullet.isUsed = true;
            return PooledBullet.bullet;
        }

        public class PooledBullets
        {
            public BulletController bullet;
            public bool isUsed;
        }
    }
}
