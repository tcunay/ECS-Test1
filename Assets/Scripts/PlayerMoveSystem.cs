using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private EcsFilter<MoveComponent, InputComponent> _moveFilter;
        
        public void Run()
        {
            foreach (var i in _moveFilter)
            {
                ref var move = ref _moveFilter.Get1(i);
                ref var input = ref _moveFilter.Get2(i);
                
                move.Move(input.Direction, Time.deltaTime);
            }
        }
    }
}