using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomColorOnSpawn : MonoBehaviour
{
    //TODO make this work based on just the body color materialnot all of them
    private void Awake()
    {
        Color randColor = GetRandomColor();
        foreach (var mesh in GetComponentsInChildren<Renderer>())
        {
            mesh.material.SetColor("_BaseColor", randColor);
            
        }
        
    }
    private Color GetRandomColor()
    {
        return new Color(
            UnityEngine.Random.Range(0f, 1f), //R
            UnityEngine.Random.Range(0f, 1f), //G
            UnityEngine.Random.Range(0f, 1f)); //B
    }
}
