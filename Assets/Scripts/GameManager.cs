using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Patroling cube;
    
    void Start()
    {
        cube = GameObject.FindGameObjectWithTag("Cube").GetComponent<Patroling>();
           
    }

    
    void Update()
    {
        if (cube.isGrounded == false && cube.transform.position.y <= -2)
        {
            
            SceneManager.LoadScene("GameOver");
        }
        //else if
    }
}
