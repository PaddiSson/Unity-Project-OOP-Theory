using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! INHERITANCE
public class MainManager : MonoBehaviour
{
    //- VARS
    [SerializeField] private GameObject[] plotsBounds;
    [SerializeField] private GameObject[] plotsSpawnBounds;

    //- MAIN METHODS
    private void Start() 
    {
        // Hide plots bounds in Game View
        HidePlotsBounds();
    }
    private void FixedUpdate()
    {
        // Draw lines between plots bounds limit in Editor
        TraceLinesBetweenPlotsBounds();
    }


    //- OTHER METHODS
    //* Draw lines between plots bounds limit in Editor
    private void TraceLinesBetweenPlotsBounds()
    {
        // Plots bounds for Game area
        for (int i = 0; i < plotsBounds.Length; i++)
        {
            int _nextIndex = i + 1;
            if (i == plotsBounds.Length - 1) _nextIndex = 0;
            Debug.DrawLine(plotsBounds[i].transform.position, plotsBounds[_nextIndex].transform.position, Color.red);
        }
        // Plots bounds for Spawn area
        for (int i = 0; i < plotsSpawnBounds.Length; i++)
        {
            int _nextIndex = i + 1;
            if (i == plotsSpawnBounds.Length - 1) _nextIndex = 0;
            Debug.DrawLine(plotsSpawnBounds[i].transform.position, plotsSpawnBounds[_nextIndex].transform.position, Color.green);
        }
    }

    //* Hide plots bounds in Game View
    private void HidePlotsBounds()
    {
        // Plots bounds for Game area
        for (int i = 0; i < plotsBounds.Length; i++)
        {
            plotsBounds[i].SetActive(false);
        }
        // Plots bounds for Spawn area
        for (int i = 0; i < plotsSpawnBounds.Length; i++)
        {
            plotsSpawnBounds[i].SetActive(false);
        }
    }
}
