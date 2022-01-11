using UnityEngine;

namespace DefaultNamespace
{
    public struct InputComponent
    {
        public Vector2 Direction { get; private set; }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }
    }
}