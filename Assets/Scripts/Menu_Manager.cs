using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{

    public GameObject[] color;
    public GameObject volumeSlider;
    public GameObject VolumeToogle;
    public TextMeshProUGUI Character;

    
    private int LevelSelected; //para el color y el numero de nivel (int)
    private float volumeLevel;//registrar a que value está el slider (float)
    private int intBoolMusic; //int que estará asociado el valor del toogle
    private bool musicToogle; //para saber si queremos la música activa o no (bool)
    private string CharacterName; //Para guardar el nombre del personaje Elegido (str)
    

    void Start()
    {
        volumeLevel = volumeSlider.GetComponent<Slider>().value;
        LoadUserOptions();
    }

    void Update()
    {
        LevelSelection();
    }

    public void SaveUserOptions()
    {
        // Persistencia de datos entre escenas
        DataPersistance.SharedInfo.Level = LevelSelected;
        DataPersistance.SharedInfo.volume = volumeLevel;

        DataPersistance.SharedInfo.music = intBoolMusic;

        DataPersistance.SharedInfo.Name = CharacterName;

        // Persistencia de datos entre partidas
        DataPersistance.SharedInfo.SaveForFutureGames();
    }

    public void LoadUserOptions()
    {
        // Tal y como lo hemos configurado, si tiene esta clave, entonces tiene todas
        if (PlayerPrefs.HasKey("LEVEL"))
        {
            LevelSelected = PlayerPrefs.GetInt("LEVEL");

            volumeLevel = PlayerPrefs.GetFloat("VOLUME");
            ChangeLevelSelection();

            CharacterName = PlayerPrefs.GetString("NAME");

            intBoolMusic = PlayerPrefs.GetInt("MUSIC");
        }
    }


    #region Music Toogle
    public void BoolMusic()
    {
        musicToogle = VolumeToogle.GetComponent<Toggle>().isOn;
        if(musicToogle)
        {
            intBoolMusic = 1;
        }
        else
        {
            intBoolMusic = 0;
        }
    }
    #endregion

    #region Character name
    public void CharacterSelection()
    {
        CharacterName = Character.text;
    }
    #endregion

    #region UpdateVolume
    public void VolumeSelection()
    {
        volumeLevel = volumeSlider.GetComponent<Slider>().value;
    }

    #endregion

    #region Level y Color Selection
    public void LevelSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LevelSelected++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LevelSelected--;
        }
        LevelSelected %= 3;
        ChangeLevelSelection();
    }

    private void ChangeLevelSelection()
    {
        for (int i = 0; i < color.Length; i++)
        {
            color[i].transform.GetChild(0).gameObject.SetActive(i == LevelSelected);
        }
    }
    #endregion
}
