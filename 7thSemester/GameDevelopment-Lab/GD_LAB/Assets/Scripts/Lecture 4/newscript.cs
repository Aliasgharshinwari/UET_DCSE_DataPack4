using UnityEngine;

public class newscript : MonoBehaviour
{
    private void Awake()
    {
        print("Awake" + Time.deltaTime);
    }

    void Start()
    {
        print("Start" + Time.deltaTime);
    }

    void Update()
    {
       // print("Update" + Time.deltaTime);
    }

    private void OnEnable()
    {
        print("Enable" + Time.deltaTime);
    }

    private void OnDisable()
    {
        print("Disable" + Time.deltaTime);
    }

    private void LateUpdate()
    {
       // print("LateUpdate" + Time.deltaTime);
    }

    private void FixedUpdate()
    {
        print("FixedUpdate" + Time.deltaTime);
    }

}
