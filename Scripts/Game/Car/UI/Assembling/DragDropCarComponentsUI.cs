using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropCarComponentsUI : MonoBehaviour
{
    [SerializeField] SpawnCarComponents _spawnCarComponents;
    [SerializeField] private CarComponentCellsUI _carComponentCells;

    private CarComponentImageUI _carComponentImage;

    public void OnBeginDrag(CarComponentImageUI carComponentImage)
    {
        _carComponentImage = carComponentImage;
    }

    public void OnDrag()
    {
        if (_carComponentImage == null) return;

        foreach (var carComponent in _carComponentCells.ComponentsList)
        {
            if (_carComponentImage.CarComponentImage != carComponent.GetComponent<CarComponentCellUI>().CarComponent)
            {
                carComponent.SetActive(false);
            }
        }

        _carComponentImage.GetComponent<RectTransform>().anchoredPosition = (Vector2)Input.mousePosition - new Vector2(Screen.width / 2, 0);
    }

    public void OnDragEnd()
    {
        if (_carComponentImage == null) return;

        foreach (var carComponent in _carComponentCells.ComponentsList)
        {
            if (_carComponentImage.CarComponentImage != carComponent.GetComponent<CarComponentCellUI>().CarComponent)
            {
                carComponent.SetActive(true);
            }
        }

        foreach (var carComponent in _carComponentCells.ComponentsList)
        {
            if (_carComponentImage.CarComponentImage == carComponent.GetComponent<CarComponentCellUI>().CarComponent)
            {
                if (carComponent.GetComponent<CarComponentCellUI>().IsMouseEntered)
                {
                    _spawnCarComponents.Spawn(carComponent.GetComponent<CarComponentCellUI>());
                    _carComponentImage.DestroyCellImage();
                    _carComponentCells.DestroyCell(carComponent);
                    Debug.Log($"The {_carComponentImage.CarComponentImage} is assembled!");
                    _carComponentImage = null;
                    break;
                }
                else
                {
                    _carComponentImage.ReturnToStartPosition();

                }
            }
        }
    }
}
