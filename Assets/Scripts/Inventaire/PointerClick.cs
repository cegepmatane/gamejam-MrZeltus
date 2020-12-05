using UnityEngine;
using UnityEngine.EventSystems;

public class PointerClick : MonoBehaviour, IPointerClickHandler
{
   public void OnPointerClick(PointerEventData eventData)
   {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Inventaire.Instance.Selectionner(transform.gameObject.GetComponent<Emplacement>());
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Inventaire.Instance.Jetter(transform.gameObject.GetComponent<Emplacement>());
        }
   }   
}
