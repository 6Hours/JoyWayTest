using Ingame.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ScarecrowHPBar : MonoBehaviour
    {
        [SerializeField] private Image lineImage;

        void Start()
        {
            FindObjectOfType<ScareCrow>().OnHPChange += UpdateValue;
        }

        void UpdateValue(int value, float ratio)
        {
            lineImage.fillAmount = ratio;
            lineImage.color = Color.Lerp(Color.red, Color.green, ratio);
        }
        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(2);
        }
    }
}
