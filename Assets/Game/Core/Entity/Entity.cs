using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
   [SerializeField] private List<MonoBehaviour> _components;
   
   public T GetComponentImplementing<T>() where T : class
   {
      foreach (var component in _components)
      {
         if (component is T)
         {
            return component as T;
         }
      }
      return null;
   }
 
}
