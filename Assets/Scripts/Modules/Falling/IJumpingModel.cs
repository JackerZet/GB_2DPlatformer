namespace Platformer.Modules.Falling
{
    public interface IJumpingModel : IFallingModel
    {
        void Jump(bool doJump);
    }
}
