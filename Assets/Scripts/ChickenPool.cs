using UnityEngine;

public class ChickenPool : MonoPool<Chicken>
{
    public static ChickenPool instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
