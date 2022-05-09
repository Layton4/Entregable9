using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] Characters;
    public Image CharacterSelection;
    private Menu_Manager Menu_ManagerScript;

    public void Start()
    {
        Menu_ManagerScript = GameObject.Find("Menu_Manager").GetComponent<Menu_Manager>();
    }
    public void CharacterSelectionDrop(int selection) //funcion para que haga lo necesario segun que opcion del desplegable marquemos, selection.
    {
        for (int i = 0; i < Characters.Length; i++) //revisará las posiciones de las opciones del desplegable
        {
            if (i == selection) //nuestra elección es una posición del desplegable, y cuando detectemos en que posición hemos clicado
            {
                CharacterSelection.GetComponent<Image>().sprite = Characters[i]; //accedemos al componente imagen de la imagen que hemos colocado le podemos cambiar el sprite segun  lo que hayamos elegido
            }
        }
    }

}
