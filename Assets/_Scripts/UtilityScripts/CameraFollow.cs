using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField]Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Helpers.GameOver) { return; }
        transform.position = Player.position + offset;
    }
}
