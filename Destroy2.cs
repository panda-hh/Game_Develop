using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroy2 : MonoBehaviour
{
    static public Player2Action instance;//����
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

    //Playerprefs :���ܶ� ������ ���� ����� �����ϴ� Ŭ����
    //�÷��̾� ��ġ

    //����Ʈ���̵�

    //����Ʈ �׼� �ε���
}
   


}