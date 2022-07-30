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

        public System.Action<int, float> OnHPChange;

        public int HP
        {
            get { return hp; }
            set 
            { 
                hp = Mathf.Clamp(value, 0, defaultHp);
                if(hp == 0)
                {
                    StopBurning();
                    gameObject.SetActive(false);
                }
                OnHPChange?.Invoke(hp, (float)hp / defaultHp);
            }
        }
        public int WET
        {
            get { return wet; }
            set 
            { 
                wet = Mathf.Clamp(value, 0, maxWet); 

                if(remainBurnSeconds > 0 && wet > 0)
                {
                    StopBurning();
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
            InvokeRepeating("BurnTick", 0f, 1f);
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
            HP = defaultHp;
            WET = 0;
            m_Renderer.material.color = Color.yellow;
        }

        private void BurnTick() //FIXME: change my name pls
        {
            HP -= 10;
            remainBurnSeconds--;
            if (remainBurnSeconds == 0) StopBurning();
        }
        private void StopBurning()
        {
            remainBurnSeconds = 0;
            CancelInvoke();
        }
    }
}