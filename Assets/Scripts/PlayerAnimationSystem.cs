using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimationSystem<T> : IEcsRunSystem where T : struct, IMoveAction
    {
        private EcsFilter<AnimationComponent, T> _animationSystem;
        
        public void Run()
        {
            foreach (var i in _animationSystem)
            {
                ref var animation = ref _animationSystem.Get1(i);
                ref var move = ref _animationSystem.Get2(i);

                animation.Animate(move, Time.deltaTime);
            }
        }
    }
}