using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MinionTypes
{
    TURTLE_1,
    TURTLE_2,
    TURTLE_3,
    TURTLE_4,
    TURTLE_5
}


public class Spawn : MonoBehaviour
{

    [SerializeField] GameObject[] MinionPrefabs;

    public void SpawnMinion(MinionTypes minionType) {
        switch (minionType) {
            case MinionTypes.TURTLE_1:
                Instantiate(MinionPrefabs[0], transform.position, Quaternion.identity);
                break;
            case MinionTypes.TURTLE_2:
                Instantiate(MinionPrefabs[1], transform.position, Quaternion.identity);
                break;
            case MinionTypes.TURTLE_3:
                Instantiate(MinionPrefabs[2], transform.position, Quaternion.identity);
                break;
            case MinionTypes.TURTLE_4:
                Instantiate(MinionPrefabs[3], transform.position, Quaternion.identity);
                break;
            case MinionTypes.TURTLE_5:
                Instantiate(MinionPrefabs[4], transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
    }
}
