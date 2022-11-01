using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent agent;

    public int exitNo = 0;

    public Rect windowRect = new Rect((Screen.width)-320,(Screen.height)-240,640,480);

    public GameObject FindClosestExit()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Exit");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Exit");
        exitNo = gos.Length;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject exit = FindClosestExit();
        agent.SetDestination(exit.transform.position);
        if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathPartial)
        {
            Destroy(exit);
            exitNo -= 1;
        }

    }

    void OnGUI()
    {
        if (exitNo == 0)
        {
            windowRect = GUI.Window(1, windowRect, DoMyWindow, "You Win");
        }
    }

    void DoMyWindow(int windowID)
    {
        if (GUI.Button(new Rect(20, 20, 600, 200), "Click Here To Restart"))
        {
            Application.LoadLevel("Level");
        }
    }
}
