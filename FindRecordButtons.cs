using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRecordButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _findRecord, _findInLibraryBooks, _findInLibraryBooksBack, _findInBooksTaken, _findInBooksTakenBack, _findInBooksReturned, _findInBooksReturnedBack;

    private void deactivateThisGameObject()
    {
        _findRecord.SetActive(false);
    }

    public void FindInLibraryBooks()
    {
        deactivateThisGameObject();
        _findInLibraryBooks.SetActive(true);
        _findInLibraryBooksBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("LBF");
    }

    public void FindInBooksTaken()
    {
        deactivateThisGameObject();
        _findInBooksTaken.SetActive(true);
        _findInBooksTakenBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("BTF");
    }

    public void FindInBooksReturned()
    {
        deactivateThisGameObject();
        _findInBooksReturned.SetActive(true);
        _findInBooksReturnedBack.SetActive(true);
        DBFunction.Instance.setSubmitScreen("BRF");
    }
}
