using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITitle : MonoBehaviour
{
    [SerializeField] Button sPButton;

    void Start()
    {
        sPButton.onClick.AddListener(StartSP);
    }

    private void StartSP()
    {
        SceneSwitcher.Instance.SwitchToTable();
    }
}
