using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInputField : MonoBehaviour
{
    public static UserInputField targetBoxes;
    public int targetUserInput;
    public InputField iField;
    

    public void Awake()
    {
        if (targetBoxes == null)
        {
            targetBoxes = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Userinput()
    {
        Debug.Log(iField.text);
        targetUserInput = int.Parse(iField.text);
        
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
