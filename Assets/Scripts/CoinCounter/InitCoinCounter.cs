using System.Utils;
using Coin;
using CoinCounter;
using Leopotam.Ecs;
using Shared;

namespace System.Init
{
    public class InitCoinCounter : IEcsInitSystem
    {
        private EcsFilter<Count, TransformObj> _counterFilter;
        
        public void Init()
        {
            var coinCount =  _counterFilter.Get1(0);
            CoinCallbacks.Update(_counterFilter.Get2(0).Transform.GetComponent<UnityEngine.UI.Text>(), coinCount);
        }
    }
}