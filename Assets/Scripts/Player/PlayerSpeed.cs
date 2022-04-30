using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public struct PlayerSpeed
    {
        [Min(0)]
        public float speed;
    }
}