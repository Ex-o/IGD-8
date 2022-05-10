using Shared;
using Leopotam.Ecs;
using UnityEngine;

namespace CoinCounter
{
    public class CoinCounter : MonoBehaviour
    {
        private EcsEntity _ent;
        
        public void CreateEntity(EcsWorld world)
        {
            _ent = world.NewEntity();
            _ent.Get<Count>();
            _ent.Get<TransformObj>().Transform = transform;
        }
    }
}
