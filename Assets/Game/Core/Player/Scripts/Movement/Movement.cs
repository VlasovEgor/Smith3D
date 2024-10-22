using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Collider _playerCollider;
    [SerializeField] private Rigidbody _playerRigidbody;
    [SerializeField] private GameObject _player;

    [SerializeField] private Camera _mainCamera;

    private Plane _plane = new Plane(-Vector3.forward, Vector3.zero);

    private bool _isPlayer;
    private bool _playerIsMoving;

    private Vector3 _touchPosition;
    private Vector3 _movePoint;

    private const float StopDistance = 0.1f; // Порог расстояния, при котором персонаж перестает двигаться
    private const float MoveSpeed = 5f; // Скорость движения

    private void Update()
    {
        CheckingAbilityMove();
        Move();
    }

    private void CheckingAbilityMove()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            _touchPosition = touch.position;

            Ray ray = _mainCamera.ScreenPointToRay(_touchPosition);
            float distance;
            _plane.Raycast(ray, out distance);
            _movePoint = ray.GetPoint(distance);

            if (touch.phase == TouchPhase.Began)
            {
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;

                    _isPlayer = objectHit == _player.transform;
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _isPlayer = false;
            }

            if (touch.phase == TouchPhase.Moved && _isPlayer)
            {
                _playerIsMoving = true;
            }
            else
            {
                _playerIsMoving = false;
            }
        }
        else
        {
            _playerIsMoving = false;
        }
    }

    private void Move()
    {
        if (_playerIsMoving)
        {
            Vector3 direction = (_movePoint - _player.transform.position).normalized;
            float distanceToTarget = Vector3.Distance(_player.transform.position, _movePoint);

            if (distanceToTarget > StopDistance)
            {
                _playerRigidbody.velocity = direction * MoveSpeed;
            }
            else
            {
                _playerRigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            _playerRigidbody.velocity = Vector3.zero;
        }
    }

    public void SetPlayerInInitPosition()
    {
        _player.transform.position = Vector3.zero;
    }
}
