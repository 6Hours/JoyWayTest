using Ingame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Weapon
{
    [RequireComponent(typeof(Rigidbody))]
    public class WaterStone : BaseWeapon
    {
        [SerializeField] private float throwPower = 10f;

        private Transform defaultParent;
        private Rigidbody rigid;

        protected override void Start()
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            rigid = GetComponent<Rigidbody>();
            rigid.constraints = RigidbodyConstraints.FreezeAll;
            base.Start();
        }
        protected override void OnMouseButtonDown()
        {
            
        }

        protected override void OnMouseButtonUp()
        {
            rigid.constraints = RigidbodyConstraints.None;
            rigid.AddForce(transform.forward * throwPower);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent<ScareCrow>(out var component))
            {
                component.WET += 10;
                component.RemainBurnSeconds = 0;
            }

            rigid.constraints = RigidbodyConstraints.FreezeAll;
            transform.parent = defaultParent;
            transform.localRotation = Quaternion.identity;
            transform.localPosition = Vector3.zero;
        }
        public override void SetButton(bool isLeft)
        {
            base.SetButton(isLeft);
            defaultParent = transform.parent;
        }
    }
}
