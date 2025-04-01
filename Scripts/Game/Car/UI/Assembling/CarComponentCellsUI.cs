using System.Collections.Generic;
using UnityEngine;

public class CarComponentCellsUI : MonoBehaviour
{
    private BananaCarConfig _bananaCarConfig;
    [SerializeField] private RectTransform _carBodyTransformUI; // Changed to RectTransform
    [SerializeField] private GameObject _componentCell;
    private List<GameObject> _componentsList;
    public List<GameObject> ComponentsList => _componentsList;

    private Canvas _canvas;
    private RectTransform _canvasRect;

    private void Awake()
    {
        _bananaCarConfig = Resources.Load<BananaCarConfig>("BananaCarConfig");
        _canvas = _carBodyTransformUI.GetComponentInParent<Canvas>();
        _canvasRect = _canvas.GetComponent<RectTransform>();
    }

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _componentsList = new List<GameObject>();

        CreateCell(_bananaCarConfig.BackWheelsPosition, CarComponent.Wheels);
        CreateCell(_bananaCarConfig.ForwardWheelsPosition, CarComponent.Wheels);

        if (true) CreateCell(_bananaCarConfig.WingsAndRocketPosition, CarComponent.WingsOrRocket);
        if (true) CreateCell(_bananaCarConfig.PropellerPosition, CarComponent.Propeller);
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
}