using Leopotam.Ecs;
using UnityEngine;

namespace FinishTrigger
{
    public class FinishTrigger : MonoBehaviour
    {
        private EcsEntity _ent;
        
        public void CreateEntity(EcsWorld world)
        {
            _ent = world.NewEntity();
            _ent.Get<FinishObj>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player.Player>())
            {
                _ent.Get<FinishEvent>();
            }
        }
    }
}