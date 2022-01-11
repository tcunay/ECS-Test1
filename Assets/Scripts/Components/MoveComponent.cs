using System;
using UnityEngine;

namespace DefaultNamespace
{
    public interface IMoveAction
    {
        event Action Moved;
        event Action Stoped;
        
        bool IsMoving { get; }
    }
    
    public struct MoveComponent : IMoveAction
    {
        public MoveComponent(Transform transform, float speed)
        {
            Transform = transform;
            Speed = speed;
            IsMoving = false;
            Moved = null;
            Stoped = null;
        }
        
        public event Action Moved;
        public event Action Stoped;

        private Transform Transform { get; }
        public float Speed { get; }
        public bool IsMoving { get; private set; }

        public void Move(Vector2 direction, float deltaTime)
        {
            Transform.Translate(direction * Speed * deltaTime);
            SetIsMoving(direction.sqrMagnitude > 0.5);
        }

        private void SetIsMoving(bool isMoving)
        {
            if (IsMoving != isMoving)
            {
                if(isMoving)
                    Moved?.Invoke();
                else
                    Stoped?.Invoke();
            }
            
            IsMoving = isMoving;
        }
    }
}