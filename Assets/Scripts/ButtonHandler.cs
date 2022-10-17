using UnityEngine;
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
    }

    void ButtonClicked(buttonFunction function)
    {
        switch (function)
        {
            case buttonFunction.startBattle:
                SceneManager.LoadScene("Battle");
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
