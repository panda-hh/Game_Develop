using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
{
    static public PlayerAction instance;//����
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

        


        //Playerprefs :���ܶ� ������ ���� ����� �����ϴ� Ŭ����
        //�÷��̾� ��ġ

        //����Ʈ���̵�

        //����Ʈ �׼� �ε���
    }


}
