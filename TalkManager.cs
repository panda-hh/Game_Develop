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
        //아빠:1000, 친구:2000, 쓰레기200, 학교 100 선생님:3000 책상:5000  침대 300 컴퓨터 400
        talkData.Add(1000, new string[] {"아빠랑은 지금 할 말이 없다/2" });
        talkData.Add(2000, new string[] { "하이~!/2","....../2", "옹? 왜 여기서 자고 있지?/2" });
        talkData.Add(3000, new string[] { "선생님과는 지금 할 말이 없다/2"});


        talkData.Add(100, new string[] { "드디어 학교에 도착했다" });
        talkData.Add(200, new string[] { "왜 여기 쓰레기가있지?" });


        //퀘스트 토크
        talkData.Add(10 + 1000, new string[] { "우리딸 잘잤어?/0", "학교 얼렁 가야지...뭐하니/1", "(아침부터 왜이렇게 화를내시지....기분이 안좋다)/2" });
        talkData.Add(12 + 3000, new string[] { "서은아! 그래그래 오느라 수고했다/0", "얼렁 수업 들어라/0" });
        talkData.Add(11 + 2000, new string[] { "하이~!/0", "안녕~ 근데 왜 밖에 나와있어?/2", "너 어제 인스타 안봤어??/1", "응? 아직....못봤,, /2", "종친다!! 나 일단 먼저 들어갈게!!/3" });


        talkData.Add(20 + 1000, new string[] { "수업듣다 왜왔니?/1" });
        talkData.Add(20 + 2000, new string[] { "왜 수업듣나 나왔어? 너라도 얼렁 들으러가../1" });
        talkData.Add(20 + 3000, new string[] { "너 자리를 못찾겠니? 얼렁 찾아서 앉아/0" });

        talkData.Add(20 + 5000, new string[] {"수업이 시작됩니다/0" });

        talkData.Add(30 + 1000, new string[] { "그래~ 오늘 학교는 어땠어?/1","뭐,,학교야 항상 똑같죠../2","(힘들어서 빨리 쉬고 싶은데 왜 그러시는건지...)/2","...그래 알겠다/1" });
        talkData.Add(30 + 2000, new string[] { "현희야 무슨일이야 계속 걱정했어/2","그게 곧 수능인데 나는 해낸것도 없고 학교에만 있는게 맞는건가 싶어/1","그렇다고 학교를 안오면 어떡해 일단은../2","너도 똑같아!!절로가!!/1" });
        talkData.Add(30 + 3000, new string[] { "할말있니?/0","현희가 수업 들으러 안온게 걱정이 되서요/1","그 문제는 일단 나중에 말하자/0","(이래서 어른들은 믿을게 못돼 망할세상)/2" });

        talkData.Add(300, new string[] { "침대에 눕고 싶다" });
        talkData.Add(400, new string[] { "컴퓨터로 지금은 할 게 없다" });
        talkData.Add(500, new string[] { "주방에서 지금은 할 게 없다" });
        talkData.Add(50 + 300, new string[] { "으음...일찍일어나는 건 역시 너무 힘들어 ", "그래도 우리딸 아침밥 먹여서 보내야 열심히 학교가서 공부하지", "그 전에 컴퓨터로 일정 체크 좀 해볼까?" });
        talkData.Add(60 + 400, new string[] { "오늘 재택근무는 11시부터 하는 걸로 널널하고.. ", "큰 이슈사항은 없고 새로만든 서버 관리 정도만 해주면 되는구만 ", "이제 우리 서은이 밥하러 가야겠다" });
        talkData.Add(70 + 500, new string[] { "오늘 아침은 카레~~", "으음 역시 냄새가 좋네", "다했다!!조금 힘들긴 하지만 우리딸 기력 채워야지" });
        








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
    {//예외처리
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 10))
            {

                //퀘스트 맨처음 대사도 없을때 예 오브젝터
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀴스트 진행순서중 대사가 없을때
                //퀘스트 맨처음 대사를 가져온다
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
