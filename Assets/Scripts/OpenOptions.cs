using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOptions: MonoBehaviour
{
    public GameObject OptionPanel;
    public GameObject MenuPanel;

    public void OpenOptionPanel() //al pulsar el botón options queremos que desactive el panel del menu y active el panel de opciones
    {
        MenuPanel.SetActive(false);
        OptionPanel.SetActive(true);
    }

    public void CloseOptionPanel() //si le damos al botón de volver apagaremos el panel de opciones y activaremos nuevamente el panel del menu.
    {
        OptionPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
