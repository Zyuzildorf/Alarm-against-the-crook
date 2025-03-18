using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private int _currentWaypoint;
    private Vector3 _direction;
    private Quaternion _targetRotation;

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (transform.position == _waypoints.WaypointsArray[_currentWaypoint].position)
        {
            _currentWaypoint = ++_currentWaypoint % _waypoints.WaypointsArray.Length;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _waypoints.WaypointsArray[_currentWaypoint].position,
            _moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        _direction = (_waypoints.WaypointsArray[_currentWaypoint].position - transform.position).normalized;
        _targetRotation = Quaternion.LookRotation(_direction);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation,
            _rotationSpeed * Time.deltaTime);
    }
}