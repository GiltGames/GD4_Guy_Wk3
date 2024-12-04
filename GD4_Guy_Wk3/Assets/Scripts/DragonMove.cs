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

  //  public TextMeshProUGUI Score;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vFoodText.text = vFoodName;


    }

    // Update is called once per frame
    void Update()
    {
       
        
        
        transform.Translate(Vector3.forward * vDragonMoveSpeed * Time.deltaTime);


        if (fFed )
        {

            transform.Translate(Vector3.up * Time.deltaTime * vDragonMoveSpeedUp);


        }

      


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == vFoodNeeded)

        {
            Destroy(other.gameObject);


            ScoreKeep = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeep>();

            ScoreKeep.vScore = ScoreKeep.vScore + 1;

            fFed = true;

        }
    }



}
