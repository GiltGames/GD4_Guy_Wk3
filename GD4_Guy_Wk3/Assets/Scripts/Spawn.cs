using UnityEngine;

public class Spawn : MonoBehaviour
{

    public float vTimer;
    public GameObject vDragon;
    public float vSpawnXL;
    public float vSpawnXU;
    public float vSpawnZU;
    public float vSpawnZL;
    public float vSpawnInterval = 5;
    public float vNextSpawn = 5;
    public float vSpawnAccel = 0.95f;
    public Vector3 vSpawnLoc;
    public Transform vTarget;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vTimer = vTimer + Time.deltaTime;

        if (vTimer > vNextSpawn)
        {
           vSpawnLoc = new Vector3(Random.Range(vSpawnXL, vSpawnXU), 2  , Random.Range(vSpawnZL, vSpawnZU));

            Instantiate(vDragon);
            vDragon.transform.position = vSpawnLoc;
            vDragon.transform.rotation = Quaternion.identity;
            vDragon.transform.LookAt(vTarget);




           
            vSpawnInterval = vSpawnInterval * vSpawnAccel * Random.Range(0.8f,1.2f);
 vNextSpawn = vTimer + vSpawnInterval;
        }
        
        


    }
}
