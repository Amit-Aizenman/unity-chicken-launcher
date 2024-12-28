using TMPro;
using UnityEngine;

public class CurrentChicken : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI myTextElement;
    
    public void UpdateCurrentChicken(int currentChicken)
    {
        myTextElement.text = currentChicken.ToString();
    }
}
