using UnityEngine;
using UnityEngine.UI;

public class StartGameBtn : MonoBehaviour
{
    [SerializeField] private Button _startGameBtn;

    private void Start()
    {
        _startGameBtn.gameObject.SetActive(false);

        _startGameBtn.onClick.AddListener(() =>
        {
            _startGameBtn.gameObject.SetActive(false);

            Transform car = GameObject.FindGameObjectWithTag("Car").transform;
            car.GetComponent<CarController>().Initialize();

            Camera.main.GetComponent<CameraMoving>().Initialize();
        });
    }

    public void ShowStartGameButton()
    {
        _startGameBtn.gameObject.SetActive(true);
    }
}
