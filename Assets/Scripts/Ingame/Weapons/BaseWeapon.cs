using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        private int buttonIndex;

        protected virtual void Start()
        {
            enabled = false;
        }
        void Update()
        {
            if (Input.GetMouseButtonDown(buttonIndex))
            {
                OnMouseButtonDown();
            }
            else if (Input.GetMouseButtonUp(buttonIndex))
            {
                OnMouseButtonUp();
            }
        }

        public virtual void SetButton(bool isLeft)
        {
            buttonIndex = isLeft ? 0 : 1;
        }
        protected abstract void OnMouseButtonDown();
        protected abstract void OnMouseButtonUp();
    }
}