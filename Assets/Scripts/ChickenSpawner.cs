using UnityEngine;
using UnityEngine.UI;

public class ChickenSpawner : MonoBehaviour
{
    public static float InitialChickentPerSecond = 3;
    public static float ChickensPerSecond;
    [SerializeField] private Button fasterButton;
    [SerializeField] private Button slowerButton;
    [SerializeField] private SpawnedChicken chickenSpawnerTracker;
    private float _timeSinceLastSpawn;
    private float _randomLaunchAngle;
    private float _randomLaunchForce;
    private float _randomToruqe;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _timeSinceLastSpawn = 0f;
        ChickensPerSecond = InitialChickentPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        _timeSinceLastSpawn += Time.deltaTime;
        if (_timeSinceLastSpawn >= 1 / ChickensPerSecond)
        {
            _timeSinceLastSpawn = 0f;
            var chicken = ChickenPool.Instance.Get();
            FindAnyObjectByType<SoundManager>().Play("ChickenSpawned", true, true);
            chicken.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            _randomLaunchAngle = Random.Range(45f, 160f);
            _randomLaunchForce = Random.Range(400f, 500f);
            _randomToruqe = Random.Range(10f, 30f);
            chicken.Launch(_randomLaunchAngle, _randomLaunchForce, _randomToruqe);
            chickenSpawnerTracker.IncerementChickenCounter();
            

        }
    }
    
    private void OnEnable()
    {
        fasterButton.onClick.AddListener(FasterButtonClicked);
        slowerButton.onClick.AddListener(SlowerButtonClicked);
    }

    private void OnDisable()
    {
        fasterButton.onClick.RemoveListener(FasterButtonClicked);
        slowerButton.onClick.RemoveListener(SlowerButtonClicked);
    }

    private void FasterButtonClicked()
    {
        if (ChickensPerSecond == 0)
            ChickensPerSecond = 1f;
        else
            ChickensPerSecond *= 1.5f;
    }

    private void SlowerButtonClicked()
    {
        ChickensPerSecond /= 1.5f;
    }
}
