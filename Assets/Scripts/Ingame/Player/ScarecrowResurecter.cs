using Ingame.Environment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Player
{
    public class ScarecrowResurecter : MonoBehaviour
    {
        private ScareCrow scareCrow;
        void Start()
        {
            scareCrow = FindObjectOfType<ScareCrow>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.R) && !scareCrow.gameObject.activeSelf)
            {
                scareCrow.gameObject.SetActive(true);
                scareCrow.Initialize();
            }
        }
    }
}
