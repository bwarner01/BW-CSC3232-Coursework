using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    public GameObject[] blockTypes;

    Camera c;
    int selectedBlock = 0;
    int rayDistance = 300;

    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Camera>();
        if(blockTypes.Length == 0)
        {
            Debug.LogError("You haven't assigned any Prefabs to spawn");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedBlock = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedBlock = 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
           GameObject placePosition = FindClosestGuide(GetClickPosition());
           GameObject block = Instantiate(blockTypes[selectedBlock], placePosition.transform.position, placePosition.transform.rotation);
           block.name += "_instantiated";
        }
    }

    Vector3[] GetClickPosition()
    {
        Vector3[] returnData = new Vector3[]{ Vector3.zero, Vector3.zero };
        Ray ray = c.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            returnData[0] = hit.point;
        }

        return returnData;
    }

    GameObject FindClosestGuide(Vector3[] clickPosition)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Placement");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = clickPosition[0];
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
}
