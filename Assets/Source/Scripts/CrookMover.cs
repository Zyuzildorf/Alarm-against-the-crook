using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private Transform _parentalWaypoint;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    private Transform[] _waypoints;
    private int _currentWaypoint;
    private Vector3 _direction;
    private Quaternion _targetRotation;

    private void Awake()
    {
        _waypoints = new Transform[_parentalWaypoint.childCount];

        for (int i = 0; i < _parentalWaypoint.childCount; i++)
        {
            _waypoints[i] = _parentalWaypoint.GetChild(i);
        }
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position,
            _moveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        _direction = (_waypoints[_currentWaypoint].position - transform.position).normalized;
        _targetRotation = Quaternion.LookRotation(_direction);
        
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation,
            _rotationSpeed * Time.deltaTime);
    }
}