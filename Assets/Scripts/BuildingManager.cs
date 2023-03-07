using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{

    private GameObject selectedObject = null;
    private GameObject pendingObject = null;

    [Header("GUI Buttons")]
    public Button increase;
    public Button decrease;
    public Button destroy;
    public Button capsule;
    public Button cylinder;
    public Button sphere;
    public Button exit;

    [Header("Configuration")]
    public float maxDistance = 100f;
    public LayerMask layerMask;
    public Material originalMaterialCube = null;

    public float minimumHeight = 0.5f;
    public float maximumHeight = 1.5f;
    public string buildingTag = "Building";

    public GameObject Capsule;
    public GameObject Cylinder;
    public GameObject Sphere;

    void Start()
    {
        increase.onClick.AddListener(IncreaseObjectHeight);
        decrease.onClick.AddListener(DecreaseObjectHeight);
        destroy.onClick.AddListener(DestroyObject);
        capsule.onClick.AddListener(ReplaceWithCapsule);
        cylinder.onClick.AddListener(ReplaceWithCylinder);
        sphere.onClick.AddListener(ReplaceWithSphere);
        exit.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        IsObjectClicked();
    }

    void IsObjectClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
            {
                if (selectedObject != null)
                {
                    selectedObject.GetComponent<Renderer>().material = originalMaterialCube;
                }
                selectedObject = hit.transform.gameObject;
                selectedObject.GetComponent<Renderer>().material = new Material(Shader.Find("Standard"));

                SetStatusButtons(true);
            }
        }
    }

    void SetStatusButtons(bool status)
    {
        increase.gameObject.SetActive(status);
        decrease.gameObject.SetActive(status);
        destroy.gameObject.SetActive(status);
        capsule.gameObject.SetActive(status);
        cylinder.gameObject.SetActive(status);
        sphere.gameObject.SetActive(status);
        exit.gameObject.SetActive(status);
    }

    void ReplaceObject(GameObject newPrimitive)
    {
        if(selectedObject != null)
        {
            Vector3 oldPosition = selectedObject.transform.position;
            Vector3 oldScale = selectedObject.transform.localScale;

            DestroyObject();
            GameObject newObject = Instantiate(newPrimitive);
            newObject.transform.position = oldPosition;
            newObject.transform.localScale = oldScale;
            newObject.tag = buildingTag;
        }
    }

    void ReplaceWithCapsule()
    {
        if(Capsule != null)
            ReplaceObject(Capsule);
    }

    void ReplaceWithCylinder()
    {
        if(Cylinder != null)
            ReplaceObject(Cylinder);
    }

    void ReplaceWithSphere()
    {
        if(Sphere != null)
            ReplaceObject(Sphere);
    }

    void IncreaseObjectHeight()
    {
        if (selectedObject != null && selectedObject.transform.localScale.y < maximumHeight)
        {
            Vector3 objectScale = selectedObject.transform.localScale;
            objectScale.y += 0.1f;
            selectedObject.transform.localScale = objectScale;

            Vector3 objectPosition = selectedObject.transform.position;
            objectPosition.y = objectScale.y / 2;
            selectedObject.transform.position = objectPosition;
        }
    }
    
    void DecreaseObjectHeight()
    {
        if (selectedObject != null && selectedObject.transform.localScale.y > minimumHeight)
        {
            Vector3 objectScale = selectedObject.transform.localScale;
            objectScale.y -= 0.1f;
            selectedObject.transform.localScale = objectScale;

            Vector3 objectPosition = selectedObject.transform.position;
            objectPosition.y = objectScale.y / 2;
            selectedObject.transform.position = objectPosition;
        }
    }

    void DestroyObject()
    {
        Destroy(selectedObject);
    }

    void ExitGame()
    {
        Application.Quit();
    }
}
