using TMPro;
using UnityEngine;

public class SpawnedChicken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    private int counter = 0;
    
    public void IncerementChickenCounter()
    {
        counter++;
        myTextElement.text = counter.ToString();
    }
}
