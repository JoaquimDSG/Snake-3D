using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador : MonoBehaviour
{
    float VelMov = 5;
    float VelDob = 180;
    float VelCuerpo = 5;
    int Brecha = 10;
    int puntos = 0;

    public GameObject MyCube;
    public GameObject Manzana;

    private List<GameObject> ParteCuerpo = new List<GameObject>();
    private List<Vector3> HPosicion = new List<Vector3>();

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Crecer();
        }

        SpawnManzana();

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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Manzana")
        {
            Crecer();
            SpawnManzana();
            puntos++;
        }

        else if (col.gameObject.tag == "Pared")
        {
            GameOver();
        }


        if (puntos == 42)
        {
            GG();
        }
    }

    public void GG()
    {
        SceneManager.LoadScene("Victoria");
    }


    public void GameOver()
    {
        SceneManager.LoadScene("PGameOver");
    }

    public void SpawnManzana()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-11, 11), 0.5f, Random.Range(-11, 11));

        var nuevaManzana = Instantiate(Manzana, randomSpawnPosition, Quaternion.identity);
        Destroy(Manzana);
        Manzana = nuevaManzana;
    }
} 

