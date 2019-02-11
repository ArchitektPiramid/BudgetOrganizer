using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AddNewShop : MonoBehaviour
{
    public Button btnAdd    = null;
    public TMPro.TMP_InputField shopName;
    public TMPro.TMP_InputField address01;
    public TMPro.TMP_InputField address02;
    public TMPro.TMP_InputField nip;

    public System.Action OnAddNewShop = () => { };

    private void Awake() {
        btnAdd.onClick.AddListener(() => { guwno(); });
    }

    private void guwno() {
        SQL.Instance.CreateNewShop(shopName.text, address01.text, address02.text, nip.text);
        OnAddNewShop();
    }
}