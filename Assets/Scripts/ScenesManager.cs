using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour
{

    private TextMeshProUGUI SceneChanges;
    private TextMeshProUGUI LastSceneChanges;
    void Start()
    {
        SceneChanges = GameObject.Find("SceneChanges").GetComponent<TextMeshProUGUI>();
        SceneChanges.text = $"Scene Changes:{DataPersistance.SharedInfo.SceneChanges}";

        LastSceneChanges = GameObject.Find("LastSceneChanges").GetComponent<TextMeshProUGUI>();
        LastSceneChanges.text = $"LastScene Changes:{DataPersistance.SharedInfo.PreviousSceneChanges}";
        
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("Options");
        DataPersistance.SharedInfo.SceneChanges++;
        SceneChanges.text = $"Scene Changes: {DataPersistance.SharedInfo.SceneChanges}";
        LastSceneChanges.text = ($"Last Scene Changes: {DataPersistance.SharedInfo.PreviousSceneChanges}");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("Game");
        DataPersistance.SharedInfo.SceneChanges++;
        DataPersistance.SharedInfo.SaveForFutureGames();
        SceneChanges.text = $"Scene Changes: {DataPersistance.SharedInfo.SceneChanges}";
        LastSceneChanges.text = ($"Last Scene Changes: {DataPersistance.SharedInfo.PreviousSceneChanges}");
    }

    public void QuitGame()
    {
        DataPersistance.SharedInfo.PreviousSceneChanges = DataPersistance.SharedInfo.SceneChanges;
        DataPersistance.SharedInfo.SaveForFutureGames();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
