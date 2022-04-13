using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions: MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject MenuPanel;
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }

    public void OpenOptionPanel()
    {
        MenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void CloseOptionPanel()
    {
        OptionPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
