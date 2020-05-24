using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterCreationController : MonoBehaviour
{
    public GameObject playerCharacterAvatar;
    public Image hair;
    public Image face;
    public Image eyes;
    public Image mouth;

    public List<Person> NPCs;

    [Header("Color Palettes")]
    public Color[] skinColors;
    public Color[] eyeColors;
    public Color[] hairColors;

    [Header("Face Sprites")]
    public Sprite[] faceShapes;
    public Sprite[] eyeShapes;
    //private Sprite[] noseShapes;
    public Sprite[] mouthShapes;
    //private Sprite[] earShapes;

    [Header("Hair Sprites")]
    //private Sprite[] bangShapes;
    public Sprite[] hairShapes;

    /*[Header("Facial Hair Sprites")]
    private Sprite[] mustaches;
    private Sprite[] beards;

    [Header("Detail Sprites")]
    private Sprite[] piercings;
    private Sprite[] frecklesTypes;
    private Sprite[] moles;
    */
    [Header("Selection Boxes")]
    public TMP_Dropdown hairSelection;
    public TMP_Dropdown faceSelection;
    public TMP_Dropdown hairColorSelection;
    public TMP_Dropdown skinColorSelection;
    public TMP_Dropdown eyeSelection;
    public TMP_Dropdown mouthSelection;

    [Header("Text Boxes")]
    public TMP_InputField firstName;
    public TMP_InputField lastName;

    [Header("GameObjects")]
    public GameObject avatarContainer;
    public GameObject avatarPrefab;
    public GameObject characterCreationContainer;
    public InkTest InkController; 

    private void Start()
    {
        if (NPCs == null)
        {
            NPCs = new List<Person>();
        }
        Debug.Log("New List?");
        Person resetPlayer = new Person("First", "Last", 0, 7, 0, 0,
                0, 0, 0, playerCharacterAvatar);

        hairSelection.onValueChanged.AddListener(delegate {
            HairChange(hairSelection);
        });
        faceSelection.onValueChanged.AddListener(delegate {
            FaceChange(faceSelection);
        });
        eyeSelection.onValueChanged.AddListener(delegate {
            EyeChange(eyeSelection);
        });
        mouthSelection.onValueChanged.AddListener(delegate {
            MouthChange(mouthSelection);
        });
        skinColorSelection.onValueChanged.AddListener(delegate {
            SkinColorChange(skinColorSelection);
        });
        hairColorSelection.onValueChanged.AddListener(delegate {
            HairColorChange(hairColorSelection);
        });
    }

    public void HairChange(TMP_Dropdown hairSelection)
    {
        hair.sprite = hairShapes[hairSelection.value];
    }
    public void FaceChange(TMP_Dropdown faceSelection)
    {
        face.sprite = faceShapes[faceSelection.value];
    }
    public void SkinColorChange(TMP_Dropdown skinColorSelection)
    {
        face.color = skinColors[skinColorSelection.value];
    }
    public void HairColorChange(TMP_Dropdown hairColorSelection)
    {
        hair.color = hairColors[hairColorSelection.value];
    }
    public void EyeChange(TMP_Dropdown eyeSelection)
    {
        eyes.sprite = eyeShapes[eyeSelection.value];
    }
    public void MouthChange(TMP_Dropdown mouthSelection)
    {
        mouth.sprite = mouthShapes[mouthSelection.value];
    }

    
    public void ContinueToGame()
    {
        if (firstName.text.Length != 0 && lastName.text.Length != 0)
        {
            Person PlayerCharacter = new Person(firstName.text, lastName.text, skinColorSelection.value, 7, hairColorSelection.value, faceSelection.value,
                eyeSelection.value, mouthSelection.value, hairSelection.value, playerCharacterAvatar);
            playerCharacterAvatar.transform.SetParent(avatarContainer.transform, false);
            playerCharacterAvatar.transform.localScale = new Vector3(.35f, .35f, 1f);
            InkController.CallInkPlayerCharacterCreation(firstName.text, lastName.text);
            characterCreationContainer.SetActive(false);            
        }
    }

    public void CreateNPC(string firstName, string lastName, int skinColor, int eyeColor, int hairColor, int faceShape, int eyeShape, int mouthShape,
        int hairShape, GameObject avatar)
    {
        if (NPCs == null)
        {
            NPCs = new List<Person>();
        }
        NPCs.Add(new Person(firstName, lastName, skinColor, eyeColor, hairColor, faceShape, eyeShape, mouthShape, hairShape, avatar));
    }
}
