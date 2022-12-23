using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy : MonoBehaviour
{
    static public PlayerAction instance;//공유
    public PlayerAction thePlayer;
    private CameraManager theCamera;
    public QuestManager questManager;




    public void Awake()
    {
        thePlayer = FindObjectOfType<PlayerAction>();
        
        theCamera = FindObjectOfType<CameraManager>();
        questManager = FindObjectOfType<QuestManager>();
    }
    public void SceneLoader(string sceneName)
    {
        PlayerPrefs.SetFloat("PlayerX", thePlayer.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", thePlayer.transform.position.y);
        PlayerPrefs.SetInt("QuestId", questManager.questId);
        PlayerPrefs.SetInt("QuestActionIndex", questManager.questActionIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(sceneName);




    }
  

    public void DestroyAll()
    {

        Destroy(thePlayer.gameObject);
        Destroy(theCamera.gameObject);

        //Playerprefs :간단란 데이터 자장 기능을 지원하는 클래스
        //플레이어 위치

        //퀘스트아이디

        //퀘스트 액션 인덱스
    }
   


}
