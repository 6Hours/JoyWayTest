using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ingame.Enemies
{
    public class ScareCrow : Enemy
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
                    RemainBurnSeconds = 0;
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

                m_Renderer.material.color = Color.Lerp(Color.yellow, Color.blue, (float)wet / maxWet);
            }
        }
        public bool ISWET
        {
            get { return wet > 0;}
        }

        public int RemainBurnSeconds
        {
            get { return remainBurnSeconds; }
            set
            {
                var oldValue = remainBurnSeconds;
                remainBurnSeconds = ISWET? 0 : value;

                if (remainBurnSeconds > 0)
                {
                    if(oldValue == 0) InvokeRepeating("BurnTick", 0f, 1f);

                    m_Renderer.material.color = Color.red;
                }
                else
                {
                    CancelInvoke();

                    if (!ISWET) m_Renderer.material.color = Color.yellow;
                }
            }
        }
        public bool ISBURN
        {
            get { return remainBurnSeconds > 0; }
        }
        public void Initialize()
        {
            HP = defaultHp;
            WET = 0;
            m_Renderer.material.color = Color.yellow;
        }
        private void Start()
        {
            m_Renderer = GetComponent<MeshRenderer>();

            Initialize();
        }

        private void BurnTick() //FIXME: change my name pls
        {
            HP -= 10;
            RemainBurnSeconds--;
        }
    }
}