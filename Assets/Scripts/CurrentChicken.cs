using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CurrentChicken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    public static int CurrenChickenCounter = 0;

    private void Update()
    {
        myTextElement.text = CurrenChickenCounter.ToString();
    }
}
