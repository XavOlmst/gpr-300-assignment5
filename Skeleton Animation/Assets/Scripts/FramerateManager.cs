using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramerateManager : MonoBehaviour
{
    [SerializeField] private List<int> testingFramerates;
    private int index = 0;

    private void Start()
    {
        if (testingFramerates.Count == 0) return;

        Application.targetFrameRate = testingFramerates[0];
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            index++;

            if(index >= testingFramerates.Count)
            {
                index = 0;
            }

            Application.targetFrameRate = testingFramerates[index];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index--;

            if (index < 0)
            {
                index = testingFramerates.Count - 1;
            }

            Application.targetFrameRate = testingFramerates[index];
        }
    }
}
