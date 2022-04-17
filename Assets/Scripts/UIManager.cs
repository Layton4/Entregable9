using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Sprite[] Characters;
    public Image CharacterSelection;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CharacterSelectionDrop(int selection)
    {
        for (int i = 0; i < Characters.Length; i++)
        {
            if (i == selection)
            {
                CharacterSelection.GetComponent<Image>().sprite = Characters[i];
            }
        }
    }
    
}
