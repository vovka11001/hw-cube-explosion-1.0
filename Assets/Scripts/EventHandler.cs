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
        float minValue = 0f;
        float maxValue = 1f;
        float randomValue = Random.Range(minValue, maxValue);

        if (randomValue <= cube.SplitChance)
        {
            var newCubes = _spawner.Split(cube);
            
            _explosion.ExplodeChildrens(cube,newCubes);
            _colorChanger.Recolor(newCubes);
        }
        else
        {
            Destroy(cube.gameObject);
            _explosion.ExplodeAll(cube);
        }
        
        Destroy(cube.gameObject);
    }
}