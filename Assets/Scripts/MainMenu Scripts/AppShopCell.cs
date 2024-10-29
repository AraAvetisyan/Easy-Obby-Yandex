using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AppShopCell : MonoBehaviour
{
    public string PurName;
    public Button BuyDiamondButton;
    [SerializeField] TextMeshProUGUI DiamondCount;
    private void Start()
    {
        SubscribeOnPurchase();
        DiamondCount.text = Rewarder.instance.GetDiamondCountByName(PurName).ToString();
    }   
    public void SubscribeOnPurchase()
    {
        BuyDiamondButton.onClick.AddListener(delegate { InAppOperation(); });
    }
   
    private void InAppOperation()
    {
        Geekplay.Instance.RealBuyItem(PurName);
    }    
}