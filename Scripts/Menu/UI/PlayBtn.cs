using UnityEngine;
using UnityEngine.UI;

public class PlayBtn : MonoBehaviour
{
    [SerializeField] private GameInitializer _gameInitializer;
    [SerializeField] private Button _playBtn;

    private void Start()
    {
        _playBtn.onClick.AddListener(() =>
        {
            _gameInitializer.StartGame();
        });
    }
}
