using System.Collections.Generic;
using UnityEngine;

public class CarComponentCellsUI : MonoBehaviour
{
    private Vector3 _carPosition;
    private BananaCarConfig _bananaCarConfig;
    [SerializeField] private RectTransform _carBodyTransformUI;
    [SerializeField] private GameObject _componentCell;
    private List<GameObject> _componentsList;
    public List<GameObject> ComponentsList => _componentsList;

    private Canvas _canvas;
    private RectTransform _canvasRect;

    [SerializeField] private StartGameBtn _startGameBtn;

    public void Initialize()
    {
        _carPosition = GameObject.FindGameObjectWithTag("Car").transform.position;
        _bananaCarConfig = Resources.Load<BananaCarConfig>("BananaCarConfig");
        _canvas = _carBodyTransformUI.GetComponentInParent<Canvas>();
        _canvas.worldCamera = Camera.main;
        _canvas.planeDistance = 1;
        _canvasRect = _canvas.GetComponent<RectTransform>();

        _componentsList = new List<GameObject>();

        CreateCell(_bananaCarConfig.BackWheelsPosition + _carPosition, CarComponent.Wheels);
        CreateCell(_bananaCarConfig.ForwardWheelsPosition + _carPosition, CarComponent.Wheels);

        //if (true) CreateCell(_bananaCarConfig.WingsAndRocketPosition + _carPosition, CarComponent.WingsOrRocket);
        //if (true) CreateCell(_bananaCarConfig.PropellerPosition + _carPosition, CarComponent.Propeller);
    }

    private void CreateCell(Vector3 worldPosition, CarComponent componentType)
    {
        GameObject cell = Instantiate(_componentCell, _carBodyTransformUI);

        // Convert world position to UI position
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPosition);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            _canvasRect,
            screenPoint,
            _canvas.worldCamera,
            out Vector2 localPoint);

        cell.GetComponent<RectTransform>().anchoredPosition = localPoint;
        cell.GetComponent<CarComponentCellUI>().Initialize(componentType, worldPosition);
        _componentsList.Add(cell);
    }

    public void DestroyCell(GameObject cell)
    {
        _componentsList.Remove(cell);
        Destroy(cell);

        if (_componentsList.Count == 0)
        {
            _startGameBtn.ShowStartGameButton();
        }
    }
}