using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    static public PlayerAction instance;//공유
    public string transferMapName;
    private UserAction User;
    private UserManager manager;
    private PlayerAction thePlayer;
    private CameraManager theCamera;
    public QuestManager questManager;

    
    void Awake()
    {
        thePlayer = FindObjectOfType<PlayerAction>();
        User = FindObjectOfType<UserAction>();
        manager = FindObjectOfType<UserManager>();
        theCamera = FindObjectOfType<CameraManager>();




    }
    

    public void SceneLoader(string sceneName)
    {


        thePlayer.currentMapName = transferMapName;
        theCamera.currentMapName = transferMapName;
        
        SceneManager.LoadScene(sceneName);

        
        

    }
    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", thePlayer.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", thePlayer.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();
        Debug.Log(questManager.questId);

        


        //Playerprefs :간단란 데이터 자장 기능을 지원하는 클래스
        //플레이어 위치

        //퀘스트아이디

        //퀘스트 액션 인덱스
    }


}
