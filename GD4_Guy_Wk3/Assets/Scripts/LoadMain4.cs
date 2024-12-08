using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain4 : MonoBehaviour
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


  public void StartG4()

    {
        Levelset.LevelID = 4;
       

        SceneManager.LoadScene(1);


    }
}
