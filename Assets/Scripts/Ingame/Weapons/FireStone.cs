using Ingame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Weapon
{
    public class FireStone : BaseWeapon
    {
        ParticleSystem particleSystem;
        protected override void Start()
        {
            particleSystem = GetComponentInChildren<ParticleSystem>();
            particleSystem.Stop();

            GetComponent<MeshRenderer>().material.color = Color.red;
            Enemy.OnParticleCollisionEvent += OnHit;

            base.Start();
        }
        protected override void OnMouseButtonDown()
        {
            particleSystem.Play();
        }

        protected override void OnMouseButtonUp()
        {
            particleSystem.Stop();
        }
        private void OnHit(Enemy to, GameObject from)
        {
            if(from.transform.parent == transform)
            {
                var target = (to as ScareCrow);

                target.WET -= 1;

                if (!target.ISWET)
                {
                    target.HP -= 1;
                    target.RemainBurnSeconds = 10;
                }
            }
        }
    }
}
