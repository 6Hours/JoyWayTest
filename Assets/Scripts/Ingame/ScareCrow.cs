using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Environment
{
    public class ScareCrow : MonoBehaviour
    {
        private MeshRenderer m_Renderer;

        private const int defaultHp = 1000;
        private const int maxWet = 100;

        //temp fields
        private int hp;
        private int wet = 0;
        private int remainBurnSeconds = 0;

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        public int WET
        {
            get { return wet; }
            set 
            { 
                wet = Mathf.Clamp(wet + value, 0, maxWet); 

                if(remainBurnSeconds > 0 && wet > 0)
                {
                    remainBurnSeconds = 0;
                    CancelInvoke();
                }
            }
        }
        public bool ISWET
        {
            get { return wet > 0;}
        }

        public void SetBurn()
        {
            remainBurnSeconds = 10;
            CancelInvoke();
            InvokeRepeating("BurnTick", 1f, remainBurnSeconds);
        }
        public bool ISBURN
        {
            get { return remainBurnSeconds > 0; }
        }

        void Start()
        {
            m_Renderer = GetComponent<MeshRenderer>();

            Initialize();
        }

        public void Initialize()
        {
            hp = defaultHp;
            wet = 0;
            m_Renderer.material.color = Color.yellow;
        }

        private void BurnTick() //FIXME: change my name pls
        {
            HP -= 10;
            remainBurnSeconds--;
        }
    }
}