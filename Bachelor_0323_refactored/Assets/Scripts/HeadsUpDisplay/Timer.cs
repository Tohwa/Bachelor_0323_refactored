using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

    public class Timer : MonoBehaviour
    {
        public FloatReference prepTime;
        public FloatReference combatTime;

        private float timer;

        private bool updateToPrep;
        private bool updateToCombat;

        public TMP_Text text;

        private void Start()
        {
            updateToPrep = true;
        }

        private void Update()
        {
            if (updateToPrep)
            {
                updateToPrep = false;

                timer = prepTime.Value;
            }
            else if(updateToCombat)
            {
                updateToCombat = false;

                timer = combatTime.Value;
            }

        timer -= Time.deltaTime;

        text.text = "Remaining Time:" + Mathf.Round(timer);
        }

        public void SetPrepTImer()
        {
            updateToPrep = true;
        }

        public void SetCombatTimer()
        {
            updateToCombat = true;
        }
    }
