using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceManager : MonoBehaviour
{
    /*****************************************************************************
     *     In this C# Script I will handle all interactions that are not UI based
     *     1 - Rotation of selected prop
     *     2 - Tap to hold
     *     3 - Send info to HUD
     *****************************************************************************/

    [System.Serializable]
    public struct ARSet
    {
        public GameObject arObject;
        public GameObject menuPanel;
        public GameObject infoPanel;
    }

    [SerializeField] private List<ARSet> _arObjects;


    [Header("Experience attribuites")]
    [SerializeField] private float _rotationSpeed = 50f; // Rotation Speed
    
    private bool _isRotating;
    private int _currentIndex = 0;

    private GameObject _currentObject; // The currently rotating object

    void Start()
    {
        if (_arObjects.Count == 0)
        {
            Debug.LogWarning("No objects were injected inside the AR LIST.");
            return;
        }
        else
        {
            _currentObject = _arObjects[_currentIndex].arObject;
            _isRotating = true;
        }
    }

    void Update()
    {
        // If there is a current object, rotate it
        if(_currentObject != null)
        {
            if (_isRotating)
                RotateObject(_currentObject);

            HandleInput();
        }  
    }

    private void HandleInput()
    {
        // Detect mouse click or touch input
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;

                // Check if the clicked object is the current rotating object
                if (clickedObject == _currentObject)
                {
                    _isRotating = false; // Stop rotation when the object is clicked
                }
            }
        }

        // Resume rotation when the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = true; // Resume rotation
        }
    }

    private void RotateObject(GameObject targetObject)
    {
        // Rotate the target object
        targetObject.transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }

    private void ActivateSet(ARSet arSetObject, GameObject panel)
    {
        if (arSetObject.arObject.transform.parent != null)
            arSetObject.arObject.transform.parent.gameObject.SetActive(true);

        if (panel != null)
        {
            panel.SetActive(true);
        }
    }

    private void DeactivateAllSet(ARSet arSetObject)
    {
        if (arSetObject.arObject.transform.parent != null)
            arSetObject.arObject.transform.parent.gameObject.SetActive(false);

        if (arSetObject.infoPanel != null)
        {
            arSetObject.infoPanel.SetActive(false);
        }

        if (arSetObject.menuPanel != null)
        {
            arSetObject.menuPanel.SetActive(false);
        }
    }

    public void PickNextObject()
    {
        if (_arObjects.Count == 0) return;

        DeactivateAllSet(_arObjects[_currentIndex]);

        _currentIndex = (_currentIndex + 1) % _arObjects.Count;
        _currentObject = _arObjects[_currentIndex].arObject;

        ActivateSet(_arObjects[_currentIndex], _arObjects[_currentIndex].menuPanel);
    }

    public void PickPrevObject()
    {
        if (_arObjects.Count == 0) return;

        DeactivateAllSet(_arObjects[_currentIndex]);

        _currentIndex = (_currentIndex - 1 + _arObjects.Count) % _arObjects.Count;
        _currentObject = _arObjects[_currentIndex].arObject;


        ActivateSet(_arObjects[_currentIndex], _arObjects[_currentIndex].menuPanel);
    }

 

    public GameObject GetCurrentObject()
    {
        return _currentObject;
    }

    public List<ARSet> GetObjectsList()
    {
        return this._arObjects;
    }

    public void ActivateSoloMenuPanel()
    {
        _arObjects[_currentIndex].infoPanel.SetActive(false);
        _arObjects[_currentIndex].menuPanel.SetActive(true);
    }

    public void ActivateSoloInfoPanel()
    {
        _arObjects[_currentIndex].menuPanel.SetActive(false);
        _arObjects[_currentIndex].infoPanel.SetActive(true);
    }

}
