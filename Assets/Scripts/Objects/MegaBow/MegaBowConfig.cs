using UnityEngine;

namespace Platformer.Objects.MegaBow
{
    [CreateAssetMenu(fileName = "MegaBowConfig",menuName = "Configs/ Mega bow config", order = 2)]
    public class MegaBowConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public Vector2 DirectionOfSprite { get; private set; }
        [field: SerializeField] public float RotatingSpeed { get; private set; }
    }
}
