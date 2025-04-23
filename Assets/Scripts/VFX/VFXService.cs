using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private VFXPool VFXPool;
        private List<VFXData> vfxData = new List<VFXData>();

        public VFXService(VFXScriptableObject vfxScriptableObject)
        {
            VFXPool = new VFXPool(vfxScriptableObject.vfxData[0].prefab);
            vfxData = vfxScriptableObject.vfxData;
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            VFXController vfxToPlay = VFXPool.GetVFx();
            vfxToPlay.Configure(spawnPosition);
        }
    } 
}