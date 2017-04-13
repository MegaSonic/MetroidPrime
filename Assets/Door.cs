using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IShootable {

    public void Shoot()
    {
        this.gameObject.SetActive(false);
    }


}
