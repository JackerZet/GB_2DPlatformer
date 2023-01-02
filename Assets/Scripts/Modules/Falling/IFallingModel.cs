using UnityEngine;

namespace Platformer.Modules.Falling
{
    public interface IFallingModel
    {
        Vector2 Velocity { get; }
        void Fall();
        bool IsGrounded();
    }
}
