using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PooledProjectile : MonoBehaviour
{
  [SerializeField] private float _lifeTime;
  [SerializeField] private float _maxLifeTime = 3f;

  // Why on Enable and not Start
  // OnEnable is called when the object is activated. 
  private void OnEnable()
  {
    _lifeTime = 0;
  }

  private void Update()
  {
    _lifeTime += Time.deltaTime;
    if (_lifeTime > _maxLifeTime)
    {
      ProjectilePoolManager.Instance.ReturnToPool(this);
    }
  }

    private void OnTriggerEnter(Collider other)
    {
        //if collide with enemy, enemy die
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        ProjectilePoolManager.Instance.ReturnToPool(this);

        

    }
}