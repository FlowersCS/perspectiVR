using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] private SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand; // Puedes elegir la mano derecha o izquierda
    [SerializeField] private SteamVR_Action_Boolean interactAction;
    [SerializeField] private LineRenderer lineRenderer; // L�nea para visualizar el rayo

    private void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>(); // Si no se asign� en el Inspector, se toma el componente LineRenderer de este objeto
        }
    }

    private void Update()
    {
        // Actualiza la posici�n y direcci�n del rayo visual
        UpdateRayVisual();

        if (interactAction[inputSource].stateDown) // Si el bot�n de interacci�n es presionado
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f)) // El rayo va hacia adelante
            {
                if (hit.collider.CompareTag("MenuButton")) // Verifica si el objeto es un bot�n de men�
                {
                    hit.collider.GetComponent<Button>().onClick.Invoke(); // Simula el clic del bot�n
                }
            }
        }
    }

    // Actualiza la visualizaci�n del rayo
    private void UpdateRayVisual()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position); // El origen del rayo es la posici�n de la mano
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f)) // El rayo va hacia adelante
            {
                lineRenderer.SetPosition(1, hit.point); // La posici�n final del rayo es donde golpea el objeto
            }
            else
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * 10f); // Si no golpea nada, el rayo se extiende hasta 10 unidades
            }
        }
    }
}