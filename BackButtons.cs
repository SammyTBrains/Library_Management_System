using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _home;

    [Header("Add Record")]
    [SerializeField]
    private GameObject _addRecord;
    [SerializeField]
    private GameObject _addRecordBack;

    [Header("Search Records")]
    [SerializeField]
    private GameObject _searchRecords;
    [SerializeField]
    private GameObject _searchRecordsBack;

    [Header("Find Record")]
    [SerializeField]
    private GameObject _findRecord;
    [SerializeField]
    private GameObject _findRecordBack;

    [Header("Add To Library Books")]
    [SerializeField]
    private GameObject _addToLibraryBooks;
    [SerializeField]
    private GameObject _addToLibraryBooksBack;

    [Header("Add To Books Taken")]
    [SerializeField]
    private GameObject _addToBooksTaken;
    [SerializeField]
    private GameObject _addToBooksTakenBack;

    [Header("Add To Books Returned")]
    [SerializeField]
    private GameObject _addToBooksReturned;
    [SerializeField]
    private GameObject _addToBooksReturnedBack;

    [Header("Search Library Books")]
    [SerializeField]
    private GameObject _searchLibraryBooks;
    [SerializeField]
    private GameObject _searchLibraryBooksBack;

    [Header("Search Books Taken")]
    [SerializeField]
    private GameObject _searchBooksTaken;
    [SerializeField]
    private GameObject _searchBooksTakenBack;

    [Header("Search Books Returned")]
    [SerializeField]
    private GameObject _searchBooksReturned;
    [SerializeField]
    private GameObject _searchBooksReturnedBack;

    [Header("Find In Library Books")]
    [SerializeField]
    private GameObject _findInLibraryBooks;
    [SerializeField]
    private GameObject _findInLibraryBooksBack;

    [Header("Find In Books Taken")]
    [SerializeField]
    private GameObject _findInBooksTaken;
    [SerializeField]
    private GameObject _findInBooksTakenBack;

    [Header("Find In Books Returned")]
    [SerializeField]
    private GameObject _findInBooksReturned;
    [SerializeField]
    private GameObject _findInBooksReturnedBack;

    [Header("Update Record LB")]
    [SerializeField]
    private GameObject _updateRecordLB;
    [SerializeField]
    private GameObject _updateRecordLBBack;

    [Header("Update Record BT_L")]
    [SerializeField]
    private GameObject _updateRecordBT_L;
    [SerializeField]
    private GameObject _updateRecordBT_LBack;

    private SearchRecordsButtons SB;
    private DBFunction DBF;

    private void Start()
    {
        SB = this.gameObject.GetComponent<SearchRecordsButtons>();
        DBF = this.GetComponent<DBFunction>();
    }

    public void AddRecordBack()
    {
        _addRecord.SetActive(false);
        _home.SetActive(true);
        _addRecordBack.SetActive(false);
    }

    public void SearchRecordsBack()
    {
        _searchRecords.SetActive(false);
        _home.SetActive(true);
        _searchRecordsBack.SetActive(false);
    }

    public void FindRecordBack()
    {
        _findRecord.SetActive(false);
        _home.SetActive(true);
        _findRecordBack.SetActive(false);
    }

    public void AddToLibraryBooksBack()
    {
        _addToLibraryBooks.SetActive(false);
        _addRecord.SetActive(true);
        _addToLibraryBooksBack.SetActive(false);
    }

    public void AddToBooksTakenBack()
    {
        _addToBooksTaken.SetActive(false);
        _addRecord.SetActive(true);
        _addToBooksTakenBack.SetActive(false);
    }

    public void AddToBooksReturnedBack()
    {
        _addToBooksReturned.SetActive(false);
        _addRecord.SetActive(true);
        _addToBooksReturnedBack.SetActive(false);
    }

    public void SearchLibraryBooksBack()
    {
        _searchLibraryBooks.SetActive(false);
        _searchRecords.SetActive(true);
        if (SB.LBPrefabs != null)
        {
            foreach (GameObject prefab in SB.LBPrefabs)
            {
                Destroy(prefab);
            }
        }
        _searchLibraryBooksBack.SetActive(false);
    }

    public void SearchBooksTakenBack()
    {
        _searchBooksTaken.SetActive(false);
        _searchRecords.SetActive(true);
        if (SB.BTPrefabs != null)
        {
            foreach (GameObject prefab in SB.BTPrefabs)
            {
                Destroy(prefab);
            }
        }
        _searchBooksTakenBack.SetActive(false);
    }

    public void SearchBooksReturnedBack()
    {
        _searchBooksReturned.SetActive(false);
        _searchRecords.SetActive(true);
        if (SB.BRPrefabs != null)
        {
            foreach (GameObject prefab in SB.BRPrefabs)
            {
                Destroy(prefab);
            }
        }
        _searchBooksReturnedBack.SetActive(false);
    }

    public void FindInLibraryBooksBack()
    {
        _findInLibraryBooks.SetActive(false);
        _findRecord.SetActive(true);
        if (DBF.LBPrefab != null)
        {
            Destroy(DBF.LBPrefab);
        }
        DBF.BookNameFindLB.text = "";
        _findInLibraryBooksBack.SetActive(false);
    }

    public void FindInBooksTakenBack()
    {
        _findInBooksTaken.SetActive(false);
        _findRecord.SetActive(true);
        if (DBF.BTPrefab != null)
        {
            Destroy(DBF.BTPrefab);
        }
        DBF.BookNameFindBT.text = "";
        _findInBooksTakenBack.SetActive(false);
    }

    public void FindInBooksReturnedBack()
    {
        _findInBooksReturned.SetActive(false);
        _findRecord.SetActive(true);
        if (DBF.BRPrefab != null)
        {
            Destroy(DBF.BRPrefab);
        }
        DBF.BookNameFindBR.text = "";
        _findInBooksReturnedBack.SetActive(false);
    }

    public void UpdateRecordLBBack()
    {
        _updateRecordLB.SetActive(false);
        if (DBFunction.Instance.getSubmitScreen() == "LB")
        {
            _searchLibraryBooks.SetActive(true);
            SB.displayRecords("LibraryBooks");
        }
        else if(DBFunction.Instance.getSubmitScreen() == "LBF")
        {
            _findInLibraryBooks.SetActive(true);
            DBFunction.Instance.SelectBookFromDB("LibraryBooks", DBFunction.Instance.BookNameFindLB.text);
        }
        _updateRecordLBBack.SetActive(false);
    }

    public void UpdateRecordBT_LBack()
    {
        _updateRecordBT_L.SetActive(false);
        if (DBFunction.Instance.getSubmitScreen() == "BT")
        {
            _searchBooksTaken.SetActive(true);
            SB.displayRecords("BooksTaken");
        }
        else if (DBFunction.Instance.getSubmitScreen() == "BR")
        {
            _searchBooksReturned.SetActive(true);
            SB.displayRecords("BooksReturned");
        }
        else if (DBFunction.Instance.getSubmitScreen() == "BTF")
        {
            _findInBooksTaken.SetActive(true);
            DBFunction.Instance.SelectBookFromDB("BooksTaken", DBFunction.Instance.BookNameFindBT.text);
        }
        else if (DBFunction.Instance.getSubmitScreen() == "BRF")
        {
            _findInBooksReturned.SetActive(true);
            DBFunction.Instance.SelectBookFromDB("BooksReturned", DBFunction.Instance.BookNameFindBR.text);
        }
        _updateRecordBT_LBack.SetActive(false);
    }
}
