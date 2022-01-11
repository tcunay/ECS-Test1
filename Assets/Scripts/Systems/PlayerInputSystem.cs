using Leopotam.Ecs;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter;
        
        public void Run()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                foreach (var i in _inputFilter)
                {
                    ref var inputComponent = ref _inputFilter.Get1(i);

                    inputComponent.SetDirection(new Vector2(x, y));
                }
            }
        }
    }
}