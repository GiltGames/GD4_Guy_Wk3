using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public float vTimer;
    public GameObject[] vDragons;
    public float vSpawnXL;
    public float vSpawnXU;
    public float vSpawnZU;
    public float vSpawnZL;
    public float vSpawnInterval = 5;
    public float vNextSpawn = 5;
    public float vSpawnAccel = 0.95f;
    public Vector3 vSpawnLoc;
    public Transform vTarget;
    public int vNoofFood    ;
    public string vFoodNeeded;
    
    public string[] vFoodNames;
    public GameObject LevelSetHolder;
    public GameObject Basket1;
    public GameObject Basket2; 
    public GameObject Basket3;
    public GameObject Basket4;
    public GameObject Basket5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
        LevelSetHolder = GameObject.Find("LevelSetHolder");
//default in case parameter pass doesn't work
        vNoofFood = 5;

        if (LevelSetHolder != null)
        {

            //Set food max to Lvel and deactiveate etra baskets

            vNoofFood = LevelSetHolder.GetComponent<Levelset>().LevelID;


            if (vNoofFood < 5)
            {
                Basket5.SetActive(false);
            }

            if (vNoofFood < 4)
            {
                Basket4.SetActive(false);
            }

            if (vNoofFood < 3)
            {
                Basket3.SetActive(false);
            }
            if (vNoofFood < 2)
            {
                Basket2.SetActive(false);
            }


            Destroy(LevelSetHolder);
        }



    }

    // Update is called once per frame
    void Update()
    {
        vTimer = vTimer + Time.deltaTime;

        if (vTimer > vNextSpawn || Input.GetKeyDown(KeyCode.Space))
        {
           vSpawnLoc = new Vector3(Random.Range(vSpawnXL, vSpawnXU), 2  , Random.Range(vSpawnZL, vSpawnZU));
            int vIndex = Random.Range(0, vNoofFood);
            Instantiate(vDragons[vIndex]);
            vDragons[vIndex].transform.position = vSpawnLoc;
            vDragons[vIndex].transform.rotation = Quaternion.identity;
            vDragons[vIndex].transform.LookAt(vTarget);

            vFoodNeeded = "Food" + vIndex;
            Debug.Log(vFoodNeeded);

            


            DragonMove script = vDragons[vIndex].GetComponent<DragonMove>();
            script.vFoodNeeded = vFoodNeeded;

            Debug.Log(vFoodNames[vIndex]);
            script.vFoodName = vFoodNames[vIndex];
            


           
            vSpawnInterval = vSpawnInterval * vSpawnAccel * Random.Range(0.8f,1.2f);
 vNextSpawn = vTimer + vSpawnInterval;
        }
        
        


    }
}
