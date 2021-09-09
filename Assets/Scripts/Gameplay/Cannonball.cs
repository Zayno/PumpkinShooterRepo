using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    [SerializeField] private float DestructionDelayTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, DestructionDelayTime);
    }
}
