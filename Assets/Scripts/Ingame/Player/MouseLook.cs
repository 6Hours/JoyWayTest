using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Player
{
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity = 100f;
        [SerializeField] private Transform playerBody;

        float xRotation;

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            xRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime);
        }
    }
}
