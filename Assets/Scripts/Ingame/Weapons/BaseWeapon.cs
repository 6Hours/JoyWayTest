using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Weapon
{
    public abstract class BaseWeapon : MonoBehaviour
    {
        protected enum ButtonTriggerAction
        {
            buttonUp,
            buttonDown
        }

        [SerializeField] protected ButtonTriggerAction action;

        private int buttonIndex;


        // Update is called once per frame
        void Update()
        {
            if (action == ButtonTriggerAction.buttonUp && Input.GetMouseButtonUp(buttonIndex))
            {
                Fire();
            }
            else if (action == ButtonTriggerAction.buttonDown && Input.GetMouseButtonDown(buttonIndex))
            {
                Fire();
            }
        }

        public void SetButton(bool isLeft)
        {
            buttonIndex = isLeft ? 0 : 1;
        }
        protected abstract void Fire();
    }
}