using Shared;
using Leopotam.Ecs;
using UnityEngine;

namespace Coin
{
    public class Coin : MonoBehaviour
    {
        private EcsEntity _entity;
        
        public void CreateEntity(EcsWorld world)
        {
            _entity = world.NewEntity();
            _entity.Get<CoinObj>();
            
            ref var transformRef = ref _entity.Get<TransformObj>();
            transformRef.Transform = transform;
        }

        public void OnTriggerEnter(Collider other)
        {
            _entity.Get<CoinPickedEvent>();
        }
    }
}
