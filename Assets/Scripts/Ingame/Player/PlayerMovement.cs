using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 7f;
        [SerializeField] private float gravity = -9.8f;


        private CharacterController characterController;
        private Vector3 velocity = Vector3.zero;

        // Start is called before the first frame update
        void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            if (characterController.isGrounded)
            { 
                velocity = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");
                velocity.y = -2f;
            }
            else
            {
                velocity.y += gravity * Time.deltaTime;
            }
            characterController.Move(velocity * speed * Time.deltaTime);
        }

    }
}
