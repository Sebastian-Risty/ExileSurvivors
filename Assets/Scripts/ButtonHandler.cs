using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private Button currentButton;
    public buttonFunction function;

    public enum buttonFunction{
        start,
        test
    }

    private void Awake()
    {
        currentButton = gameObject.GetComponent<Button>();
        currentButton.onClick.AddListener(() => ButtonClicked(function));
    }

    void ButtonClicked(buttonFunction function)
    {
        switch (function)
        {
            case buttonFunction.start:
                SceneManager.LoadScene("Battle");
                break;
            case buttonFunction.test:
                Debug.Log("Hit!");
                break;
        }
    }
}
