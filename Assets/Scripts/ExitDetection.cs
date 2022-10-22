using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDetection : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;
    
    bool exitCollision = false;

    public Rect windowRect = new Rect((Screen.width)-320,(Screen.height)-240,640,480);

    void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.tag == "Exit")
        {
            exitCollision = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if (exitCollision)
        {

            windowRect = GUI.Window(1, windowRect, DoMyWindow, "You Lose");
        }
    }

    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(20, 20, 600, 200), "Click Here To Restart"))
        {
            print("Not Yet Implented");
            exitCollision = false;
            transform.position = new Vector3(0,1,0);
        }
    }
}
