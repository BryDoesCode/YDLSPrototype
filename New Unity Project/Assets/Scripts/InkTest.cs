using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;
using TMPro;

public class InkTest : MonoBehaviour
{
    public TextAsset inkAsset;
    public Button button;
    public TextMeshProUGUI storyText;
    public GameObject buttonPanel;

    public TextMeshProUGUI conversationText;
    public Button conversationButton;
    private bool conversationActive;
    public GameObject conversationContainer;
    public GameObject conversationButtonContainer;

    public StatController StatController;
    public SFXController SFXController;
    public LabelController LabelController;
    public InventoryController InventoryController;
    public StoreController StoreController;

    public AudioClip buttonClick;
    private AudioSource audioSource;

    private Story story;

    public TMP_FontAsset userFont;
    public int userFontSize;


    //For Text Effect
    private Queue<string> sentences;

    void Awake()
    {
        sentences = new Queue<string>();
    }
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();

        story = new Story(inkAsset.text);
        
        // ------------------ Observeable Variables
        // Stats
        story.ObserveVariable("energy", (string varName, object newValue) => {
            StatController.UpdateEnergyStat((int)newValue);
        });
        story.ObserveVariable("health", (string varName, object newValue) => {
            StatController.UpdateHealthStat((int)newValue);
        });
        story.ObserveVariable("wellness", (string varName, object newValue) => {
            StatController.UpdateWellnessStat((int)newValue);
        });

        // Date / UI Stuff
        story.ObserveVariable("fullDate", (string varName, object newValue) => {
            LabelController.UpdateDate((string)newValue);
        });
        story.ObserveVariable("today", (string varName, object newValue) => {
            LabelController.UpdateWeekday(newValue);
        });
        story.ObserveVariable("time", (string varName, object newValue) => {
            LabelController.UpdateTimeSlot(newValue);
        });
        story.ObserveVariable("location", (string varName, object newValue) => {
            LabelController.UpdateLocation((string)newValue);
        });
        story.ObserveVariable("background", (string varName, object newValue) => {
            LabelController.UpdateBackground((string)newValue);
        });

        // Inventory
        story.ObserveVariable("money", (string varName, object newValue) => {
            InventoryController.UpdateMoneyQuantity((float)newValue);
        });
        story.ObserveVariable("prepackagedMealCount", (string varName, object newValue) => {
            InventoryController.UpdatePrepackagedFoodQuantity((int)newValue);
        });
        story.ObserveVariable("foodIngredientsCount", (string varName, object newValue) => {
            InventoryController.UpdateIngredientsSet((int)newValue);
        });

        // Store
        story.ObserveVariable("storePrompt", (string varName, object newValue) => {
            StoreController.StoreState((int)newValue);
        });
        story.ObserveVariable("purchaseResponse", (string varName, object newValue) => {
            StoreController.UpdatePurchaseResponse((string)newValue);
        });

        // Conversation
        story.ObserveVariable("conversationActive", (string varName, object newValue) => {
            ConversationToggle((int)newValue);
        });

        //  ------------------ External Functions
        story.BindExternalFunction("EndGame", () => EndGame());


        //  ------------------ Font Options
        userFont = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as TMP_FontAsset;
        storyText.fontSize = userFontSize;
        storyText.font = userFont;


        //  ------------------ Start Loop
        StoryLoop();           
        
    }

    void StoryLoop()
    {
        ClearUI();        

        sentences.Clear();
        sentences.Enqueue(GetNextStoryBlock());
        DisplayNextSentences();
        //storyText.text = GetNextStoryBlock();
        //Debug.Log("storyText");

        if (story.currentTags.Count > 0)
        {

            foreach (string tag in story.currentTags)
            {
                Debug.Log("Current Tags: " + tag);
                EvaluateTag(tag);
            }
        }

        if (story.currentChoices.Count > 0)
        {
            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton;

                if (conversationActive)
                {
                    choiceButton = Instantiate(conversationButton) as Button;

                    choiceButton.transform.SetParent(conversationButtonContainer.transform, false);                    
                }
                else
                {
                    choiceButton = Instantiate(button) as Button;

                    choiceButton.transform.SetParent(buttonPanel.transform, false);                                        
                }

                TextMeshProUGUI choiceText = choiceButton.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.fontSize = userFontSize;
                choiceText.font = userFont;

                choiceText.text = choice.text.Replace("\\n", "\n"); // Allows for newlines during choices.

                choiceButton.onClick.AddListener(delegate { OnClickChoiceButton(choice); });
            }

        }
        
    }

    public void DisplayNextSentences()
    {
        if(sentences.Count==0)
        {
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        if (conversationActive)
        {            
            conversationText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                conversationText.text += letter;
                yield return null;
                if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
                {
                    conversationText.text = sentence;
                    yield break;
                }
            }
        }
        else
        {
            storyText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                storyText.text += letter;
                yield return null;
                if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
                {
                    storyText.text = sentence;
                    yield break;
                }
            }
        }
    }

    void OnClickChoiceButton(Choice choice)
    {
        audioSource.PlayOneShot(buttonClick);
        story.ChooseChoiceIndex(choice.index);
        StoryLoop();
    }

    void ClearUI()
    {
        int childCount = 0;
        if (conversationActive)
        {
            childCount = conversationButtonContainer.transform.childCount;
            for (int i = childCount - 1; i >= 0; --i)
            {
                GameObject.Destroy(conversationButtonContainer.transform.GetChild(i).gameObject);
            }
        }
        else
        {
            childCount = buttonPanel.transform.childCount;
            for (int i = childCount - 1; i >= 0; --i)
            {
                GameObject.Destroy(buttonPanel.transform.GetChild(i).gameObject);
            }
        }
        
    }

    string GetNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.ContinueMaximally();
        }

        return text;
    }

    void EvaluateTag(string tag)
    {
        if (tag.Contains("SFX")) {
            SFXController.SFXPlayer(tag);
        }
    }

    void ConversationToggle(int value)
    {
        if (value == 1)
        {
            conversationActive = true;
            conversationContainer.SetActive(true);
        }
        else
        {
            conversationActive = false;
            conversationContainer.SetActive(false);

        }
    }

    public void CallInkFunction(string functionName)
    {
        story.EvaluateFunction(functionName);
    }

    public bool CallInkPurchaseFunction(int prepackagedQuantity, int ingredientsQuantity)
    {
        if((int)story.EvaluateFunction("PurchaseItems", prepackagedQuantity, ingredientsQuantity) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /*public void CallInkFunction(string functionName, string variable)
    {
        story.EvaluateFunction(functionName, variable);
    }*/

    void EndGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }


}
