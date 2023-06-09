using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class StoryTeller : Singleton<StoryTeller>
{
    public Text[] storyTextArray;

    public static string tempMessage;

    private Coroutine tempMessageCoroutine;

    private bool isSpeaking;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        storyTextArray = new Text[GameManager.playerList.Count];
        for (int i = 0; i < GameManager.playerList.Count; i++)
        {
            GameManager.playerList[i].GetComponent<PlayerData>().playerLowHealthEvent += LowHealthSubscriber;
            storyTextArray[i] = GameManager.playerList[i].GetComponent<PlayerData>().storyText;
        }
    }

    private void LowHealthSubscriber(ClassType playerClass)
    {
        if (isSpeaking)
        {
            StopCoroutine(tempMessageCoroutine);
            for (int n = 0; n < storyTextArray.Length; n++)
            {
                storyTextArray[n].text = "";
            }
        }
        isSpeaking = true;
        tempMessageCoroutine = StartCoroutine(StoryWriterIEnum(playerClass, 0));
    }
    public static void ShotFoodSubscriber(ClassType playerClass)
    {
        if (Instance.isSpeaking)
        {
            Instance.StopCoroutine(Instance.tempMessageCoroutine);
            for (int n = 0; n < Instance.storyTextArray.Length; n++)
            {
                Instance.storyTextArray[n].text = "";
            }
        }
        Instance.isSpeaking = true;
        Instance.tempMessageCoroutine = Instance.StartCoroutine(Instance.StoryWriterIEnum(playerClass, 2));
    }

    IEnumerator StoryWriterIEnum(ClassType playerClass, int Countext)
    {
        switch (Countext)
        {
            case 0:
                tempMessage = "The " + playerClass.ToString() + " is low on Health";
                break;
            case 1:
                tempMessage = "Shots do not hurt other players � yet";
                break;
            case 2:
                tempMessage = playerClass.ToString() + " � shot the food!";
                break;
            default:
                break;
        }
        for (int i = 0; i < storyTextArray.Length; i++)
        {
            for (int n = 0; n < tempMessage.Length; n++)
            {
                storyTextArray[i].text += tempMessage[n].ToString();
                yield return new WaitForSeconds(.2f);
            }
        }
        yield return new WaitForSeconds(5f);
        for (int n = 0; n < storyTextArray.Length; n++)
        {
            storyTextArray[n].text = "";
        }
        isSpeaking = false;
    }
}
