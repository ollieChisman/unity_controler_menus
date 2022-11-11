using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using game_pad_UI;
using UnityEngine.InputSystem;


namespace game_pad_UI {

    public class UI_menu : MonoBehaviour
    {
        //public
        public Vector2Int min;
        public Vector2Int max;

        public input_button[] actions;
        public UnityEvent[] actions_events;

        //private
        UI_element[] elements;

        bool is_active;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (is_active) {
                for (int i = 0; i < actions.Length; i++) {
                    if (actions[i].action.IsPressed())
                    {
                        actions_events[i].Invoke();
                    }
                }
            }
        }

        public void onMenu()
        {
            is_active = true;
            elements = GetComponentsInChildren<UI_element>();
            foreach(UI_element i in elements) { 
                i.onMenu();
            }
        }

        public void onNotMenu()
        {
            is_active = false;
            elements = GetComponentsInChildren<UI_element>();
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].onNotMenu();
            }
        }

    }

}
