using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCommand : ICommand
{
    private GameObject cube; 
    private Color      newColor;
    private Color      oldColor;
    
    public ClickCommand(GameObject cube, Color color)
    {
        this.cube     = cube;
        newColor = color;
    }
    public void Execute()
    {
        oldColor                                    = cube.GetComponent<MeshRenderer>().material.color;
        cube.GetComponent<MeshRenderer>().material.color = newColor;
    }

    public void Undo()
    {
        cube.GetComponent<MeshRenderer>().material.color = oldColor;
    }
}