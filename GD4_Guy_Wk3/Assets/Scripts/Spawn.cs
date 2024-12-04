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
    public int vNoofFood = 2;
    public string vFoodNeeded;
    
    public string[] vFoodNames;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vFoodNames[0] = "Banana";
        vFoodNames[1] = "Meat";
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
