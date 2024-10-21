using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] private Collider2D _playerCollider2D;
   [SerializeField] private Rigidbody2D _playerRigidbody2D;
   [SerializeField] private GameObject _player;
   
   private bool _isPlayer;
   private bool _playerIsMoving;
   
   private Vector3 _mousePosition;

   private void Update()
   {
       CheckingAbilityMove();
   }

   private void CheckingAbilityMove()
   {    
       _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
       if (Input.GetMouseButtonDown(0))
       {
           Collider2D targetObject = Physics2D.OverlapPoint(_mousePosition);
            
           if (targetObject)
           {
               _isPlayer = targetObject == _playerCollider2D;
           }
       }
       
       if (Input.GetMouseButtonUp(0))
       {    
           _isPlayer = false;
       }

       if (Input.GetMouseButton(0) && _isPlayer)
       {    
           _playerIsMoving = true;
       }
       else
       {
           _playerIsMoving = false;
       }
   }
   
   private void FixedUpdate()
   {
       if (_playerIsMoving)
       {    
           _playerRigidbody2D.MovePosition(_mousePosition);
       }
   }

   public void SetPlayerInInitPosition()
   {
       _player.transform.position = Vector3.zero;
   }
}
