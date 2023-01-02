using UnityEngine;

namespace Platformer.Objects.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Transform Transform;

        public void Init()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Transform = transform;
        }
    }
}
