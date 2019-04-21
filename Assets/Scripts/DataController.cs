using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using SimpleJSON;

public class DataController : MonoBehaviour
{

    public CharactersManager charactersData;
    private string charactersFileName = "characters.json";
    // Used to keep track of the current character when moving 
    // from character selection to character details
    public int currentCharacter = 0;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        LoadCharacters();
        SceneManager.LoadScene("CharacterSelection");
    }

    private void LoadCharacters()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, charactersFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            charactersData = JsonUtility.FromJson<CharactersManager>(dataAsJson);
        }
        else
        {
            Debug.LogError("Cannot load characters data!");
        }
    }

    public void SaveCharacters()
    {
        string dataAsJson = JsonUtility.ToJson(charactersData);
        string filePath = Path.Combine(Application.streamingAssetsPath, charactersFileName);
        File.WriteAllText(filePath, dataAsJson);
    }
}
