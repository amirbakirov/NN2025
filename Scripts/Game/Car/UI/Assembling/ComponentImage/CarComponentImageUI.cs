using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class CarComponentImageUI : MonoBehaviour
{
    private DragDropCarComponentsUI _dragDropCarComponentsUI;
    private Vector3 _spawnPosition = Vector3.zero;
    private CarComponent _carComponentImage;
    public CarComponent CarComponentImage => _carComponentImage;

    public void Initialize(CarComponent carComponentImage, GameObject componentVisual)
    {
        _dragDropCarComponentsUI = FindAnyObjectByType<DragDropCarComponentsUI>();

        _carComponentImage = carComponentImage;

        Instantiate(componentVisual, transform);

        EventTrigger eventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((eventData) => _dragDropCarComponentsUI.OnBeginDrag(this));
        eventTrigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((eventData) => _dragDropCarComponentsUI.OnDrag());
        eventTrigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener((eventData) => _dragDropCarComponentsUI.OnDragEnd());
        eventTrigger.triggers.Add(entry);

        _spawnPosition = GetComponent<RectTransform>().anchoredPosition;
    }

    public void ReturnToStartPosition()
    {
        GetComponent<RectTransform>().anchoredPosition = _spawnPosition;
    }

    public void DestroyCellImage()
    {
        Destroy(gameObject);
    }
}
