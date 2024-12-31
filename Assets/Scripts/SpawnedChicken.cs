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
    
    private void OnEnable()
    {
        GameEvents.DestroyAllChickens += ResetChickenCounter;
    }

    private void OnDisable()
    {
        GameEvents.DestroyAllChickens -= ResetChickenCounter;
    }

    private void ResetChickenCounter(int reset)
    {
        counter = reset;
        myTextElement.text = "0";
    }
}
