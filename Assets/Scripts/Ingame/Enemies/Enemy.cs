using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public static System.Action<Enemy, GameObject> OnParticleCollisionEvent;

        private void OnParticleCollision(GameObject other)
        {
            OnParticleCollisionEvent?.Invoke(this, other);
        }
    }
}
