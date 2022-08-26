using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyMarkerViewer : MonoBehaviour
{
    [SerializeField] private GameObject _marker;
    [SerializeField] private Vector3 _offset = new Vector3(0, 2.5f, 0);

    private Collider _collider;
    private void Start()
    {
        _collider = GetComponent<Collider>();
        _marker = Instantiate(_marker, transform.position + _offset, transform.rotation, transform);
        //_marker.SetActive(false);
    }
    //private void FixedUpdate()
    //{
    //    Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit hit = new RaycastHit();
    //    Physics.Raycast(mouseRay, out hit);

    //    if (hit.collider == _collider)
    //    {
    //        _marker.SetActive(true);
    //    }
    //    else
    //    {
    //        _marker.SetActive(false);
    //    }
    //}
}
