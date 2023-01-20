using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterManage : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public SpriteRenderer weaponSprite;
    public SpriteRenderer artworkSprite;

    private int selectOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectOption);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextOption()
    {
        selectOption++;
        if(selectOption >= characterDatabase.CharacterCount)
        {
            selectOption = 0;
        }
        UpdateCharacter(selectOption);
        Save();
    }
    public void BackOption()
    {
        selectOption--;
        if (selectOption < 0)
        {
            selectOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectOption);
        Save();
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectOption", selectOption);
    }
    private void UpdateCharacter(int selectedOption)
    {
        SelectCharacter character = characterDatabase.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        weaponSprite.sprite = character.weapon;
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
   
}
