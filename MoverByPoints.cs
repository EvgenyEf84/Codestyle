using UnityEngine;

public class MoverByPoints : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _way;

    private Transform[] _wayPoints;
    private int _currentWayPoint;

    private void Start()
    {
        _wayPoints = new Transform[_way.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
        {
            _wayPoints[i] = _way.GetChild(i);
        }
    }

    private void Update()
    {
        if (transform.position == _wayPoints[_currentWayPoint].position)
        {
            _currentWayPoint = (++_currentWayPoint) % _wayPoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWayPoint].position, _speed * Time.deltaTime);
    }
}