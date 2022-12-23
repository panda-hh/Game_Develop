using UnityEngine;
using UnityEngine.SceneManagement;

public class JustButton : MonoBehaviour
{

    public GameObject message;
    

    public void SceneLoader(string sceneName)
    {

        SceneManager.LoadScene(sceneName);

    }

    public void SceneLoader1(string sceneName)
    {
        int questId = PlayerPrefs.GetInt("QuestId");
        if (questId < 40)
        {
            SceneManager.LoadScene(sceneName);
        }

    }
    public void SceneLoader2(string sceneName)
    {
        int questId = PlayerPrefs.GetInt("QuestId");
        if (questId >= 40)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            message.SetActive(true);
        }
    }
}
