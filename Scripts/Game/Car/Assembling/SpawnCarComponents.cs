using UnityEngine;

public class SpawnCarComponents : MonoBehaviour
{
    [SerializeField] private Transform _car;

    [SerializeField] private GameObject _wheelsPrefab;
    [SerializeField] private GameObject _wingsPrefab;
    [SerializeField] private GameObject _rocketPrefab;
    [SerializeField] private GameObject _propellerPrefab;

    public void Spawn(CarComponentCellUI carComponent)
    {
        if (carComponent.CarComponent == CarComponent.Wheels)
        {
            Instantiate(_wheelsPrefab.gameObject, carComponent.CellPositionCar, Quaternion.identity, _car);
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
