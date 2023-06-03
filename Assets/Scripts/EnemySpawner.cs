using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _startSpawn;
    [SerializeField] private int _mixX;
    [SerializeField] private int _maxX;
    [SerializeField] private int _mixY;
    [SerializeField] private int _maxY;
    [SerializeField] private float _height;
    private float _currentStartSpawnTimer;
    private float _currentSpawnTimer;
    private float _currentSpawnNumber;

  
    private void Update()
    {
        _currentStartSpawnTimer+=Time.deltaTime;
        if (_currentStartSpawnTimer >= _startSpawn)
        {
            _currentSpawnTimer += Time.deltaTime;
            if (_currentSpawnTimer >= _spawnInterval)
            {
                var enemyInstance = Instantiate(_enemyPrefab);
                var newPosition = GenerateStartPosition();
                enemyInstance.transform.position = newPosition;
                _currentSpawnTimer = 0;
                _currentSpawnNumber += 1;
                
            }
        }
        
    }
    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_mixX, _maxX), _height, Random.Range(_mixY, _maxY));
        return startPos;
    }
}
