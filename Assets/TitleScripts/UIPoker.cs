using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPoker : MonoBehaviour
{
    [SerializeField] Button titleButton;
    [SerializeField] GameObject raiseObject;
    [SerializeField] TMP_Text textBox;
    [SerializeField] Button raiseButton;
    // Start is called before the first frame update
    void Start()
    {
        titleButton.onClick.AddListener(BackToTitle);
        raiseButton.onClick.AddListener(ShowRaise);
    }

    private void ShowRaise()
    {

    }

    private void BackToTitle()
    {
        SceneSwitcher.Instance.SwitchToTitle();
    }
}
