using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
   [SerializeField] private Collider _playerCollider;
   [SerializeField] private Rigidbody _playerRigidbody;
   [SerializeField] private GameObject _player;

   [SerializeField] private CharacterController _playerCharacterController;

   [SerializeField] private Camera _mainCamera;

   private Plane _plane = new(-Vector3.forward,Vector3.zero);
   
   private bool _isPlayer;
   private bool _playerIsMoving;
   
   private Vector3 _movePoint;
   
   private const float StopDistance = 0.2f; 

   private void Update()
   {
       CheckingAbilityMove();
   }

   private void CheckingAbilityMove()
   {    
       Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
       float distance;
       _plane.Raycast(ray, out distance);
       _movePoint = ray.GetPoint(distance);
       

       if (Input.GetMouseButtonDown(0))
       {
           RaycastHit hit;
           if (Physics.Raycast(ray, out hit))
           {
               Transform objectHit = hit.transform;
            
               _isPlayer = objectHit == _player.transform;
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
       Move();
   }

   private void Move()
   {
      
      if (_playerIsMoving)
      {
          Vector3 direction = (_movePoint - _player.transform.position).normalized;
          float distanceToTarget = Vector3.Distance(_player.transform.position, _movePoint);

          if (distanceToTarget > StopDistance)
          {
              _playerRigidbody.velocity = direction * 10;
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
