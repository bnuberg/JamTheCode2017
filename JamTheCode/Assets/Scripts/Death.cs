using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    [SerializeField] private GameObject explosion;
    public void StartExplosion() {
        explosion.SetActive(true);
    }
}
