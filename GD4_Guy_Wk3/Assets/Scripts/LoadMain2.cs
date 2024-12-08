using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain2 : MonoBehaviour
{
    
    public Levelset Levelset;
    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }


  public void StartG2()

    {
        Levelset.LevelID = 2;
       

        SceneManager.LoadScene(1);


    }
}
