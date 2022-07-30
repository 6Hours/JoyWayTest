using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Environment
{
    public class ScareCrow : MonoBehaviour
    {
        private MeshRenderer m_Renderer;

        private int defaultHp = 1000;
        private int hp;

        // Start is called before the first frame update
        void Start()
        {
            m_Renderer = GetComponent<MeshRenderer>();

            Initialize();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnEnable()
        {
            
        }
        void Initialize()
        {
            hp = defaultHp;
            m_Renderer.material.color = Color.yellow;
        }
    }
}