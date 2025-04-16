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

        public class PooledBullets
        {
            public BulletController bullet;
            public bool isUsed;
        }
    }
}
