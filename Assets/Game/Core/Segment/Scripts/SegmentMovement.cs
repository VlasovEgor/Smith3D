using UnityEngine;

public class SegmentMovement : MonoBehaviour, IMovable
{
    private float _speed;

    private bool _canMove;
    
    public void SetSpeed(float speed)
    {   
        if (speed < 0)
        {   
            _speed = 0;
            return;
        }
       
        _speed = speed;
        _canMove = true;
    }


    private void Update()
    {
        if (!_canMove)
        {
            return;
        }
        
        Move();
    }

    public void Move()
    {
        var nextPosition = transform.position + Vector3.down * _speed * Time.deltaTime;
        transform.position = nextPosition;
    }
}
