using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnHit : MonoBehaviour
{
    [SerializeField] Color HitColor = Color.red;
    [SerializeField] Color[] originals = new Color[5]; //!  Evaluate this number, it should not be this large in the final game. 
    Renderer[] renderers;
    float flashTime = 0.2f;

    


    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        GetOriginalColors();
    }

    public void FlashColors()
    {
        StartCoroutine("Flash");
    }

    IEnumerator Flash()
    {
        if (renderers != null)
        {
            foreach (Renderer r in renderers)
            {
                r.material.SetColor("_BaseColor", HitColor);
            }

            yield return new WaitForSeconds(flashTime);

            foreach (Renderer r in renderers)
            {
                if (r != null)
                {
                    for (int i = 0; i < renderers.Length; i++)
                    {
                        renderers[i].material.SetColor("_BaseColor", originals[i]);

                    }

                }
            }
        }

    }

    void GetOriginalColors()
    {
        foreach (Renderer r in renderers)
        {
            
                for (int i = 0; i < renderers.Length; i++)
                {
                    originals[i] = renderers[i].material.color;
                }
            
        }
    }
}
