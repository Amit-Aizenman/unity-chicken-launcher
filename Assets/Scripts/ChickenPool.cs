using UnityEngine;

public class ChickenPool : MonoPool<Chicken>
{
    public static ChickenPool Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
