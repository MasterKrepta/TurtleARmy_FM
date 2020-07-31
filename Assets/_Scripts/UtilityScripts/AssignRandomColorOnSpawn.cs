using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignRandomColorOnSpawn : MonoBehaviour
{
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
