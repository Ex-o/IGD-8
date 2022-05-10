using System.Utils;
using Coin;
using CoinCounter;
using Leopotam.Ecs;
using Player;
using Shared;

namespace System
{
    public class IncrementCoinCounter : IEcsRunSystem
    {
        private EcsFilter<CoinPickedEvent, TransformObj, CoinObj> _coinFilter;
        private EcsFilter<Count, TransformObj> _counterFilter;
        
        public void Run()
        {
            foreach (var idx in _coinFilter)
            {
                UnityEngine.Object.Destroy(_coinFilter.Get2(idx).Transform.gameObject);
                _coinFilter.GetEntity(idx).Destroy();

                _counterFilter.Get1(0).Value++;
                CoinCallbacks.Update(
                        _counterFilter.Get2(idx).Transform.GetComponent<UnityEngine.UI.Text>(),
                        _counterFilter.Get1(0)
                    );
            }
        }
    }
}