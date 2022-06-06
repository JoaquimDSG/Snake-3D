using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    float VelMov = 5;
    float VelDob = 180;
    float VelCuerpo = 5;
    int Brecha = 10;

    public GameObject MyCube;

    private List<GameObject> ParteCuerpo = new List<GameObject>();
    private List<Vector3> HPosicion = new List<Vector3>();

    void Start()
    {
        Crecer();
        Crecer();
        Crecer();
        Crecer();
        Crecer();
    }

    void Update()
    {
        transform.position += transform.forward * VelMov * Time.deltaTime;

        float steerDirection = Input.GetAxis("Horizontal"); 
        transform.Rotate(Vector3.up * steerDirection * VelDob * Time.deltaTime);

        HPosicion.Insert(0, transform.position);

        int i = 0;
        foreach (var body in ParteCuerpo)
        {
            Vector3 point = HPosicion[Mathf.Clamp(i * Brecha, 0, HPosicion.Count - 1)];

            Vector3 Direccion = point - body.transform.position;
            body.transform.position += Direccion * VelCuerpo * Time.deltaTime;

            body.transform.LookAt(point);
            i++;
        }
    }

    private void Crecer()
    {
        GameObject Cuerpo = Instantiate(MyCube);
        ParteCuerpo.Add(Cuerpo);
    }
}
