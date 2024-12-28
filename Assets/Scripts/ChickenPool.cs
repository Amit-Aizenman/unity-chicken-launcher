using System;
using UnityEngine;

public class ChickenPool : MonoPool<Chicken>
{
    public static ChickenPool instance;
    [SerializeField] private CurrentChicken currentChicken;
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

    private void Update()
    {
        currentChicken.UpdateCurrentChicken(getActiveElements());
    }
}
