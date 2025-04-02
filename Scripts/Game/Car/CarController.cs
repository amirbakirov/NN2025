using UnityEngine;

public class CarController : MonoBehaviour
{
    public void Initialize()
    {
        GetComponent<CarMoving>().Initialize();
    }
}
