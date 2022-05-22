using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance SharedInfo;
    //datos que querremos conservar de una escena a otra
    public int Level; //numero de nivel en el que estás
    public float volume; //valor del slider de volume
    public int music; //valor 0 o 1 del bool
    public string Name; //nombre del personaje elegido
    public int CharacterSlotInt;
    public int SceneChanges;
    public int PreviousSceneChanges;

    //Para que la instancia sea única
    private void Awake()
    {

        // Si la instancia no existe
        if (SharedInfo == null)
        {
            // Configuramos la instancia
            SharedInfo = this;
            // Nos aseguramos de que no sea destruida con el cambio de escena
            DontDestroyOnLoad(SharedInfo);
        }
        else
        {
            // Como ya existe una instancia, destruimos la copia
            Destroy(this);
        }
    }
    public void SaveForFutureGames()
    {
        // Level
        PlayerPrefs.SetInt("LEVEL", Level);

        // volume
        PlayerPrefs.SetFloat("VOLUME", volume);

        //Music

        PlayerPrefs.SetInt("MUSIC", music);

        // Nombre
        PlayerPrefs.SetInt("CHARACTER_SLOT", CharacterSlotInt);

        PlayerPrefs.SetString("NAME", Name);

        PlayerPrefs.SetInt("SCENECHANGES", SceneChanges);

        //PlayerPrefs.SetInt("PREVIOUS_CHANGES", PreviousSceneChanges);
    }

}
