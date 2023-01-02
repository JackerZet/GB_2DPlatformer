using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Objects.Arrow
{
    public class ArrowView : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer;
        public Transform Transform;
        public bool IsVisible
        {
            set => SpriteRenderer.enabled = value;
        }
        public void Init()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Transform = transform;
        }        
    }
}
