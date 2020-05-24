using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Person
{
    // Character Appearance

    // Face
    public Sprite FaceShape { get; protected set; }
    public Color SkinColor { get; protected set; }
    public Sprite EyeShape { get; protected set; }
    public Color EyeColor { get; protected set; }
    public Sprite NoseShape { get; protected set; }
    public Sprite MouthShape { get; protected set; }
    public Sprite EarShape { get; protected set; }

    // Hair
    public Sprite BangShape { get; protected set; }
    public Sprite HairShape { get; protected set; }
    public Color HairColor { get; protected set; }

    // Facial Hair
    public Sprite Mustache { get; protected set; }
    public Sprite Beard { get; protected set; }

    // Details
    public Sprite Piercing { get; protected set; }
    public Sprite Freckles { get; protected set; }
    public Sprite Mole { get; protected set; }

    // Basic Info
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public bool KnowsPlayerCharacter { get; set; }

    // Basic Info

    /*public Person (int skinColor, int eyeColor, int hairColor, int faceShape, int eyeShape, int noseShape, int mouthShape, int earShape, int bangShape,
        int hairShape, int mustache, int beard, int piercing, int freckles, int mole)
    {
        SkinColor = skinColors[skinColor];
        EyeColor = eyeColors[eyeColor];
        HairColor = hairColors[hairColor];

        FaceShape = faceShapes[faceShape];
        EyeShape = eyeShapes[eyeShape];
        NoseShape = noseShapes[noseShape];
        MouthShape = mouthShapes[mouthShape];
        EarShape = earShapes[earShape];

        BangShape = bangShapes[bangShape];
        HairShape = hairShapes[hairShape];

        Mustache = mustaches[mustache];
        Beard = beards[beard];

        Piercing = piercings[piercing];
        Freckles = frecklesTypes[freckles];
        Mole = moles[mole];
    }*/
    public Person(string firstName, string lastName, int skinColor, int eyeColor, int hairColor, int faceShape, int eyeShape, int mouthShape,
        int hairShape, GameObject avatar)
    {
        FirstName = firstName;
        LastName = lastName;

        CharacterCreationController CharacterController = GameObject.FindObjectOfType<CharacterCreationController>();
        SkinColor = CharacterController.skinColors[skinColor];
        EyeColor = CharacterController.eyeColors[eyeColor];
        HairColor = CharacterController.hairColors[hairColor];

        FaceShape = CharacterController.faceShapes[faceShape];
        EyeShape = CharacterController.eyeShapes[eyeShape];
        MouthShape = CharacterController.mouthShapes[mouthShape];

        HairShape = CharacterController.hairShapes[hairShape];

        UpdateAvatar(avatar);
    }


    public void UpdateAvatar(GameObject avatar)
    {        
        Image faceImage = avatar.transform.Find("Face").GetComponent<Image>();
        Image hairImage = avatar.transform.Find("Hair").GetComponent<Image>();
        Image eyeImage = avatar.transform.Find("Eyes").GetComponent<Image>();
        Image mouthImage = avatar.transform.Find("Mouth").GetComponent<Image>();

        faceImage.sprite = FaceShape;
        faceImage.color = SkinColor;
        hairImage.sprite = HairShape;
        hairImage.color = HairColor;
        eyeImage.sprite = EyeShape;
        eyeImage.color = EyeColor;
        mouthImage.sprite = MouthShape;
    }
}
