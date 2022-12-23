using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonStory : MonoBehaviour
{
    public string transferMapName;
    //private Player thePlayer;
    
    static public PlayerAction instance;
    private PlayerAction thePlayer;
    // private CameraManager theCamera;



    public void SceneLoader(string sceneName)
    {
        thePlayer = FindObjectOfType<PlayerAction>();
        
        thePlayer.currentMapName = transferMapName;
        SceneManager.LoadScene(sceneName);



        thePlayer.manager = FindObjectOfType<GameManager>();

    }
    


}