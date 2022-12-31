
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnToOrigin : MonoBehaviour
{
    [SerializeField] private Pose originpose;
    private XRGrabInteractable grabinteractable;
    private void Awake()
    {
        grabinteractable = GetComponent<XRGrabInteractable>();
        originpose.position = transform.position;
        originpose.rotation=transform.rotation;
    }

    private void OnEnable()
    {
        grabinteractable.selectExited.AddListener(laserGunReleased);
    }

    private void OnDisable()
    {
        grabinteractable.selectExited .RemoveListener(laserGunReleased);
    }
    private void laserGunReleased(SelectExitEventArgs arg0)
    {
        transform.position = originpose.position;
        transform.rotation = originpose.rotation;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
