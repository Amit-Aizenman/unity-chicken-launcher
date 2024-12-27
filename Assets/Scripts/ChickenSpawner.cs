using UnityEngine;

public class ChickenSpawner : MonoBehaviour
{
    [SerializeField] private float chickensPerSecond;
    private float _timeSinceLastSpawn;
    private float _randomLaunchAngle;
    private float _randomLaunchForce;
    private float _randomToruqe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _timeSinceLastSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= 1 / chickensPerSecond)
        {
            _timeSinceLastSpawn = 0f;
            var chicken = ChickenPool.instance.Get();
            chicken.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            _randomLaunchAngle = Random.Range(45f, 160f);
            _randomLaunchForce = Random.Range(400f, 500f);
            _randomToruqe = Random.Range(10f, 30f);
            chicken.Launch(_randomLaunchAngle, _randomLaunchForce, _randomToruqe);

        }
    }
}
