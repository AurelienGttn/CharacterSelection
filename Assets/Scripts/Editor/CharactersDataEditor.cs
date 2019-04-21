using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class CharactersDataEditor : EditorWindow
{
    public CharactersManager charactersData;

    private string charactersFilePath = "/StreamingAssets/characters.json";
    private Vector2 scrollPos;

    [MenuItem("Window/Characters Data Editor")]
    static void Init()
    {
        GetWindow(typeof(CharactersDataEditor)).Show();
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();

        scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, GUILayout.MinHeight(200), GUILayout.MaxHeight(1000), GUILayout.ExpandHeight(true));

        if (charactersData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("charactersData");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            }
        }

        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }

        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

    private void LoadGameData()
    {
        string filePath = Application.dataPath + charactersFilePath;

        if (File.Exists(filePath))
        {
            // Load data from file
            string dataAsJson = File.ReadAllText(filePath);
            charactersData = JsonUtility.FromJson<CharactersManager>(dataAsJson);
        }
        else
        {
            // Create new object if no data exists
            charactersData = new CharactersManager();
        }
    }

    private void SaveGameData()
    {
        string dataAsJson = JsonUtility.ToJson(charactersData);
        string filePath = Application.dataPath + charactersFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }
}
