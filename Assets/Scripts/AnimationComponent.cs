using UnityEngine;

namespace DefaultNamespace
{
    public struct AnimationComponent
    {
        public AnimationComponent(Transform transform, float animateSpeed, float scaleFactor)
        {
            Transform = transform;
            AnimateSpeed = animateSpeed;
            ScaleFactor = scaleFactor;
            NormalScale = 1;
        }

        private Transform Transform { get; }
        public float AnimateSpeed { get; }
        public float ScaleFactor { get; }
        public float NormalScale { get; }

        public void Animate(IMoveAction moveComponent, float deltaTime)
        {
            float direction;
            if (moveComponent.IsMoving)
                direction = 1;
            else
                direction = -1;
                
            SetScale(direction * deltaTime * AnimateSpeed);
        }

        private void SetScale(float value)
        {
            Vector2 currentScale = new Vector2(Transform.localScale.x + value, Transform.localScale.y + value);
            
            currentScale.x = Mathf.Clamp(currentScale.x, NormalScale, ScaleFactor);
            currentScale.y = Mathf.Clamp(currentScale.y, NormalScale, ScaleFactor);
            
            Transform.localScale = currentScale;
        }



    }
}