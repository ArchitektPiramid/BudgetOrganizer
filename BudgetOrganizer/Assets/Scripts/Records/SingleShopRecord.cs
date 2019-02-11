using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleShopRecord : MonoBehaviour
{
    public TMPro.TextMeshProUGUI ID         = null;
    public TMPro.TextMeshProUGUI shopName   = null;
    public TMPro.TextMeshProUGUI address01  = null;
    public TMPro.TextMeshProUGUI address02  = null;
    public TMPro.TextMeshProUGUI nip        = null;

    public void SetData(string id, string shopName, string address01, string address02, string nip) {
        this.ID.text        = id;
        this.shopName.text  = shopName;
        this.address01.text = address01;
        this.address02.text = address02;
        this.nip.text       = nip;
    }
}