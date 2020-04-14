using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterCreationController : MonoBehaviour
{

    public Image hair;
    public Image face;
    public Image eyes;
    public Image mouth;

    public Sprite[] hairTypes;
    public Sprite[] faceTypes;
    public Sprite[] eyeTypes;
    public Sprite[] mouthTypes;

    public Color[] skinColors;
    public Color[] hairColors;

    public TMP_Dropdown hairSelection;
    public TMP_Dropdown faceSelection;
    public TMP_Dropdown hairColorSelection;
    public TMP_Dropdown skinColorSelection;
    public TMP_Dropdown eyeSelection;
    public TMP_Dropdown mouthSelection;


    private void Start()
    {
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
        hair.sprite = hairTypes[hairSelection.value];
    }
    public void FaceChange(TMP_Dropdown faceSelection)
    {
        face.sprite = faceTypes[faceSelection.value];
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
        eyes.sprite = eyeTypes[eyeSelection.value];
    }
    public void MouthChange(TMP_Dropdown mouthSelection)
    {
        mouth.sprite = mouthTypes[mouthSelection.value];
    }

    public void ContinueToGame()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
