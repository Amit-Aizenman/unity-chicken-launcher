using TMPro;
using UnityEngine;

public class SpawnedChicken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    private int _counter;
    
    public void IncerementChickenCounter()
    {
        _counter++;
        myTextElement.text = _counter.ToString();
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
        _counter = reset;
        myTextElement.text = "0";
    }
}
