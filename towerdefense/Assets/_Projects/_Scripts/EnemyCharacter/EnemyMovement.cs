using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Towerdefense
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _target;
        [SerializeField] private int _waypointIndex;
        private WaypointManager _waypointManager;
        private bool _isMove;
        private bool _isCompleteRound;
        private void Start()
        {
            _waypointManager = WaypointManager.Instance;
            _target = _waypointManager?.Waypoints[0];
        }
        private void OnEnable()
        {
            _isMove = true;
        }
        private void Update()
        {
            MoveToWayPoint();
        }
        private void MoveToWayPoint()
        {
            if (!_isMove)
            {
                return;
            }

            Vector3 direction = _target.position - transform.position;
            transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);
            transform.LookAt(_target);

            if (Vector3.Distance(this.transform.position, _target.position) <= 0.1f)
            {
                GetNextWayPoint();
            }
        }

        private void GetNextWayPoint()
        {
            if (_isCompleteRound)
            {
                this.gameObject.SetActive(false);
                _waypointIndex = 0;
                _isCompleteRound = false;
                return;
            }
            _waypointIndex++;
            if (_waypointIndex > _waypointManager?.Waypoints.Length - 1 )
            {
                _waypointIndex = 0;
                _isCompleteRound = true;
            }
            _target = _waypointManager?.Waypoints[_waypointIndex];
        }
        public void InitMovementSpeed(float speed)
        {
            this._speed = speed;
        }
    }
}
