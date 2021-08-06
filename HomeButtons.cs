using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _home, _addRecord, _addRecordBack, _searchRecords, _searchRecordsBack, _findRecord, _findRecordBack;

    private void deactivateThisGameObject()
    {
        _home.SetActive(false);
    }

    public void AddRecord()
    {
        deactivateThisGameObject();
        _addRecord.SetActive(true);
        _addRecordBack.SetActive(true);
    }

    public void SearchRecords()
    {
        deactivateThisGameObject();
        _searchRecords.SetActive(true);
        _searchRecordsBack.SetActive(true);
    }

    public void FindRecord()
    {
        deactivateThisGameObject();
        _findRecord.SetActive(true);
        _findRecordBack.SetActive(true);
    }
}
