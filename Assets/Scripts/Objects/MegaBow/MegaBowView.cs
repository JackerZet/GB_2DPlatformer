using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Objects.MegaBow
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class MegaBowView : MonoBehaviour
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
