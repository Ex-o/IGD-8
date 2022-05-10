using Leopotam.Ecs;
using Shared;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerSpeed _speed;
        public void CreateEntity(EcsWorld world)
        {
            var ent = world.NewEntity();
            
            ent.Get<PlayerObj>();
            ent.Get<Orientation>();
            ent.Get<TransformObj>().Transform = transform;
            ent.Get<PlayerSpeed>() = _speed;
        }
    }
}