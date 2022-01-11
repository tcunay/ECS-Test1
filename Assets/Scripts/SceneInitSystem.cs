using UnityEngine;
using Leopotam.Ecs;

namespace DefaultNamespace
{
    public class SceneInit: IEcsInitSystem
    {
        private Transform _player;
        private EcsWorld _world = default;

        public SceneInit(Transform player)
        {
            _player = player;
        }

        public void Init()
        {
            var player = _world.NewEntity();

            var move = new MoveComponent(_player, 10);
            var input = new InputComponent();
            var animation = new AnimationComponent(_player, 1.5f, 1.5f);
            
            player.Replace(input).Replace(move).Replace(animation);
        }
    }
}