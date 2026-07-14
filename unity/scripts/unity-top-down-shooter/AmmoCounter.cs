using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Jobs;
using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    public int ammoToDisplay;
    public int maxAmmoToDisplay;
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = ammoToDisplay.ToString() + "/" + maxAmmoToDisplay.ToString();
    }
}
