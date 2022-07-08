using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public int maxHealth = 100;

    int minHealth = 0;
    int currentHealth = 42;

    void Start() {
        currentHealth = maxHealth;
    }
}
