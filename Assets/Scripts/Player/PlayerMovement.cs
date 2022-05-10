using Leopotam.Ecs;
using Player;
using Shared;
using UnityEngine;

namespace System
{
    public class PlayerMovement : IEcsRunSystem
    {
        private EcsFilter<TransformObj, Orientation, PlayerSpeed, PlayerObj> _filter;
    
        public void Run()
        {
            var mouseDown = Input.GetMouseButtonDown(0);
            foreach (var idx in _filter)
            {
                ref var player = ref _filter.Get1(idx);
                ref var orientation = ref _filter.Get2(idx);
            
                if (mouseDown)
                {
                    orientation.Forward = !orientation.Forward;
                }
            
                var direction = orientation.Forward ? Vector3.forward : Vector3.right;
                var speed = _filter.Get3(idx).speed;
                player.Transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}