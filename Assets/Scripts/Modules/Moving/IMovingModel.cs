using System.Collections.Generic;

namespace Platformer.Modules.Moving
{
    public interface IMovingModel
    {
        void MoveTowards(float xAxis);
    }
}
