using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject Panel;
    bool state;
    
    public void Toggle()
    {
        if (Panel != null)
        {
            state = !state;
            Panel.SetActive(state);
        }
    }
}
