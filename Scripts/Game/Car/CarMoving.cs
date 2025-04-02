using UnityEngine;

public class CarMoving : MonoBehaviour
{
    private bool _isCanMove = true;

    [SerializeField] private WheelJoint2D[] _wheelJoint2Ds;

    public void Initialize()
    {
        _isCanMove = true;
    }

    private void Update()
    {
        if (_isCanMove)
        {

        }
    }
}
