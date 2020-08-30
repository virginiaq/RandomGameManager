using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]

public class SimpleGameManager : MonoBehaviour
{
    public GameObject[] controllers;

    private Dictionary<int, GameObject> p_controllers = new Dictionary<int, GameObject>();
    int index = 0;
    private Vector3 currentPos;
    private Quaternion currentRot;

    void Start()
    {
        p_controllers.Add(index, Instantiate(controllers[index]));
        p_controllers[index].SetActive(true);
    }

    public void CheckOutOfBoundaries(Transform target)
    {
        if (target.position.y <= -5.0f)
            target.position = new Vector3(0.0f, 0.0f, 0.0f);
    }

    public void SwitchControl()
    {
        currentPos = p_controllers[index].transform.position;
        currentRot = p_controllers[index].transform.rotation;
        if (Input.GetKeyDown(KeyCode.Q))
        {

            p_controllers[index].SetActive(false);
            index++;
            if (index > controllers.Length - 1)
            {
                index = 0;
                p_controllers[index].transform.position = currentPos;
                p_controllers[index].transform.rotation = currentRot;
            }
            if (p_controllers.ContainsKey(index))
            {
                p_controllers[index].SetActive(true);
                p_controllers[index].transform.position = currentPos;
                p_controllers[index].transform.rotation = currentRot;
            }
                
            else
            {
                p_controllers.Add(index, Instantiate(controllers[index]));
                p_controllers[index].transform.position = currentPos;
                p_controllers[index].transform.rotation = currentRot;
            }
        }
    }

    private string GetNextControllerName()
    {
        // If next controller would be out of bounds, gets the one at index 0
        if (index + 1 >= controllers.Length)
            return controllers[0].name;
        else
            return controllers[index + 1].name;
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(400, 600, 500, 200), GetNextControllerName()))
            SwitchControl();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchControl();
        CheckOutOfBoundaries(p_controllers[index].transform);
    }
}

