using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListDropdown : MonoBehaviour
{
    public List<SingleShopData> _list = new List<SingleShopData>();

    public TMPro.TMP_Dropdown _myDropdown = null;

    private void Awake() {
        _myDropdown = this.gameObject.GetComponent<TMPro.TMP_Dropdown>();
    }


    [ContextMenu("GET ALL")]
    public void PopulateAllDropdownList() {
        _myDropdown.options.Clear();
        foreach (var item in SQL.Instance.GetAllShopts()) {
            var option = new TMPro.TMP_Dropdown.OptionData() {
                text = item.id + " - " + item.shopName + " - " + item.address01
            };

            _myDropdown.options.Add(option);
        }
    }

}