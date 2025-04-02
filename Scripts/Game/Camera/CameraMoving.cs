using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Transform _carTransform;
    private Vector3 _carOffset;
    private Vector3 _offset;

    public void Initialize()
    {
        _carTransform = GameObject.FindGameObjectWithTag("Car").transform;
        _carOffset = _carTransform.position;
        _offset = transform.position;
    }

    private void Update()
    {
        if (_carTransform != null)
        {
            transform.position = _offset + _carTransform.position - _carOffset;
        }
    }
}
