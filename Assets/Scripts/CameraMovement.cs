using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private float moveSpeed = 3f;
    private string _activeButton = "up";

    private void Awake()
    {
        upButton.gameObject.SetActive(true);
        downButton.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        upButton.onClick.AddListener(UpButtonClicked);
        downButton.onClick.AddListener(DownButtonClicked);
        GameEvents.ResetCameraPosition += ResetPosition;
    }

    private void OnDisable()
    {
        upButton.onClick.RemoveListener(UpButtonClicked);
        downButton.onClick.RemoveListener(DownButtonClicked);
        GameEvents.ResetCameraPosition += ResetPosition;

    }

    private void UpButtonClicked()
    {
        upButton.gameObject.SetActive(false);
        transform.DOMove(new Vector3(0.57f,33.6f, -10), moveSpeed);
        _activeButton = "down";
        Invoke("ActivateButton", moveSpeed);
    }

    private void DownButtonClicked()
    {
        transform.DOMove(new Vector3(0.57f, -6.68f, -10), moveSpeed);
        downButton.gameObject.SetActive(false);
        _activeButton = "up";
        Invoke("ActivateButton", moveSpeed);
    }

    private void ActivateButton()
    {
        if (_activeButton == "up")
            upButton.gameObject.SetActive(true);
        else
            downButton.gameObject.SetActive(true);
    }

    private void ResetPosition(int reset)
    {
        DownButtonClicked();
    }
    
}
