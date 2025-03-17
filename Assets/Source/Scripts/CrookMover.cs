using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private Transform _parentalWaypoint;
    [SerializeField] private float _moveSpeed;

    private Transform[] _waypoints;
    private int _currentWaypoint;

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
    }

    private void Move()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position,
            _moveSpeed * Time.deltaTime);
        transform.LookAt(_waypoints[_currentWaypoint].position);
    }
}