using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using game_pad_UI;


namespace game_pad_UI {

    public class UI_menu : MonoBehaviour
    {
        UI_element[] elements;
        public Vector2Int min;
        public Vector2Int max;

        public string[] Define_buttons;

        public UnityEvent[] Buttons;

        private int A;
        private int B;
        private int X;
        private int Y;

        private int start;
        private int select;

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < Define_buttons.Length; i++) {
                if (Define_buttons[i] == "A") {
                    menu_control.A_E += A_F;
                    A = i;
                }
                if (Define_buttons[i] == "B")
                {
                    menu_control.B_E += B_F;
                    B = i;
                    Debug.Log(i);
                }
                if (Define_buttons[i] == "X")
                {
                    menu_control.X_E += X_F;
                    X = i;
                }
                if (Define_buttons[i] == "Y")
                {
                    menu_control.Y_E += Y_F;
                    Y = i;
                }
                if (Define_buttons[i] == "start")
                {
                    menu_control.start_E += start_F;
                    start = i;
                }
                if (Define_buttons[i] == "select")
                {
                    menu_control.select_E += select_F;
                    select = i;
                }
            }
        }

        void A_F() {  Buttons[A]?.Invoke(); }
        void B_F() { Debug.Log("B Presed");  Buttons[B]?.Invoke(); }
        void X_F() { Buttons[X]?.Invoke(); }
        void Y_F() { Buttons[Y]?.Invoke(); }

        void start_F() { Buttons[start]?.Invoke(); }
        void select_F() { Buttons[select]?.Invoke(); }



        // Update is called once per frame
        void Update()
        {

        }

        public void onMenu()
        {
            elements = GetComponentsInChildren<UI_element>();
            foreach(UI_element i in elements) { 
                i.onMenu();
            }
        }

        public void onNotMenu()
        {
            elements = GetComponentsInChildren<UI_element>();
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i].onNotMenu();
            }
            for (int i = 0; i < Define_buttons.Length; i++)
            {
                if (Define_buttons[i] == "A")
                {
                    menu_control.A_E -= A_F;
                    A = i;
                }
                if (Define_buttons[i] == "B")
                {
                    menu_control.B_E -= B_F;
                    B = i;
                }
                if (Define_buttons[i] == "X")
                {
                    menu_control.X_E -= X_F;
                    X = i;
                }
                if (Define_buttons[i] == "Y")
                {
                    menu_control.Y_E -= Y_F;
                    Y = i;
                }
                if (Define_buttons[i] == "start")
                {
                    menu_control.start_E -= start_F;
                    start = i;
                }
                if (Define_buttons[i] == "select")
                {
                    menu_control.select_E -= select_F;
                    select = i;
                }
            }
        }

    }

}
