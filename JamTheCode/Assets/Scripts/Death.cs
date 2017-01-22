using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    [SerializeField] private GameObject explosion;
    public void StartExplosion() {
        explosion.SetActive(true);
        SoundManager.Instance.PlayMainExplosion();
        GameObject tower = gameObject.transform.FindChild("TowerBase").gameObject;

        tower.SetActive(false);
    }
}
