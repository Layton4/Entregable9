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
    //public TextMeshProUGUI Character;
    public string CharacterSelected;
    public GameObject DropDownCharacters;

    
    private int LevelSelected; //para el color y el numero de nivel (int)
    private float volumeLevel;//registrar a que value est� el slider (float)
    private int intBoolMusic; //int que estar� asociado el valor del toogle
    private bool musicToogle; //para saber si queremos la m�sica activa o no (bool)
    private string CharacterName; //Para guardar el nombre del personaje Elegido (str)
    private int DropdownIndx;
    

    void Start()
    {
        
        LoadUserOptions();

        
        
        volumeLevel = DataPersistance.SharedInfo.volume;
        volumeSlider.GetComponent<Slider>().value = volumeLevel;

        if (intBoolMusic == 0)
        {
            VolumeToogle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            VolumeToogle.GetComponent<Toggle>().isOn = false;
        }

        
        
    }

    void Update()
    {
        LevelSelection();
        CharacterSelection();
    }

    public void SaveUserOptions()
    {
        // Persistencia de datos entre escenas
        DataPersistance.SharedInfo.Level = LevelSelected;
        DataPersistance.SharedInfo.volume = volumeLevel;

        DataPersistance.SharedInfo.music = intBoolMusic;

        DataPersistance.SharedInfo.Name = CharacterName;

        DataPersistance.SharedInfo.CharacterSlotInt = DropdownIndx;

        // Persistencia de datos entre partidas
        DataPersistance.SharedInfo.SaveForFutureGames();
    }

    public void LoadUserOptions()
    {
        // Tal y como lo hemos configurado, si tiene esta clave, entonces tiene todas
        if (PlayerPrefs.HasKey("LEVEL"))
        {
            //ChangeLevelSelection();
            //CharacterSelection();
            LevelSelected = PlayerPrefs.GetInt("LEVEL");

            volumeLevel = PlayerPrefs.GetFloat("VOLUME");

            DropdownIndx = PlayerPrefs.GetInt("CHARACTER_SLOT");

            CharacterName = PlayerPrefs.GetString("NAME");

            intBoolMusic = PlayerPrefs.GetInt("MUSIC");
        }
    }


    #region Music Toogle
    public void BoolMusic()
    {
        musicToogle = VolumeToogle.GetComponent<Toggle>().isOn;
        if(musicToogle == true)
        {
            intBoolMusic = 0;
        }
        else
        {
            intBoolMusic = 1;
        }
    }
    #endregion

    #region Character name
    public void CharacterSelection()
    {
        CharacterName = CharacterSelected;
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
        LevelSelected = LevelSelected % 3;
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
