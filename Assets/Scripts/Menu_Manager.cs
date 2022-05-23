using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class Menu_Manager : MonoBehaviour
{

    public GameObject[] levelBoxes; //Donde seleccionaremos el nivel que hemos elegido
    public Slider volumeSlider; //donde sacaremos el value (float)
    public Toggle VolumeToogle; //donde sacaremos el isOn (bool que se convierte en int)
    //public TextMeshProUGUI Character;
    public TMP_Dropdown DropdownLabelText; //donde sacaremos que slot de personaje hemos seleccioando (int que usaré para tener un string)
    public string CharacterSelected;
    public GameObject CharacterImage;
    public Sprite[] Characters;

    public TextMeshProUGUI SceneChanges;
    public TextMeshProUGUI LastSceneChanges;


    private int LevelSelected; //para el color y el numero de nivel (int)
    private float volumeLevel;//registrar a que value está el slider (float)
    private int intBoolMusic; //int que estará asociado el valor del toogle
    private bool musicToogle; //para saber si queremos la música activa o no (bool)
    private string CharacterName; //Para guardar el nombre del personaje Elegido (str)
    private int LastSceneChangeCounter;
    public int DropdownIndx;
    

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

        DataPersistance.SharedInfo.PreviousSceneChanges = LastSceneChangeCounter;
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

            intBoolMusic = PlayerPrefs.GetInt("MUSIC"); //obtenemos si estaba apagada o encendida la música antes
            LoadToogle(); //cambiamos el toogle según si estaba apagada o encendida

            CharacterName = PlayerPrefs.GetString("NAME");
            
            DropdownIndx = PlayerPrefs.GetInt("CHARACTER_SLOT");
            LoadCharacter();

            LastSceneChangeCounter = PlayerPrefs.GetInt("PREVIOUS_CHANGES");
            LastSceneChanges.text = ($"Last Scene Changes: {LastSceneChangeCounter}");

        }
    }

   

    #region Music Toogle

    public void LoadToogle() //activa o desactiva el toggle segun el valor guardado en playerPrefs de la partida anterior.
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
    public void BoolMusic() //al cambiar el valor del toggle podremos cambiar el valor del int que meteremos en data persistance
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
        DropdownLabelText.value = DropdownIndx;
    }
    #endregion

    #region UpdateVolume

    public void LoadVolume() //metemos el valor de volume level en el slider del menú de opciones, para cargar datos de partidas previas
    {
        volumeSlider.GetComponent<Slider>().value = volumeLevel;
    }
    public void VolumeSelection() //para que cuando cambiemos el valor del slider guardemos el valor para pasarlo al datapersistance
    {
        volumeLevel = volumeSlider.GetComponent<Slider>().value;
    }

    #endregion

    #region Level y Color Selection
    public void LevelSelection() //al usar las flechas cambiamos el valor int que dice que caja queremos seleccionar
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            LevelSelected++;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LevelSelected--;
        }
        LevelSelected = LevelSelected % 3; //para que si sobrepasamos el numero máximo de veces que podemos dar a la derecha vuelva a la primera opción hay 3 niveles, si queremos el 4 vuelve al 1
        ChangeLevelSelection();
    }

    private void ChangeLevelSelection() //comprueba con el int que nivel seleccionamos y activa solamente el marco del nivel marcado y desactiva los demás.
    {
        for (int i = 0; i < levelBoxes.Length; i++)
        {
            levelBoxes[i].transform.GetChild(0).gameObject.SetActive(i == LevelSelected);
        }
    }
    #endregion
}
