using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitPassword : MonoBehaviour
{
    [SerializeField]
    private int nbAttempts = 5;

    [SerializeField]
    private GameObject prefab;

    private GameObject attempts;
    private int noAttempt = 1;

    private const int INPUT_HEIGHT = 100;
    private const int INPUT_HEIGHT_SPACE = 150;
    // Start is called before the first frame update
    void Start()
    {
        attempts = transform.GetChild(0).GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubmitAttempt()
    {
        GameObject nextInputs = Instantiate(prefab);

        InputField[] inputs = attempts.transform.GetChild(attempts.transform.childCount - 1).GetComponentsInChildren<InputField>();
        string attempt = "";
        InputField actual;
        bool allFilled = true;
        foreach (InputField item in inputs)
        {
            if (item.text.Equals(""))
            {
                allFilled = false;
                break;
            }
        }

        if (allFilled)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                actual = inputs[i];
                actual.interactable = false;
                actual.GetComponentsInChildren<Text>()[1].color = (MainScript.GetWord()[i].ToString().ToLower().Equals(actual.text.ToLower()) ? Color.green : Color.red);
                actual.text = actual.text.ToUpper();
                actual.interactable = false;
                attempt += actual.text;
                nextInputs.transform.GetChild(i).GetComponent<InputField>().text = (MainScript.GetWord()[i].ToString().ToLower().Equals(actual.text.ToLower()) ? actual.text.ToUpper() : "");
            }

            if (MainScript.GetWord().ToLower().Equals(attempt.ToLower()))
            {
                Menu.SafeMenu.ShowMenu(false);
                Menu.ShowMouse(true);
                SceneManager.LoadScene("Credit");
            }
            else if (noAttempt == nbAttempts)
            {
                
                Menu.SafeMenu.ShowMenu(false);
            }
            else
            {
                nextInputs.transform.SetParent(attempts.transform);
                RectTransform rt = nextInputs.GetComponent<RectTransform>();
                rt.offsetMax = new Vector2(0, -noAttempt * INPUT_HEIGHT_SPACE);
                rt.offsetMin = new Vector2(0, -(noAttempt) * INPUT_HEIGHT_SPACE - INPUT_HEIGHT);
                noAttempt++;
                transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Remaining attempts : " + (nbAttempts - noAttempt + 1);
            }
        }
    }

    public void CloseMenu() {
        Menu.SafeMenu.ShowMenu(false);
    }
}
