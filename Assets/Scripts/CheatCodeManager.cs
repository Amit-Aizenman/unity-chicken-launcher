using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CheatCodeManager : MonoBehaviour
{
    public static CheatCodeManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            // 1 - Reset spawn rate 
        {
            Debug.Log("Resetting chickens spawn rate");
            ChickenSpawner.ChickensPerSecond = ChickenSpawner.initialChickentPerSecond;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            // 2 - Destroy all chickens and reset the counters
        {
            GameEvents.DestroyAllChickens?.Invoke(0);
            
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            // 3 - Reset the camera to its initial position
        {
            Debug.Log("Resetting the camera to initial position");
        }
    }
}