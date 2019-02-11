using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopList : MonoBehaviour
{
    [SerializeField] private ScrollRect _myScrollRect   = null;

    public AddNewShop dupaa;
    public List<SingleShopRecord> _shopRecordsList = new List<SingleShopRecord>();

    [Header("PREFABS")]
    public SingleShopRecord shopRecordPrefab = null;

    private void Awake() {
        if(_myScrollRect == null) {
            _myScrollRect = this.gameObject.GetComponent<ScrollRect>();
        }
        dupaa.OnAddNewShop += GetAllRecords;
    }

    private void Start() {
        this.GetAllRecords();
    }

    [ContextMenu("GET ALL RECRODS")]
    public void GetAllRecords() {
        if(_shopRecordsList == null) { 
            return;
        }
        if(_shopRecordsList.Count > 0) {
            for (int i = 0; i < _shopRecordsList.Count; i++) {
                Destroy(_shopRecordsList[i].gameObject);
            }
            _shopRecordsList.Clear();
        }

        foreach (SingleShopData item in SQL.Instance.GetAllShopts()) {
           SingleShopRecord newGO = Instantiate(shopRecordPrefab, _myScrollRect.content);
           newGO.SetData(item.id ,item.shopName, item.address01, item.address02, item.nip);
           _shopRecordsList.Add(newGO);
        }
    }


    [ContextMenu("ADD_EXAMPLE_RECORDS")]
    public void TEST() {
        for (int i = 0; i < 7; i++) { //TODO: ADD TO LIST
            SingleShopRecord dupa = Instantiate(shopRecordPrefab, _myScrollRect.content);
            dupa.name = "test_" + i.ToString();
        }
    }
}