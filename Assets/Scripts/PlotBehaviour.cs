using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{

    public GameObject store;
    public GameObject park;
    public GameObject road;
    public GameObject house;
    public GameObject scaffold;
    int objectToBuild;

    public int buildState = 0;

    public bool isPlaced = false;
    //public int objectSelection;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.parent = transform;
        //Instantiate(objectToSpawn);
        //objectToSpawn.transform.SetPositionAndRotation(new Vector3(0,1,0), new Quaternion());
        //objectToSpawn.transform.position = transform.position + new Vector3(0, 0.05f, 0);

        //objectToSpawn.transform.SetPositionAndRotation(GetComponentInParent(p) new Vector3(0, 0, 0), new Quaternion());
        //GameObject clone = (GameObject)Instantiate(prefab, position, rotation);
        //clone.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (buildState == 2)
        {
            place(objectToBuild);
        }
    }

    public void Build(int objectSelection, int countdownTime)
    {
        // This is where the magic happens
        if (!isPlaced)
        {
            //Instantiate(scaffold, transform.position + new Vector3(0, 0.5f, 0), new Quaternion());
            objectToBuild = objectSelection;
            isPlaced = true;
            buildState = 1;
            Debug.Log("build state 1");
            StartCoroutine(countDown(countdownTime));
        }
    }

    public void place(int objectSelection)
    {
        //scaffold.transform.localScale = new Vector3(0, 0, 0);
        //Destroy(scaffold);
        //Destroy(this.scaffold);
        buildState = 3;
        Debug.Log("build state 3");
        switch (objectSelection)
        {
            case 1:
                //gameObject.transform.parent = transform;
                GameObject newObjectHouse = Instantiate(store, transform.position + new Vector3(0, 0, 0), new Quaternion(0,180,0,0));
                newObjectHouse.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                //store.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                break;
            case 2:
                //gameObject.transform.parent = transform;
                Instantiate(park, transform.position + new Vector3(0, 0.05f, 0), new Quaternion());
                //Instantiate(park);
                //park.transform.position = transform.position + new Vector3(0, 0.05f, 0);
                break;
            case 3:
                //gameObject.transform.parent = transform;
                Instantiate(road, transform.position + new Vector3(0, 0.05f, 0), new Quaternion());
                //Instantiate(road);
                //road.transform.position = transform.position + new Vector3(0, 0.05f, 0);
                break;
            case 4:
                //gameObject.transform.parent = transform;
                //Instantiate(house, transform.position + new Vector3(0, 0.5f, 0), new Quaternion(0, 90, 0, 0));
                GameObject newObjectStore = Instantiate(house, transform.position + new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
                newObjectStore.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                //Instantiate(house);
                //house.transform.position = transform.position + new Vector3(0, 0.5f, 0);
                break;
        }
    }

    IEnumerator countDown(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        buildState = 2;
        Debug.Log("build state 2");
    }
}
