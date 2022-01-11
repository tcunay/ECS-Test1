using UnityEngine;
using Leopotam.Ecs;
using DefaultNamespace;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    private EcsWorld _world;
    private EcsSystems _systems;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        
        var player = Instantiate(_playerPrefab, _spawnPoint.position, Quaternion.identity);
        
        var sceneInit = new SceneInit(player.transform);
        var input = new PlayerInputSystem();
        var move = new PlayerMoveSystem();
        var animation = new PlayerAnimationSystem<MoveComponent>();
        
        _systems.Add(sceneInit).Add(input).Add(move).Add(animation);
        _systems.Init();
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
