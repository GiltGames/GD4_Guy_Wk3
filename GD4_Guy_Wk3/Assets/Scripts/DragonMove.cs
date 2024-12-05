using TMPro;
using UnityEngine;

public class DragonMove : MonoBehaviour
{

    public float vDragonMoveSpeed = 1;
    public float vDragonMoveSpeedUp = 5;
    public string vFoodNeeded;
    public string vFoodName;
    public TextMeshPro vFoodText;


    public GameObject other;
    public bool fFed = false;
    public int vScoreTmp;
    public ScoreKeep ScoreKeep;
    public GameObject Score;
    public GameObject vLastObjectHit;
    public string vLastObjectHitTag;
    public GameObject vShield;
    public float vShieldOnTime =2f;
    public float vShieldOnTimer;
    public MeshRenderer vMesh;
    public int vAppetiteTmp;
    public int vHunger;
    public Transform vHealthBar;
    public float vHealthBarLim =0.15f;
    public float vHealthBarShift;

    //  public TextMeshProUGUI Score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vFoodText.text = vFoodName;
        
        Transform parent = GameObject.Find("Fence").transform;
        Transform child = parent.Find("Torus");
        if (child != null)
        {

            vShield = child.gameObject;
        }

        vMesh = vShield.GetComponent<MeshRenderer>();
        vAppetiteTmp = vHunger;

        vHealthBar = transform.Find("ScalePoint");


    }

    // Update is called once per frame
    void Update()
    {
       
        if(vShieldOnTimer > .5f)

        {
            vShieldOnTimer = vShieldOnTimer - Time.deltaTime;

        }

        else

        {
            if (vShieldOnTimer > 0)
            {
                vMesh.enabled = false;
            }
            
            
           
        }

        
        transform.Translate(Vector3.forward * vDragonMoveSpeed * Time.deltaTime);


        if (fFed )
        {

            transform.Translate(Vector3.up * Time.deltaTime * vDragonMoveSpeedUp);


        }

      


    }

    private void OnTriggerEnter(Collider other)
    {
        vLastObjectHit = other.gameObject;
        vLastObjectHitTag = other.tag;
        Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == vFoodNeeded)

        {
            Destroy(other.gameObject);

            Debug.Log("FoodHit");

            ScoreKeep = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeep>();

            ScoreKeep.vScore = ScoreKeep.vScore + 1;

            vAppetiteTmp = vAppetiteTmp - 1;

            vHealthBar.localScale = new Vector3(vHealthBar.localScale.x* vAppetiteTmp/vHunger, vHealthBar.localScale.y, vHealthBar.localScale.z);


            
            if (vAppetiteTmp == 0)
            {
                fFed = true;
            }
        }


        if(other.tag == "Finish")
        {
            Debug.Log("Hit Shield");

            fFed = true;
            ScoreKeep = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeep>();

           
            vMesh.enabled = true;
            vShieldOnTimer = vShieldOnTime;

            ScoreKeep.vLives = ScoreKeep.vLives - 1;

            if(ScoreKeep.vLives == 0)

            {
                fGameEnd();

            }

        }

    }

    private void fGameEnd()
    {

        Time.timeScale = 0;
        ScoreKeep.vGameOver = true;
    }

}
