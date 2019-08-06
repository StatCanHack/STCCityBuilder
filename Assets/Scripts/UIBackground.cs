using UnityEngine;

public class UIBackground : MonoBehaviour
{
    public int buildingSelection = 0;
    public int countdownTime = 1;
    public int expansiondisplacement = 1;
    public GameObject buildplots;
    public bool buildingTimerOn = true;

    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            ExpandPlots();
        }

        if (Input.GetKeyDown("n"))
        {
            buildingTimerOn = true;
        }

        if (Input.GetKeyDown("m"))
        {
            buildingTimerOn = false;
        }

        if (Input.GetKeyDown("b"))
        {
            countdownTime = 1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();

            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "plot")
                {
                    if (buildingTimerOn)
                    {
                        hitInfo.transform.GetComponentInParent<PlotBehaviour>().Build(buildingSelection, countdownTime);
                        countdownTime = countdownTime + 1;
                    }
                    else
                    {
                        hitInfo.transform.GetComponentInParent<PlotBehaviour>().Build(buildingSelection, 0);
                    }
                    // Building is currently a function of PlotBehaviour which is a component in plot
                    // replace PlotBehaviour with whatever component you want the build function to be in
                    Debug.Log("Hit");
                }
                else if (hitInfo.transform.gameObject.tag == "UIButton")
                {
                    if (hitInfo.transform.gameObject.name == "Store Selector")
                    {
                        buildingSelection = 1;
                    }
                    else if (hitInfo.transform.gameObject.name == "Park Selector")
                    {
                        buildingSelection = 2;
                    }
                    else if (hitInfo.transform.gameObject.name == "Road Selector")
                    {
                        buildingSelection = 3;
                    }
                    else if (hitInfo.transform.gameObject.name == "House Selector")
                    {
                        buildingSelection = 4;
                    }
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            //Debug.Log("Mouse is down");
        }
    }

    public void ExpandPlots()
    {
        for (int counter = -expansiondisplacement + 1; counter <= expansiondisplacement; counter++)
        {
            //Instantiate(buildplots, new Vector3(0, 0, 5 * expansiondisplacement), new Quaternion());
            Instantiate(buildplots, new Vector3(counter * 5, 0, expansiondisplacement * 5), new Quaternion());
            Instantiate(buildplots, new Vector3(-(counter * 5), 0, -(expansiondisplacement * 5)), new Quaternion());
            Instantiate(buildplots, new Vector3(expansiondisplacement * 5, 0, (counter - 1) * 5), new Quaternion());
            Instantiate(buildplots, new Vector3(-(expansiondisplacement * 5), 0, -((counter - 1) * 5)), new Quaternion());
        }
        expansiondisplacement++;
    }
}