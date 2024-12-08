using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain1 : MonoBehaviour
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


  public void StartG1()

    {
        Levelset.LevelID = 1;
       

      SceneManager.LoadScene(1);


    }
}
