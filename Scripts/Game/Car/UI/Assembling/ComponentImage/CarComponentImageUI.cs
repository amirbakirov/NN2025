using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class CarComponentImageUI : MonoBehaviour
{
    private DragDropCarComponentsUI _dragDropCarComponentsUI;

    private CarComponent _carComponentImage;
    public CarComponent CarComponentImage => _carComponentImage;

    private void Start()
    {
        Initialize(CarComponent.Wheels);
    }
    public void Initialize(CarComponent carComponentImage)
    {
        _dragDropCarComponentsUI = FindAnyObjectByType<DragDropCarComponentsUI>();

        _carComponentImage = carComponentImage;

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
    }
}
