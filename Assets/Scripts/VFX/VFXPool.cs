using CosmicCuration.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmicCuration.VFX
{
    internal class VFXPool : GenericObjectPool<VFXController>
    {
        private VFXView vfxPrefab;

        public VFXPool(VFXView vfxPrefab) => this.vfxPrefab = vfxPrefab;

        public VFXController GetVFX() => GetItem<VFXController>();

        protected override VFXController CreateItem<T>() => new VFXController(vfxPrefab);
    }
}
