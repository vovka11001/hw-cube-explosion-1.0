using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private RaycastReader _raycastReader;
    [SerializeField] private ColorChanger _colorChanger;

    private void OnEnable()
    {
        _raycastReader.HittedObject += Handler;
    }

    private void OnDisable()
    {
        _raycastReader.HittedObject -= Handler;
    }

    private void Handler(Cube cube)
    {
        _spawner.Clone(cube);
        _explosion.ExplodeHandler(cube,_spawner.ChildrenObjects);
        _colorChanger.Recolor(_spawner.ChildrenObjects);
    }
}