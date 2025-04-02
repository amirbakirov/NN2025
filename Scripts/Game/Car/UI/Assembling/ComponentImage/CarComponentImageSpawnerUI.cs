using UnityEngine;

public class CarComponentImageSpawnerUI : MonoBehaviour
{
    [SerializeField] private GameObject _carComponentImagePrefab;
    [SerializeField] private Transform _CarComponentImagesParent;

    [SerializeField] private GameObject _wheelsVisual;
    [SerializeField] private GameObject _spikedWheelsVisual;
    [SerializeField] private GameObject _wingsPrefab;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _propellerPrefab;

    public void Initialize()
    {
        // get data from json and spawn needed components

        GameObject componentPrefab = Instantiate(_carComponentImagePrefab, _CarComponentImagesParent);
        componentPrefab.GetComponent<CarComponentImageUI>().Initialize(CarComponent.Wheels, _wheelsVisual);

        componentPrefab = Instantiate(_carComponentImagePrefab, _CarComponentImagesParent);
        componentPrefab.GetComponent<CarComponentImageUI>().Initialize(CarComponent.Wheels, _wheelsVisual);
    }
}
