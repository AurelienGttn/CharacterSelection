using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DetailsMenu : MonoBehaviour
{
    [SerializeField] private Text nameText, ageText, strengthText, speedText;
    [SerializeField] private Text[] comboNameText, comboMoveText;

    [SerializeField] private GameObject confirmationPopup;
    [SerializeField] private Text nameDelete;

    private DataController dataController;
    private List<Character> characters;
    private int index;
    private Character character;

    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        characters = dataController.characters;
        character = characters[dataController.currentCharacter];

        // Fill basic information fields
        nameText.text = character.name;
        ageText.text = character.age.ToString();
        strengthText.text = character.strength.ToString();
        speedText.text = character.speed.ToString();

        // Fill combo fields
        int i = 0;
        int j;
        foreach(Combo c in character.combo)
        {
            comboNameText[i].text = c.name;
            if (c.movements.Count > 0) {
                comboMoveText[i].text = c.movements[0];
                for (j = 0; j < c.movements.Count - 1; j++)
                    comboMoveText[i].text += ", " + c.movements[j];
            }
            i++;
        }
    }
    

    public void Back()
    {
        SceneManager.LoadScene("CharacterSelection");
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
        Back();
    }
}
