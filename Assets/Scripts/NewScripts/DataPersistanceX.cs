using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceX : MonoBehaviour
{
    public static DataPersistance SharedInfo;
    //datos que querremos conservar de una escena a otra
    public int Level; //numero de nivel en el que estás
    public float volume; //valor del slider de volume
    public int music; //valor 0 o 1 del bool
    public string Name; //nombre del personaje elegido
    public int CharacterSlotInt;

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
