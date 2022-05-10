using Leopotam.Ecs;

namespace System.Init
{
    public class CreateEntities : IEcsInitSystem
    {
        private EcsWorld _world;

        private Player.Player _player;
        private CoinCounter.CoinCounter _counter;
        
        public void Init()
        {
            _player.CreateEntity(_world);
            _counter.CreateEntity(_world);
        }
    }
}