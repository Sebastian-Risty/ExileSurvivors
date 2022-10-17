//***********************************************************************
//COPYRIGHT: Team ??????
//***********************************************************************

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private Button currentButton;
    public buttonFunction function;

    public enum buttonFunction{
        startBattle,
        returnToMain,
        resumeBattle
    }

    private void Awake()
    {
        currentButton = gameObject.GetComponent<Button>();
        currentButton.onClick.AddListener(() => ButtonClicked(function));

        // set buttons nav mode to none to prevent weird selection highlights without needing to change every button
        Navigation navigation = new Navigation();
        navigation.mode = Navigation.Mode.None;
        currentButton.navigation = navigation;
    }

    void ButtonClicked(buttonFunction function)
    {
        switch (function)
        {
            case buttonFunction.startBattle:
                SceneManager.LoadScene("Battle");
                EventSystem.current.SetSelectedGameObject(null);
                break;
            case buttonFunction.returnToMain:
                SceneManager.LoadScene("Main Menu");
                break;
            case buttonFunction.resumeBattle:
                BattleScene.pause = false;
                break;
        }
    }
}
