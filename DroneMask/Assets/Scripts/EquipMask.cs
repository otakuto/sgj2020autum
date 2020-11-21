using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMask : MonoBehaviour
{
    [SerializeField]
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        Destroy(target);
    }
}
