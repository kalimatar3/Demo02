using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealToEnvironment : DameDealer
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.transform.childCount <= 0) return;
        if(!other.transform.GetChild(0).gameObject.activeInHierarchy) return ;
        EnvironmentReciver environmentReciver = GetComponent<EnvironmentReciver>();
        if(environmentReciver == null) return;
            other.transform.GetChild(0).gameObject.SetActive(false);
    }
    protected void OnTriggerExit(Collider other)
    {
        if(other.transform.childCount <= 0) return;
        if(other.transform.GetChild(0).gameObject.activeInHierarchy) return ;
        EnvironmentReciver environmentReciver = GetComponent<EnvironmentReciver>();
        if(environmentReciver == null) return;
        other.transform.GetChild(0).gameObject.SetActive(true);
    }
}