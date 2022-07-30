using Ingame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Weapon
{
    public class Pistol : BaseWeapon
    {
        [SerializeField] private float shotDistance;
        [SerializeField] private int normalDamage = 20;
        [SerializeField] private int damageOnWet = 10;
        [SerializeField] private int damageOnBurn = 30;

        protected override void OnMouseButtonDown()
        {
            
        }

        protected override void OnMouseButtonUp()
        {
            int layerMask = 1 << 8;

            layerMask = ~layerMask;

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, shotDistance, layerMask))
            {
                if (hit.collider.TryGetComponent<ScareCrow>(out var component))
                {
                    component.HP -= component.ISWET ? damageOnWet : (component.ISBURN ? damageOnBurn : normalDamage);
                }
            }
        }
    }
}
