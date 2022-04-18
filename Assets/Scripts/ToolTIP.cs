using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTIP : MonoBehaviour
{
    void Start()
    {
        
    }
    public void activateToolTip()
    {
        gameObject.SetActive(true);
    }

    public void desactivateToolTip()
    {
        gameObject.SetActive(false);
    }
}
