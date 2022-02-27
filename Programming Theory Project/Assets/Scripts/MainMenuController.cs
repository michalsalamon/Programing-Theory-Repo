using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;

    private void Start()
    {
        playerName.characterLimit = 10;     //ENCAPSULATION - limiting 
    }

    public void StartGame()
    {
        DataSave.Instance.PlayerName = playerName.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }    
}
