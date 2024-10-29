using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PickUpScript : MonoBehaviour
{

    [SerializeField] private MeshRenderer[] meshes;
    [SerializeField] private GameObject[] particles;
    [SerializeField] private TextMeshProUGUI coinsText;
    private BoxCollider collider;
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < meshes.Length; i++)
            {
                meshes[i].enabled = false;
            }
            for (int i = 0; i < meshes.Length; i++)
            {
                particles[i].SetActive(true);
            }
            collider.enabled = false;
            Geekplay.Instance.PlayerData.Coins += 1;
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            Geekplay.Instance.Save();
        }
    }
}
