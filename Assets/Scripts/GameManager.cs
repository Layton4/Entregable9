using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI characterName; //str
    public TextMeshProUGUI Level; //int
    public TextMeshProUGUI Volume; //float
    private AudioSource Music; //bool
    public Image MuteButton; //boton que aparecerá en pantalla para indicar si queremos o no escuchar la música

    public Sprite[] MuteImages; //array de sprites para cambiar la imagen del boton segun si la música está activada o desactivada
 
    void Start()
    {
        Music = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        MuteButton.sprite = MuteImages[DataPersistance.SharedInfo.music];
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {
        characterName.text = $"Wellcome to The Owl House!! {DataPersistance.SharedInfo.Name}"; //nombre del personaje (str)

        Volume.text = $"{(DataPersistance.SharedInfo.volume * 100)} %"; //nos indica el % de volumen de la música en pantalla (float)

        if (DataPersistance.SharedInfo.music == 0) //queremos música activada o no (bool)
        {
            ContinueMusic();
           
        }
        else
        {
            MuteMusic();
        }
        
        Level.text = $"Level: {DataPersistance.SharedInfo.Level + 1}"; //el nivel seleccionado


    }

    public void ContinueMusic()
    {
        Music.UnPause();
        DataPersistance.SharedInfo.music = 0;
        DataPersistance.SharedInfo.SaveForFutureGames();
    }
    
    public void MuteMusic()
    {
        Music.Pause();
        DataPersistance.SharedInfo.music = 1;
        DataPersistance.SharedInfo.SaveForFutureGames();
    }
    
    public void MusicDesActivator() //al clicar el boton de mute cambiamos el valor si queremos o no escucar la música
    {
        if(DataPersistance.SharedInfo.music == 0)
        {
            MuteMusic();
            MuteButton.sprite = MuteImages[DataPersistance.SharedInfo.music];
        }
        else
        {
            ContinueMusic();
            MuteButton.sprite = MuteImages[DataPersistance.SharedInfo.music];
        }
    }

}
