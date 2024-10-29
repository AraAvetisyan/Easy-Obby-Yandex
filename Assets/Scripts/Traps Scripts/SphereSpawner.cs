using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;
    private GameObject sphere;
    [SerializeField] private Material[] materials;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        int mat = Random.RandomRange(0, materials.Length);
        yield return new WaitForSeconds(3);
        
        sphere = Instantiate(spherePrefab,transform.position,transform.rotation);
        sphere.GetComponent<MeshRenderer>().material = materials[mat];
        StartCoroutine(DestroyObject());
        StartCoroutine(Spawn());
    }
    public IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(3);
        Destroy(sphere);
    }
}
