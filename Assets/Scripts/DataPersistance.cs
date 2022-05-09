using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance SharedInfo;
    //datos que querremos conservar de una escena a otra
    public int Level;
    public float volume;
    public bool music;
    public string Name;

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

        //PlayerPrefs.SetBool("MUSIC", music); //pregunta a Maria como lo haría

        // Nombre
        PlayerPrefs.SetString("NAME", Name);
    }

}
