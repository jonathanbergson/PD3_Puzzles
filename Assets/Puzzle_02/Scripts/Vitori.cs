using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Vitori : MonoBehaviour
{
    public GameObject panel;
    
    private void OnTriggerEnter(Collider other)
    {
        panel.SetActive(true);
        Time.timeScale = 0;
    }
}
