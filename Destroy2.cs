using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy2 : MonoBehaviour
{
    static public Player2Action instance;//공유
    public Player2Action thePlayer;
    private CameraManager theCamera;
    public QuestManager questManager;




    public void Awake()
    {
        
        thePlayer = FindObjectOfType<Player2Action>();
        theCamera = FindObjectOfType<CameraManager>();
        questManager = FindObjectOfType<QuestManager>();
    }
    public void SceneLoader(string sceneName)
    {
        PlayerPrefs.SetFloat("Player2X", thePlayer.transform.position.x);
        PlayerPrefs.SetFloat("Player2Y", thePlayer.transform.position.y);
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