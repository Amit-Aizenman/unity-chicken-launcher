using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static Action<int> DestroyAllChickens;
    public static Action<int> ResetCameraPosition;
}
