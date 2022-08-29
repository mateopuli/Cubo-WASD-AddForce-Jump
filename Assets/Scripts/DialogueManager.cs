using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogueUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo;
    [SerializeField] bool hasTalked;

    [SerializeField] string[] frasesDialogo;
    [SerializeField] int posicionFrase;

    [SerializeField] TextMeshProUGUI textoBoton;
    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            frasesDialogo = other.gameObject.GetComponent<NPCBehaviour>().data.dialogueFrases;
            if (!hasTalked)
            {
                textoDelDialogo.text = "Hola forastero!";
                dialogueUI.SetActive(true);
            }
            else
            {
                textoDelDialogo.text = "Ya hablamos";
                textoBoton.text = "Cerrar";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            dialogueUI.SetActive(false);
        }
    }

    public void NextFrase()
    {
        if (posicionFrase < frasesDialogo.Length)
        {
            textoDelDialogo.text = frasesDialogo[posicionFrase];
            posicionFrase++;
            if(posicionFrase == frasesDialogo.Length - 1)
            {
                textoBoton.text = "Cerrar";
            }
        }
        else
        {
            dialogueUI.SetActive(false);
            hasTalked = true;
        }
        
    }
}
