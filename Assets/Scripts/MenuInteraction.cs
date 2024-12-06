using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class MenuInteraction : MonoBehaviour
{
    [SerializeField] private SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand; // Puedes elegir la mano derecha o izquierda
    [SerializeField] private SteamVR_Action_Boolean interactAction;
    [SerializeField] private LineRenderer lineRenderer; // Línea para visualizar el rayo

    private void Start()
    {
        if (lineRenderer == null)
        {
            lineRenderer = GetComponent<LineRenderer>(); // Si no se asignó en el Inspector, se toma el componente LineRenderer de este objeto
        }
    }

    private void Update()
    {
        // Actualiza la posición y dirección del rayo visual
        UpdateRayVisual();

        if (interactAction[inputSource].stateDown) // Si el botón de interacción es presionado
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f)) // El rayo va hacia adelante
            {
                if (hit.collider.CompareTag("MenuButton")) // Verifica si el objeto es un botón de menú
                {
                    hit.collider.GetComponent<Button>().onClick.Invoke(); // Simula el clic del botón
                }
            }
        }
    }

    // Actualiza la visualización del rayo
    private void UpdateRayVisual()
    {
        if (lineRenderer != null)
        {
            lineRenderer.SetPosition(0, transform.position); // El origen del rayo es la posición de la mano
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 10f)) // El rayo va hacia adelante
            {
                lineRenderer.SetPosition(1, hit.point); // La posición final del rayo es donde golpea el objeto
            }
            else
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * 10f); // Si no golpea nada, el rayo se extiende hasta 10 unidades
            }
        }
    }
}