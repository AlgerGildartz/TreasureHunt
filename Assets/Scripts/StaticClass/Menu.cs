using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private static Menu instance;

    [SerializeField]
    private GameObject pauseMenu = null;
    [SerializeField]
    private GameObject tabMenu = null;
    [SerializeField]
    private GameObject quitMenu = null;
    [SerializeField]
    private GameObject safeMenu = null;
    [SerializeField]
    private Text textInfo = null;

    [SerializeField]
    private Text textNPC = null;

    private static bool pause = false;

    public static void SetPause(bool state)
    {
        pause = state;
    }

    public static bool IsOnPause()
    {
        return pause;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetInstance(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private static void SetInstance(Menu myInstance)
    {
        instance = myInstance;
        PauseMenu.SetMenus(myInstance.pauseMenu, myInstance.quitMenu);
        TabMenu.SetTabMenu(myInstance.tabMenu);
        TextInfo.setTextInfo(myInstance.textInfo);
        SafeMenu.setSafeMenu(myInstance.safeMenu);
        TextNPC.setTextNPC(myInstance.textNPC);
    }

    public static void ShowMouse(bool state)
    {
        Debug.Log(state);

        if (state)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }


    public static class PauseMenu
    {
        private static GameObject pauseMenu;
        private static GameObject quitMenu;

        private static bool escapePause = false;

        public static void SetMenus(GameObject myPauseMenu, GameObject myQuitMenu)
        {
            pauseMenu = myPauseMenu;
            quitMenu = myQuitMenu;
        }

        public static void GamePause()
        {
            if (!Menu.IsOnPause() || IsOnEscapePause())
            {
                Menu.SetPause(!Menu.IsOnPause());
                escapePause = Menu.IsOnPause();
                Menu.ShowMouse(Menu.IsOnPause());
                SetActive_PauseMenu(Menu.IsOnPause());
            }
            else
            {
                Menu.TabMenu.ShowTab(false);
                Menu.SafeMenu.ShowMenu(false);
            }
        }

        public static bool IsOnEscapePause()
        {
            return escapePause;
        }

        public static void SetActive_PauseMenu(bool state)
        {
            pauseMenu.SetActive(state);
            if (!state)
                quitMenu.SetActive(false);
        }
    }

    public static class TabMenu
    {
        private static GameObject tabMenu;

        public static void SetTabMenu(GameObject myTabMenu)
        {
            tabMenu = myTabMenu;
        }

        public static void SetActive(bool state)
        {
            tabMenu.SetActive(state);
        }

        public static void ShowTab(bool state)
        {
            tabMenu.SetActive(state);
            ShowMouse(state);
            Menu.SetPause(state);
            if (state)
                tabMenu.GetComponent<LoadTab>().LoadLetters();
            else
                tabMenu.GetComponent<LoadTab>().DeleteLetters();
        }

    }

    public static class TextInfo
    {
        private static Text textInfo;

        public static void setTextInfo(Text myTextInfo)
        {
            textInfo = myTextInfo;
        }

        private static bool textLocked = false;

        public static void setLock(bool state)
        {
            textLocked = state;
        }

        public static bool isLocked()
        {
            return textLocked;
        }

        private static IEnumerator ShowTextFor_Coroutine(string text, float delay)
        {
            ChangeText(text);
            setLock(true);
            ShowText(true);
            yield return new WaitForSeconds(delay);
            ShowText(false);
            setLock(false);
        }

        public static void ShowTextFor(string text, float delay)
        {
            textInfo.StartCoroutine(ShowTextFor_Coroutine(text, delay));
        }

        public static void ChangeText(string txt)
        {
            setLock(false);
            textInfo.text = txt;
        }

        public static void ShowText(bool state)
        {
            textInfo.gameObject.SetActive(state);
        }
    }

    public static class SafeMenu
    {
        private static GameObject safeMenu;

        public static void setSafeMenu(GameObject mySafeMenu)
        {
            safeMenu = mySafeMenu;
        }

        public static void SetActive(bool state)
        {
            safeMenu.SetActive(state);
        }

        public static void ShowMenu(bool state)
        {
            safeMenu.SetActive(state);
            ShowMouse(state);
            Menu.SetPause(state);
        }
    }

    public static class TextNPC
    {
        private static Text textNPC;

        public static void setTextNPC(Text myTextNPC)
        {
            textNPC = myTextNPC;
        }

        private static IEnumerator ShowTextFor_Coroutine(string text, float delay)
        {
            ChangeText(text);
            ShowText(true);
            yield return new WaitForSeconds(delay);
            ShowText(false);
        }

        public static void ShowTextFor(string text, float delay)
        {
            ChangeText("");
            ShowText(true);
            textNPC.StartCoroutine(ShowTextFor_Coroutine(text, delay));
        }

        public static void ChangeText(string txt)
        {
            textNPC.text = txt;
        }

        public static void ShowText(bool state)
        {
            textNPC.gameObject.SetActive(state);
        }
    }
}
