using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infantry.Devices.Weapons
{
    public class Weapon : Device 
    {
        public event Action OnShoot;

        protected int CurrentAmmo;

        [SerializeField] protected int AmmoPerMag;
        [SerializeField] protected int TotalMags;
        [SerializeField] protected float timeBetweenShots;

        private bool canShoot = true;

        public override void Awake() // if overriding - should call base.Awake()
        {
            base.Awake();

            // starts loaded
            CurrentAmmo = AmmoPerMag;
            TotalMags -= 1;

            input.Infantry.PrimaryMouseClick.performed += (UnityEngine.InputSystem.InputAction.CallbackContext obj) => AttemptShoot();
        }

        public void AttemptShoot()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
            {
                StartCoroutine(ShootCoroutine());
            }
        }

        private IEnumerator ShootCoroutine()
        {
            Debug.Log("hey");
            canShoot = false;
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
    }
}
