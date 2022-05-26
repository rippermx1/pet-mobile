using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [HideInInspector] public Vector3 CurrentMousePosition;
    private Camera mainCamera;

    [SerializeField] private GameObject groundPlayerRef;
    [SerializeField] private GameObject groundIARef;

    [SerializeField] private Material groundPlayerMaterialRef;
    [SerializeField] private Material groundIAMaterialRef;
    [SerializeField] private Material groundDefaultMaterialRef;

    private MeshRenderer meshRendererPlayer;
    private MeshRenderer meshRendererIA;

    [HideInInspector] public string sideOfMap;
    [HideInInspector] public string waypointToUse;

    public static GroundController instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        mainCamera = Camera.main;
        meshRendererPlayer = groundPlayerRef.GetComponent<MeshRenderer>();
        meshRendererIA = groundIARef.GetComponent<MeshRenderer>();

        sideOfMap = null;
        waypointToUse = null;
    }

    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);

        if (CardsController.instance.onDrag) {
            foreach (var hit in hits)
            {
                if (hit.collider.gameObject.layer != LayerMask.NameToLayer("PlayerGround") && hit.collider.gameObject.layer != LayerMask.NameToLayer("IAGround"))
                {
                    setSideOfMap(null);
                    setDefaultGround();
                    continue;
                }

                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 10000, Color.red);
                CurrentMousePosition = hit.point;

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("PlayerGround"))
                {
                    meshRendererPlayer.material = groundPlayerMaterialRef;
                    meshRendererIA.material = groundDefaultMaterialRef;
                    setSideOfMap(hit.collider.gameObject.name);
                }

                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("IAGround"))
                {
                    meshRendererPlayer.material = groundDefaultMaterialRef;
                    meshRendererIA.material = groundIAMaterialRef;
                    setSideOfMap(hit.collider.gameObject.name);
                }

                if (hit.point.x < 0)
                {
                    // Debug.Log("Left Player");
                    waypointToUse = "WaypointsPlayerLeft";
                }
                if (hit.point.x > 0)
                {
                    // Debug.Log("Right Player");
                    waypointToUse = "WaypointsPlayerRight"; 
                }
                break;
            }
        }

        if (CardsController.instance.onPointerUp) {
            setDefaultGround();
            Instantiate(GameManager.instance.catPrefab);
            CardsController.instance.onPointerUp = false;
        }
    }

    private void setSideOfMap(string side) {
        sideOfMap = side;
    }

    public void setDefaultGround()
    {
        meshRendererPlayer.material = groundDefaultMaterialRef;
        meshRendererIA.material = groundDefaultMaterialRef;
    }
}
