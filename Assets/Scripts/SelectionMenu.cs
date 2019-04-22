using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionMenu : MonoBehaviour
{
    

    [SerializeField] private Text nameDisplay, nameDelete;
    [SerializeField] private GameObject confirmationPopup;

    private DataController dataController;
    private List<Character> characters;
    private int index;

    void Start()
    {
        confirmationPopup.SetActive(false);

        dataController = FindObjectOfType<DataController>();
        characters = dataController.characters;
        index = dataController.currentCharacter;
        nameDisplay.text = characters[index].name;
    }

    public void NextCharacter()
    {
        if (index == characters.Count - 1)
            index = 0;
        else 
            index++;

        nameDisplay.text = characters[index].name;
    }

    public void PreviousCharacter()
    {
        if(index == 0)
            index = characters.Count - 1;
        else
            index--;

        nameDisplay.text = characters[index].name;
    }

    public void Details()
    {
        dataController.currentCharacter = index;
        SceneManager.LoadScene("CharacterDetails");
    }

    public void ToggleDeletePopup()
    {
        if (!confirmationPopup.activeSelf)
        {
            nameDelete.text = characters[index].name;
            confirmationPopup.SetActive(true);
        }
        else
            confirmationPopup.SetActive(false);
    }

    public void DeleteCharacter()
    {
        characters.Remove(characters[index]);
        dataController.charactersData.characters = characters.ToArray();
        dataController.SaveCharacters();
        ToggleDeletePopup();
        PreviousCharacter();
    }
}
