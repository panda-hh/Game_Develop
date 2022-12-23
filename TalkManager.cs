using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    Dictionary<int, Sprite> buttonData;
    public Sprite[] portraitArr;
    public GameObject player;
    public Sprite[] buttonArr;


    public void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        buttonData = new Dictionary<int, Sprite>();
        GenerateData();
        
    }

    // Update is called once per frame
    public void GenerateData()
    {
        //�ƺ�:1000, ģ��:2000, ������200, �б� 100 ������:3000 å��:5000  ħ�� 300 ��ǻ�� 400
        talkData.Add(1000, new string[] {"�ƺ����� ���� �� ���� ����/2" });
        talkData.Add(2000, new string[] { "����~!/2","....../2", "��? �� ���⼭ �ڰ� ����?/2" });
        talkData.Add(3000, new string[] { "�����԰��� ���� �� ���� ����/2"});


        talkData.Add(100, new string[] { "���� �б��� �����ߴ�" });
        talkData.Add(200, new string[] { "�� ���� �����Ⱑ����?" });


        //����Ʈ ��ũ
        talkData.Add(10 + 1000, new string[] { "�츮�� �����?/0", "�б� �� ������...���ϴ�/1", "(��ħ���� ���̷��� ȭ��������....����� ������)/2" });
        talkData.Add(12 + 3000, new string[] { "������! �׷��׷� ������ �����ߴ�/0", "�� ���� ����/0" });
        talkData.Add(11 + 2000, new string[] { "����~!/0", "�ȳ�~ �ٵ� �� �ۿ� �����־�?/2", "�� ���� �ν�Ÿ �Ⱥþ�??/1", "��? ����....����,, /2", "��ģ��!! �� �ϴ� ���� ����!!/3" });


        talkData.Add(20 + 1000, new string[] { "������� �ֿԴ�?/1" });
        talkData.Add(20 + 2000, new string[] { "�� �����質 ���Ծ�? �ʶ� �� ��������../1" });
        talkData.Add(20 + 3000, new string[] { "�� �ڸ��� ��ã�ڴ�? �� ã�Ƽ� �ɾ�/0" });

        talkData.Add(20 + 5000, new string[] {"������ ���۵˴ϴ�/0" });

        talkData.Add(30 + 1000, new string[] { "�׷�~ ���� �б��� ���?/1","��,,�б��� �׻� �Ȱ���../2","(���� ���� ���� ������ �� �׷��ô°���...)/2","...�׷� �˰ڴ�/1" });
        talkData.Add(30 + 2000, new string[] { "����� �������̾� ��� �����߾�/2","�װ� �� �����ε� ���� �س��͵� ���� �б����� �ִ°� �´°ǰ� �;�/1","�׷��ٰ� �б��� �ȿ��� ��� �ϴ���../2","�ʵ� �Ȱ���!!���ΰ�!!/1" });
        talkData.Add(30 + 3000, new string[] { "�Ҹ��ִ�?/0","���� ���� ������ �ȿ°� ������ �Ǽ���/1","�� ������ �ϴ� ���߿� ������/0","(�̷��� ����� ������ ���� ���Ҽ���)/2" });

        talkData.Add(300, new string[] { "ħ�뿡 ���� �ʹ�" });
        talkData.Add(400, new string[] { "��ǻ�ͷ� ������ �� �� ����" });
        talkData.Add(500, new string[] { "�ֹ濡�� ������ �� �� ����" });
        talkData.Add(50 + 300, new string[] { "����...�����Ͼ�� �� ���� �ʹ� ����� ", "�׷��� �츮�� ��ħ�� �Կ��� ������ ������ �б����� ��������", "�� ���� ��ǻ�ͷ� ���� üũ �� �غ���?" });
        talkData.Add(60 + 400, new string[] { "���� ���ñٹ��� 11�ú��� �ϴ� �ɷ� �γ��ϰ�.. ", "ū �̽������� ���� ���θ��� ���� ���� ������ ���ָ� �Ǵ±��� ", "���� �츮 ������ ���Ϸ� ���߰ڴ�" });
        talkData.Add(70 + 500, new string[] { "���� ��ħ�� ī��~~", "���� ���� ������ ����", "���ߴ�!!���� ����� ������ �츮�� ��� ä������" });
        








        portraitData.Add(1000 + 0,portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(1000 + 2, portraitArr[3]);

        portraitData.Add(2000 + 0, portraitArr[4]);
        portraitData.Add(2000 + 1, portraitArr[5]);
        portraitData.Add(2000 + 2, portraitArr[2]);
        portraitData.Add(2000 + 3, portraitArr[3]);

        portraitData.Add(3000 + 0, portraitArr[7]);
        portraitData.Add(3000 + 1, portraitArr[2]);
        portraitData.Add(3000 + 2, portraitArr[3]);

        buttonData.Add(5000+0, buttonArr[0]);






    }
  

 
    public string GetTalk(int id, int talkIndex)
    {//����ó��
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {

                //����Ʈ ��ó�� ��絵 ������ �� ��������
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ��������� ��簡 ������
                //����Ʈ ��ó�� ��縦 �����´�
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
        }
        
        
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];

       
    }
    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
    public Sprite GetButton(int id, int buttonIndex)
    {
        return buttonData[id + buttonIndex];
    }
}
