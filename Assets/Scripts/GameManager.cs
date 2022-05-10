using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInfo;
    public TextMeshProUGUI characterName; //str
    public TextMeshProUGUI Level; //int
    public TextMeshProUGUI Volume; //float
    public AudioSource Music; //bool
 


    private void Awake()
    {
        if (SharedInfo == null)
        {
            SharedInfo = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        Music = GameObject.Find("GameAudio").GetComponent<AudioSource>();
    }

    public void ApplyUserOptions()
    {
        characterName.text = DataPersistance.SharedInfo.Name; //nombre del personaje (str)

        Volume.text = $"{(DataPersistance.SharedInfo.volume * 100)} %"; //nos indica el % de volumen de la música en pantalla (float)

        if (DataPersistance.SharedInfo.music == 1) //queremos música activada o no (bool)
        {
            Music.enabled = Music.enabled;
        }
        else
        {
            Music.enabled = !Music.enabled;
        }

        Level.text = $"Level: {DataPersistance.SharedInfo.Level}"; //el nivel seleccionado


    }
}
