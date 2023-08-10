using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

// To provide extra functionality of TextMeshProUGUI to get animated text and use events with custom tags, to achieve interactive dialogue.
namespace TMPro
{
    /// <summary>
    /// Declares Enums for emotions that NPCs can have
    /// </summary>
    public enum Emotion { happy, sad, suprised, angry };


    // Declares the events for the dialogue system
    /// <summary>
    /// Event for emotion
    /// </summary>
    [System.Serializable] public class EmotionEvent : UnityEvent<Emotion> { }

    /// <summary>
    /// Event for actions
    /// </summary>
    [System.Serializable] public class ActionEvent : UnityEvent<string> { }

    /// <summary>
    /// Event for revealing text
    /// </summary>
    [System.Serializable] public class TextRevealEvent : UnityEvent<char> { }

    /// <summary>
    /// Event for Dialogue.
    /// </summary>
    [System.Serializable] public class DialogueEvent : UnityEvent { }

}

public class TMP_Animated : TextMeshProUGUI
{
    [SerializeField]private float speed = 10;
    public EmotionEvent onEmotionChange;
    public ActionEvent onAction;
    public TextRevealEvent onTextReveal;
    public DialogueEvent onDialogueEnd;

    /// <summary>
    /// Takes a string parameter and processes it to display the text, animated.
    /// </summary>
    /// <param name="newText"></param>
    public void ReadText(string newText)
    {
        text = string.Empty;

        // Splits the whole text into parts using < and > tags.
        // Even numbers in array are texts and odd numbers are tags.

        string[] subTexts = newText.Split('<', '>');

        //tmp needs to parse built in text, so we only include our non custom tags.
        string displayText = "";
        for(int i = 0; i < subTexts.Length; i++)
        {
            if(i % 2 == 0)
            {
                displayText += subTexts[i];
            }
            else if (!isCustomTag(subTexts[i].Replace(" ", "")))
            {
                displayText += $"<{subTexts[i]}>";
            }
        }

        //Check if tag is our own tag
        bool isCustomTag(string tag)
        {
            return tag.StartsWith("speed=") || tag.StartsWith("pause=") || tag.StartsWith("emotion=") || tag.StartsWith("action");
        }

        //sends the string to textmeshpro to hide it completely, then start reading it.
        text = displayText;
        maxVisibleCharacters = 0;
        StartCoroutine(Read());

        IEnumerator Read()
        {
            int subCounter = 0;
            int visibleCounter = 0;
            while(subCounter < subTexts.Length)
            {
                // if 
                if (subCounter % 2 == 1)
                {
                    yield return EvaluateTag(subTexts[subCounter].Replace(" ", ""));
                }
                else
                {
                    while (visibleCounter < subTexts[subCounter].Length)
                    {
                        onTextReveal.Invoke(subTexts[subCounter][visibleCounter]);
                        visibleCounter++;
                        maxVisibleCharacters++;
                        yield return new WaitForSeconds(1f / speed);
                    }
                    visibleCounter = 0;
                }
                subCounter++;
            }
            yield return null;

            WaitForSeconds EvaluateTag(string tag)
            {
                if (tag.Length > 0)
                {
                    if (tag.StartsWith("speed="))
                    {
                        speed = float.Parse(tag.Split('=')[1]);
                    }
                    else if (tag.StartsWith("pause="))
                    {
                        return new WaitForSeconds(float.Parse(tag.Split('=')[1]));
                    }
                    else if (tag.StartsWith("emotion="))
                    {
                        onEmotionChange.Invoke((Emotion)System.Enum.Parse(typeof(Emotion), tag.Split('=')[1]));
                    }
                    else if (tag.StartsWith("action="))
                    {
                        onAction.Invoke(tag.Split('=')[1]);
                    }
                }
                return null;
            }
            onDialogueEnd.Invoke();
        }
    }

}