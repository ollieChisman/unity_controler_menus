using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using System;

namespace game_pad_UI
{
    public class menu_control : MonoBehaviour
    {
        public bool start_menu;
        Vector2Int max;
        Vector2Int min;
        public UI_menu[] menus;
        public Color standard_colour;
        public Vector2Int posiion = new Vector2Int(0, 0);

        public static event Action pressed;
        public static event Action hylighted;

        public static event Action A_E;
        public static event Action B_E;
        public static event Action X_E;
        public static event Action Y_E;

        public static event Action start_E;
        public static event Action select_E;

        private data data;

        bool B_B;
        bool A_B;
        bool X_B;
        bool Y_B;

        bool up_B;
        bool down_B;
        bool left_B;
        bool right_B;

        bool start_B;
        bool select_B;

        public void B(CallbackContext context)
        {
            if (B_B == true)
            {
                B_E();
            }
            B_B = context.action.triggered;
        }

        public void A(CallbackContext context)
        {

            A_B = context.action.triggered;
            if (A_B == true)
            {
                Debug.Log("the A button has been pressed ");
                A_E();
                pressed();
            }
        }

        public void X(CallbackContext context)
        {
            if (X_B == true)
            {
                X_E();
            }
            X_B = context.action.triggered;
        }

        public void Y(CallbackContext context)
        {
            if (Y_B == true)
            {
                Y_E();
            }
            Y_B = context.action.triggered;
        }



        public void up(CallbackContext context)
        {
            up_B = context.action.triggered;
        }

        public void down(CallbackContext context)
        {
            down_B = context.action.triggered;
        }

        public void left(CallbackContext context)
        {
            left_B = context.action.triggered;
        }

        public void right(CallbackContext context)
        {
            right_B = context.action.triggered;
        }



        public void start(CallbackContext context)
        {
            if (start_B == false)
            {
                start_E();
            }
            start_B = context.action.triggered;
            if (start_B == false) start_E();
        }

        public void select(CallbackContext context)
        {
            if (select_B == false)
            {
                select_E();
            }
            select_B = context.action.triggered;
            if (select_B == false) select_E();
        }
        // Start is called before the first frame update

        public void close_menus()
        {
            for (int i = 0; i < menus.Length; i++)
            {
                menus[i].onNotMenu();
                menus[i].gameObject.SetActive(false);
            }
        }




        public void change_menu(int menu_ID)
        {
            Debug.Log(menu_ID);
            menus[menu_ID].gameObject.SetActive(true);
            menus[menu_ID].onMenu();
            posiion = new Vector2Int(0, 0);
            max = menus[menu_ID].max;
            min = menus[menu_ID].min;
            for (int i = 0; i < menus.Length; i++)
            {
                if (i != menu_ID)
                {
                    menus[i].onNotMenu();
                    menus[i].gameObject.SetActive(false);
                }
            }
            hylighted?.Invoke();

        }

        void pressed_F()
        {

        }

        void A_F()
        {
        }

        void B_F()
        {
        }

        void X_F()
        {
        }

        void Y_F()
        {
        }

        void Start()
        {
            pressed += pressed_F;

            A_E += A_F;
            B_E += B_F;
            X_E += X_F;
            Y_E += Y_F;

            if (start_menu)
            {
                menus[0].gameObject.SetActive(true);
                menus[0].onMenu();
                change_menu(0);
                for (int i = 0; i < menus.Length; i++)
                {
                    if (i != 0)
                    {
                        menus[i].onNotMenu();
                        menus[i].gameObject.SetActive(false);
                    }
                }
            }
            data = FindObjectOfType<data>();
        }

        // Update is called once per frame
        void Update()
        {
            if (up_B)
            {
                if (posiion.y != max.y)
                {
                    posiion.y += 1;
                    up_B = false;
                    hylighted?.Invoke();
                }
            }
            if (down_B)
            {
                if (posiion.y != min.y)
                {
                    posiion.y -= 1;
                    down_B = false;
                    hylighted?.Invoke();
                }
            }
            if (right_B)
            {
                if (posiion.x != max.x)
                {
                    posiion.x += 1;
                    right_B = false;
                    hylighted?.Invoke();
                }
            }
            if (left_B)
            {
                if (posiion.x != min.x)
                {
                    posiion.x -= 1;
                    left_B = false;
                    hylighted?.Invoke();
                }
            }
            if (A_B)
            {
                A_E();
            }
            if (Y_B)
            {
                Y_E();
            }
            if (B_B)
            {
                B_E();
            }
            if (X_B)
            {
                X_E();
            }
        }
    }
}
