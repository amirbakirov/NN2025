using UnityEngine;
using UnityEngine.EventSystems;

public class CarComponentCellUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 CellPositionCar {  get; private set; }
    public CarComponent CarComponent {  get; private set; }
    public bool IsMouseEntered { get; private set; }

    public void Initialize(CarComponent carComponent, Vector3 cellPosition)
    {
        CarComponent = carComponent;
        CellPositionCar = cellPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsMouseEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsMouseEntered = false;
    }
}
