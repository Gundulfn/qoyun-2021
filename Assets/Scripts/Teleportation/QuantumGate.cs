using UnityEngine;
using UnityEngine.UI;

public class QuantumGate : MonoBehaviour
{
    [SerializeField]
    private Transform player, gate;

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(
            () => 
            {
                UIHandler.instance.OnGadgetUIKeyDown();
                Teleportation.instance.TeleportToLocation(gate.position + Vector3.up, player);
                GameController.instance.StartGame();
            });    
    }
}
