﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OponentScript : MonoBehaviour {
    private bool isActive;
    public void SetActive(bool active) {
        isActive = active;
    }
    public bool IsActive() {
        return isActive;
    }
}