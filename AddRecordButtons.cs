using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRecordButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _addRecord, _addToLibraryBooks, _addToLibraryBooksBack, _addToBooksTaken, _addToBooksTakenBack, _addToBooksReturned, _addToBooksReturnedBack;

    private void deactivateThisGameObject()
    {
        _addRecord.SetActive(false);
    }

    public void AddToLibraryBooks()
    {
        deactivateThisGameObject();
        _addToLibraryBooks.SetActive(true);
        _addToLibraryBooksBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("LB");
    }

    public void AddToBooksTaken()
    {
        deactivateThisGameObject();
        _addToBooksTaken.SetActive(true);
        _addToBooksTakenBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("BT");
    }

    public void AddToBooksReturned()
    {
        deactivateThisGameObject();
        _addToBooksReturned.SetActive(true);
        _addToBooksReturnedBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("BR");
    }
}
