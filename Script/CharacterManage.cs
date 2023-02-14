using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CharacterManage : MonoBehaviour
{
    public WeaponDatabase weaponDatabase;
    public CharacterDatabase characterDatabase;
    public Store SDatabase;
    public SpriteRenderer weaponSprite;
    public SpriteRenderer artworkSprite;
    private Scene MyScene;

    private int selectOption = 0;
    private int selectOption1 = 0;
    // Start is called before the first frame update
    void Start()
    {
        MyScene = SceneManager.GetActiveScene();
        if(MyScene.buildIndex == 1 || MyScene.buildIndex == 2)
        {
            for (int i = 0; i < characterDatabase.CharacterCount; i++)
            {
                if (MyScene.buildIndex == 1)
                {
                    characterDatabase.GetCharacter(i).Isleft = false;
                    weaponDatabase.GetCharacter(i).IsLeft = false;
                }
                if (MyScene.buildIndex == 2)
                {
                    characterDatabase.GetCharacter(i).IsRight = false;
                    weaponDatabase.GetCharacter(i).IsRight = false;
                }
            }

        }
        if(MyScene.buildIndex == 4)
        {
            for(int i =0; i < characterDatabase.CharacterCount; i++)
            {
                if (characterDatabase.GetCharacter(i).Isleft)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = characterDatabase.GetCharacter(i).characterSprite;
                }
            }
        }
        if (MyScene.buildIndex == 5)
        {
            for (int i = 0; i < characterDatabase.CharacterCount; i++)
            {
                if (characterDatabase.GetCharacter(i).IsRight)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = characterDatabase.GetCharacter(i).characterSprite;
                }
            }
        }
        if (!PlayerPrefs.HasKey("selectOption"))
        {
            selectOption = 0;
            selectOption1 = 0;
        }
        else
        {
            Load();
        }
        if(MyScene.buildIndex != 4 && MyScene.buildIndex != 5 && MyScene.buildIndex != 0)
        {
            UpdateCharacter(selectOption, selectOption1);

        }
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
        UpdateCharacter(selectOption, selectOption1);
        Save();
    }
    public void NextOption1()
    {
        selectOption1++;
        if (selectOption1 >= weaponDatabase.WeaponCount)
        {
            selectOption1 = 0;
        }
        UpdateCharacter(selectOption, selectOption1);
        Save();
    }
    public void BackOption()
    {
        selectOption--;
        if (selectOption < 0)
        {
            selectOption = characterDatabase.CharacterCount - 1;
        }
        UpdateCharacter(selectOption, selectOption1);
        Save();
    }
    public void BackOption1()
    {
        selectOption1--;
        if (selectOption1 < 0)
        {
            selectOption1 = weaponDatabase.WeaponCount - 1;
        }
        UpdateCharacter(selectOption, selectOption1);
        Save();
    }
    private void Load()
    {
        selectOption =0;
        selectOption1 = 0;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectOption", selectOption);
    }
    private void UpdateCharacter(int selectedOption, int i)
    {
        artworkSprite.sprite = characterDatabase.GetCharacter(selectOption).characterSprite;
        weaponSprite.sprite = weaponDatabase.GetCharacter(i).Weapon;
    }

    public void ChangeScene(int sceneID)
    {
        if(MyScene.buildIndex == 1)
        {
            characterDatabase.GetCharacter(selectOption).Isleft = true;
            weaponDatabase.GetCharacter(selectOption1).IsLeft = true;
        }
        else if(MyScene.buildIndex == 2)
        {
            characterDatabase.GetCharacter(selectOption).IsRight = true;
            weaponDatabase.GetCharacter(selectOption1).IsRight = true;
        }
        if(MyScene.buildIndex == 4 || MyScene.buildIndex == 5)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(MyScene.buildIndex + 1);
        }

    }
    public void NewGame()
    {
        SDatabase.GetCharacter(0).Repeat = false;
        SDatabase.GetCharacter(1).Repeat = false;
        SceneManager.LoadScene(1);
    }
    public void OldGame()
    {
        SDatabase.GetCharacter(0).Repeat = true;
        SDatabase.GetCharacter(1).Repeat = true;
        SceneManager.LoadScene(3);
    }
    public void SelectScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
