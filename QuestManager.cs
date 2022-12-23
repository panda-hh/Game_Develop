using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    static public QuestManager instance;
    public int questId;
    public int questActionIndex;
    public GameObject[] questObject;
    Dictionary<int, QuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateDate();
    }
    //6000 ��ũ��
    void GenerateDate()
    {
        questList.Add(10, new QuestData("�б��� ����", new int[] { 1000,2000,3000 }));
        questList.Add(20, new QuestData("å�� �ɱ�", new int[] { 5000}));
        questList.Add(30, new QuestData("��ȭ ������", new int[] { 1000,2000,3000 }));
        questList.Add(40, new QuestData("All Clear", new int[] { 1000, 2000, 3000 }));
        questList.Add(50, new QuestData("ħ�� �����ϱ�", new int[] { 300 }));
        questList.Add(60, new QuestData("����üũ�ϱ�", new int[] { 400 }));
        questList.Add(70, new QuestData("ī�������", new int[] { 500 }));
        questList.Add(80, new QuestData("All Clear", new int[] { 0}));


    }
    public int GetQuestTalkIndex(int id)
    {
        return questId+ questActionIndex;

    
    }
    public string CheckQuest(int id)
    {
        //���� talk  Target

        if (id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //����Ʈ������Ʈ ��Ʈ��
        ControlObject();

        //��ȭ�������� ���� ����Ʈ
        if (questActionIndex == questList[questId].npcId.Length)
            NextQuest();
        //����Ʈ����
        return questList[questId].questName;
    }
    public string CheckQuest()
    {

        return questList[questId].questName;
    }
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
        Debug.Log(questId);//delete
    }
    public void ControlObject()
    {
        switch (questId)
        {
            case 10:
                if (questActionIndex == 3)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if (questActionIndex == 0)
                    questObject[0].SetActive(true);
                else if (questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
            case 70:
                if(questActionIndex == 1)
                    questObject[1].SetActive(true);
                break;
                

        }
    }

    public void SetId(int newquestId)
    {
        questId = newquestId;
    }
}
