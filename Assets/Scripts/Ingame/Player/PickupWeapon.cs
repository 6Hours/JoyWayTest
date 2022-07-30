using Ingame.Weapon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Player
{
    public class PickupWeapon : MonoBehaviour
    {
        [SerializeField] private Transform leftWeaponParent;
        [SerializeField] private Transform rightWeaponParent;
        [SerializeField] private float pickUpDistance = 2f;

        private BaseWeapon leftWeapon;
        private BaseWeapon rightWeapon;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q))
                TryPickupWeapon(true);
            else if (Input.GetKeyUp(KeyCode.E))
                TryPickupWeapon(false);
        }
        void TryPickupWeapon(bool isLeft)
        {
            int layerMask = 1 << 8;

            layerMask = ~layerMask;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpDistance, layerMask))
            {
                if(hit.collider.TryGetComponent<BaseWeapon>(out var component))
                {
                    var dropWeapon = isLeft? leftWeapon : rightWeapon;
                    dropWeapon.transform.parent = null;
                    dropWeapon.transform.position = component.transform.position;
                    dropWeapon.enabled = false;

                    component.transform.parent = isLeft ?
                        leftWeaponParent : rightWeaponParent;
                    component.transform.position = Vector3.zero;

                    component.enabled = true;
                    component.SetButton(isLeft);
                    

                    if (isLeft)
                        leftWeapon = component;
                    else
                        rightWeapon = component;

                }
            }
        }
    }
}