using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Objects.Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/ Player config", order = 1)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField]public float MovingSpeed { get; private set; }
        [field: SerializeField] public float JumpSpeed { get; private set; }
        [field: SerializeField] public float AnimationSpeed { get; private set; }
    }
}
