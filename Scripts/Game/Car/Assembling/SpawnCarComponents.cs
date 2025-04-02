using UnityEngine;

public class SpawnCarComponents : MonoBehaviour
{
    private Transform _car;

    [SerializeField] private GameObject _wheelsVisual;
    [SerializeField] private GameObject _spikedWheelsVisual;
    [SerializeField] private GameObject _wingsPrefab;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _propellerPrefab;

    public void Spawn(CarComponentCellUI carComponent)
    {
        _car = GameObject.FindGameObjectWithTag("Car").transform;

        if (carComponent.CarComponent == CarComponent.Wheels)
        {
            if (true)
            {
                Instantiate(_wheelsVisual.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
            }
            else
            {
                Instantiate(_spikedWheelsVisual.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
            }
        }
        else if (carComponent.CarComponent == CarComponent.WingsOrRocket)
        {
            if (true)
            {
                Instantiate(_wingsPrefab.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
            }
            else
            {
                Instantiate(_rocketPrefab.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
            }
        }
        else if (carComponent.CarComponent == CarComponent.Propeller)
        {
            Instantiate(_propellerPrefab.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
        }
    }
}
