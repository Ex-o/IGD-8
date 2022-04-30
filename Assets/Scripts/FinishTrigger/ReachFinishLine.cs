using FinishTrigger;
using Leopotam.Ecs;
using Player;
using Shared;
using UnityEngine;

public class ReachFinishLine : IEcsRunSystem
{
    private EcsFilter<TransformObj, Orientation, PlayerSpeed, PlayerObj> _filter;
    private EcsFilter<FinishEvent, FinishObj> _finishFilter;

    public void Run()
    {
        if (_finishFilter.GetEntitiesCount() > 0) 
            _filter.GetEntity(0).Get<Player.PlayerSpeed>().speed = 0;
    }
}
