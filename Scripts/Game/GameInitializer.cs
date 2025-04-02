using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    [SerializeField] private Transform _gameObjectsPosition;
    [SerializeField] private GameObject _bananaCarPrefab;
    [SerializeField] private GameObject _gameSettings;
    [SerializeField] private Transform _carSpawnPosition;

    public void StartGame()
    {
        _menu.SetActive(false);

        Instantiate(_gameSettings, _gameObjectsPosition);
        Instantiate(_bananaCarPrefab, _carSpawnPosition.position, Quaternion.identity, _gameObjectsPosition);

        FindAnyObjectByType<CarComponentCellsUI>().Initialize();
        FindAnyObjectByType<CarComponentImageSpawnerUI>().Initialize();
    }
}
