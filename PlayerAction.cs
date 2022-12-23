using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    public string currentMapName;//tranferMap스크립트에 있는 transferMapName변수의 값을 저장
    private CameraManager theCamera;
    private QuestManager questManager;
    public GameManager manager;
    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    int eunseo=21;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    static public PlayerAction instance;//공유
   

  
    void Start()
    {
        SceneManager.sceneLoaded += LoadedsceneEvent;

        if (instance==null)
       {
            DontDestroyOnLoad(this.gameObject);
            
            
            rigid = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            
            instance = this;
        }
       

        else if(instance == null & currentMapName == "Game1")
        {
            Destroy(this.gameObject);


        }
        else 
        {
            Destroy(this.gameObject);


        }

    }

    private void LoadedsceneEvent(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(scene.name + "으로 변경되었습니다.");

        int questId = PlayerPrefs.GetInt("QuestId");
        int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        if (this != null)
        {
            this.transform.position = new Vector3(x, y, 0);
        }
    }



    void Update()
    {
        if (currentMapName == "Stage1Back" & eunseo == 21)
        {

            theCamera = FindObjectOfType<CameraManager>();

            //thePlayer = FindObjectOfType<PlayerAction>();
            manager = FindObjectOfType<GameManager>();
            theCamera.target = GameObject.Find("Player");
            eunseo = 99;
            int questId = PlayerPrefs.GetInt("QuestId");
            int questActionIndex = PlayerPrefs.GetInt("QuestActionIndex");
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
             
            Debug.Log(questId);
            this.transform.position = new Vector3(x, y, 0);
            
            Debug.Log(questId);
            questManager = FindObjectOfType<QuestManager>();
            Debug.Log(questManager.questId);
            questManager.questId = questId+10;
            questManager.questActionIndex = questActionIndex;
            questManager.ControlObject();
            Debug.Log(questManager.questId);
            Debug.Log(questManager.questActionIndex);


        }
        
    

        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonDown("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if(vDown)
            isHorizonMove = false;


        

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);
        
      
        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == -1)
            dirVec = Vector3.left;
        else if (hDown && h == 1)
            dirVec = Vector3.right;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);
    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //RAY
        Debug.DrawRay(rigid.position,dirVec*0.7f,new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
    
            scanObject = rayHit.collider.gameObject;
        
        else
            scanObject = null;
    }
}
