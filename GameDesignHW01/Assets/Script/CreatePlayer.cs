using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreatePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player; 
    public static bool IfCreated = false; 
    void Start()
    {
        //生成一个Player
        if (IfCreated == false)
        {
            Instantiate(Player);
            IfCreated = true; 
            Debug.Log('1'); 
        }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
