using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] InputField inputField;
    [SerializeField] Text resultText;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void usernameInput()
    {
        // get input and send it over to LogicScript
        string input = inputField.text.Trim();

        if (input.Length > 6)
        {
            resultText.text = "Too Long!";
            return;
        }

        logic.curPlayer = input + ':';
        logic.nameEntered = true;
        resultText.text = "Entered!";
    }
}
