using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Menu_Manager : MonoBehaviour
{

    public GameObject[] color; //Donde seleccionaremos el nivel que hemos elegido
    public GameObject volumeSlider; //donde sacaremos el value (float)
    public GameObject VolumeToogle; //donde sacaremos el isOn (bool que se convierte en int)
    //public TextMeshProUGUI Character;
    public string CharacterSelected;
    public TextMeshProUGUI DropdownLabelText; //donde sacaremos que slot de personaje hemos seleccioando (int que usaré para tener un string)
    public GameObject CharacterImage;
    public Sprite[] Characters;
    public TMP_Dropdown Dropdowntest;

    
    private int LevelSelected; //para el color y el numero de nivel (int)
    private float volumeLevel;//registrar a que value está el slider (float)
    private int intBoolMusic; //int que estará asociado el valor del toogle
    private bool musicToogle; //para saber si queremos la música activa o no (bool)
    private string CharacterName; //Para guardar el nombre del personaje Elegido (str)
    private int DropdownIndx;
    

    void Start()
    {
        LoadUserOptions();
        SaveUserOptions();
    }

    void Update()
    {
        LevelSelection();
    }

    public void SaveUserOptions() //cuando se ejecuta guarda en el data persitance las variables en su respectiva caja
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
            LevelSelected = PlayerPrefs.GetInt("LEVEL"); //Lo actualiza el changeLevelSelection

            volumeLevel = PlayerPrefs.GetFloat("VOLUME"); //obtenemos el volumen de la partida anterior
            LoadVolume(); //y lo metemos en el slider

            DropdownIndx = PlayerPrefs.GetInt("CHARACTER_SLOT");

            CharacterName = PlayerPrefs.GetString("NAME");

            LoadCharacter();

            intBoolMusic = PlayerPrefs.GetInt("MUSIC"); //obtenemos si estaba apagada o encendida la música antes
            LoadToogle(); //cambiamos el toogle según si estaba apagada o encendida

        }
    }


    #region Music Toogle

    public void LoadToogle()
    {
        if (intBoolMusic == 0)
        {
            VolumeToogle.GetComponent<Toggle>().isOn = true;
        }
        else
        {
            VolumeToogle.GetComponent<Toggle>().isOn = false;
        }
    }
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

    public void LoadCharacter()
    {
        CharacterImage.GetComponent<Image>().sprite = Characters[DropdownIndx];
        DropdownLabelText.text = CharacterName;
    }
    #endregion

    #region UpdateVolume

    public void LoadVolume()
    {
        volumeSlider.GetComponent<Slider>().value = volumeLevel;
    }
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
