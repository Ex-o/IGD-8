using System;
using System.Init;
using Leopotam.Ecs;
using UnityEngine;

public class Init : MonoBehaviour
{
    [SerializeField] private Player.Player _player;
    [SerializeField] private CoinCounter.CoinCounter _coinCounter;

    [SerializeField] private PrefabSettings _prefabs;
    
    [Min(3)]
    [SerializeField] private int _tileCount;

    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world)
            .Add(new GenerateLevel())
            .Add(new CreateEntities())
            .Add(new PlayerMovement())
            .Add(new IncrementCoinCounter())
            .Add(new InitCoinCounter())
            .Add(new ReachFinishLine())
            .Inject(_player)
            .Inject(_coinCounter)
            .Inject(_prefabs)
            .Inject(_tileCount);

        _systems.Init();
    }

    private void Update() {
        _systems.Run();
    }

    private void OnDestroy() {
        _systems.Destroy();
        _world.Destroy();
    }
}