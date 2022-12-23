using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game2Manager : MonoBehaviour
{
    public TalkManager talkManager;
    public QuestManager questManager;
    public GameObject talkPanel;
    public TextMeshProUGUI talkText;
    public GameObject MenuSet;
    public GameObject scanObject;
    public bool isAction;
    public int talkIndex;
    public Image portraitImg;
    public Image buttonlmg;
    public TextMeshProUGUI questTalk;
    static public Game2Manager instance;
    public GameObject player;

    private Player2Action thePlayer;

    void Awake()
    {
        thePlayer = FindObjectOfType<Player2Action>();
    }

    void Start()
    {
        GameLoad();
        questTalk.text = questManager.CheckQuest();

    }

    void Update()
    {
        //서브메뉴
        if (Input.GetButtonDown("Cancel"))
        {
            if (MenuSet.activeSelf)
                MenuSet.SetActive(false);
            else
                MenuSet.SetActive(true);
        }



    }
    public void Action(GameObject scanObj)
    {


        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNPC);

        talkPanel.SetActive(isAction);


    }

    void Talk(int id, bool isNPC)
    {
        //talkdata  설치
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);

        //END TALK
        if (id != 5000 & talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            questTalk.text = questManager.CheckQuest(id);
            return;
        }




        //Continuous Talk
        if (isNPC)
        {
            talkText.text = talkData.Split('/')[0];
            //캐릭터보여주기
            portraitImg.sprite = talkManager.GetPortrait(id, int.Parse(talkData.Split('/')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
            buttonlmg.color = new Color(1, 1, 1, 0);


        }
        else if (id == 5000)
        {
            talkText.text = talkData.Split('/')[0];
            buttonlmg.sprite = talkManager.GetButton(id, int.Parse(talkData.Split('/')[1]));
            portraitImg.color = new Color(1, 1, 1, 0);
            buttonlmg.color = new Color(1, 1, 1, 1);
            isAction = true;


        }
        else
        {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
            buttonlmg.color = new Color(1, 1, 1, 0);


        }
        isAction = true;
        talkIndex++;
    }


    public void GameSave()
    {
        if (thePlayer == null)
        {
            thePlayer = FindObjectOfType<Player2Action>();
        }

        PlayerPrefs.SetFloat("Player2X", thePlayer.transform.position.x);
        PlayerPrefs.SetFloat("Player2Y", thePlayer.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId + 10);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);

        PlayerPrefs.Save();

        MenuSet.SetActive(false);


        //Playerprefs :간단란 데이터 자장 기능을 지원하는 클래스
        //플레이어 위치

        //퀘스트아이디

        //퀘스트 액션 인덱스
    }
    public void GameLoad()
    {
        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");

        if (!PlayerPrefs.HasKey("Player2X"))
        {
            
            questId = questId + 10;
            questManager.questId = questId;
            questManager.questActionIndex = questActionIndex;
            questManager.ControlObject();

        }
        else
        {
            float x = PlayerPrefs.GetFloat("Player2X");
            float y = PlayerPrefs.GetFloat("Player2Y");

            player.transform.position = new Vector3(x, y, 0);
            questManager.questId = questId;
            questManager.questActionIndex = questActionIndex;
            questManager.ControlObject();
        }
            

       

    }
    public void GameExit()
    {
       
        Application.Quit();
    }


}
