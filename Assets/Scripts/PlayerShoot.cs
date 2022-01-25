using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   [SerializeField] private float FireRate = 0.2f;
   [SerializeField] private Transform ShootPoint;
   
   [SerializeField] private GameObject FireballPrefab;

   private float TimeUntilFire;
   private PlayerController _PlayerController;
   

   private void Start()
   {
      _PlayerController = GetComponent<PlayerController>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.F) && TimeUntilFire < Time.time)
      {
         Shoot();
         TimeUntilFire = Time.time + FireRate;
      }
   }

   void Shoot()
   {
      float Angle = _PlayerController.isFacingRight ? 0f : 180f;
      var temp = Instantiate(FireballPrefab, ShootPoint.position, 
            Quaternion.Euler(new Vector3(0f, 0f, Angle)));
      Destroy(temp,2f);
   }
}
