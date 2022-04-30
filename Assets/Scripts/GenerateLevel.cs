using Leopotam.Ecs;
using UnityEngine;

namespace System.Init
{
    public class GenerateLevel : IEcsInitSystem
    {
        private EcsWorld _world;
        private PrefabSettings _prefabs;
        private int _tileCount;
        private Vector3 _tilePos;
        private bool _forward;

        public void Init()
        {
            BuildLines();
        }
        
        private void BuildLines()
        {
            var needed = _tileCount - 1;
        
            while (needed > 0)
            {
                var tileCnt = Mathf.Clamp(UnityEngine.Random.Range(3, 6), 0, needed);
                for (var i = 0; i < tileCnt; i++)
                {
                    CreateTile(_prefabs.tilePrefap, false);
                }
            
                _forward = !_forward;
                needed -= tileCnt;
            }
            
            _forward = !_forward; 
            CreateTile(_prefabs.finishPrefab, true);
        }

        private void CreateTile(Transform prefap, bool finish)
        {
            var scale = prefap.localScale;
            _tilePos.z += (_forward ? prefap.localScale.z : 0);
            _tilePos.x += (_forward ? 0 : prefap.localScale.x);

            var tile =  UnityEngine.Object.Instantiate(prefap, _tilePos, Quaternion.Euler(0, (_forward ? -90 : 0), 0));

            if(finish)
            {
                tile.GetComponentInChildren<FinishTrigger.FinishTrigger>().CreateEntity(_world);
            }
            else
            {
                if (UnityEngine.Random.value < 0.5)
                {
                    GenerateCoinToTile();
                }
            }
        }

        private void GenerateCoinToTile()
        {
            var shift = _tilePos;
            shift.y += 2 * _prefabs.tilePrefap.transform.lossyScale.y;
            var coin = UnityEngine.Object.Instantiate(_prefabs.coinPrefab, shift, Quaternion.identity);
            coin.GetComponent<Coin.Coin>().CreateEntity(_world);
        }
    }
}