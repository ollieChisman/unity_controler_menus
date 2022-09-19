using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

using TMPro;


namespace game_pad_UI
{
    public class UI_element : MonoBehaviour
    {

        public bool uses_standard_colour;
        public Color colour;
        public UnityEvent pressed;
        public Vector2Int pos = new Vector2Int(0,0);

        private Color baseColour;
        public bool isHylighted;
        public TextMeshProUGUI text;
        public menu_control menu_Control;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                baseColour = text.color;
            }
            menu_Control = FindObjectOfType<menu_control>();
            if (uses_standard_colour == true)
            {
                colour = menu_Control.standard_colour;
            }
        }

        void Update()
        {
        }

        void onHylighted()
        {
            
            if (isHylighted == true) {
                isHylighted = false;
                text.color = baseColour;
                menu_control.pressed -= onPressed;
            }
            if (menu_Control != null && menu_Control.posiion == pos)
            {
                    text.color = colour;
                    isHylighted = true;
                    menu_control.pressed += onPressed;
            }
        }

        void onPressed()
        {
            Debug.Log("pressed");
            pressed.Invoke();
        }

        public void onMenu()
        {
            text = GetComponent<TextMeshProUGUI>();
            if (text != null)
            {
                baseColour = text.color;
            }
            menu_control.hylighted += onHylighted;
        }

        public void onNotMenu()
        {
           menu_control.hylighted -= onHylighted;
        }


    }
}

