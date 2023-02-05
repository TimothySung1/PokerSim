using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPoker : MonoBehaviour
{
    [SerializeField] Button titleButton;
    // Start is called before the first frame update
    void Start()
    {
        titleButton.onClick.AddListener(BackToTitle);
    }

    private void BackToTitle()
    {
        SceneSwitcher.Instance.SwitchToTitle();
    }
}
