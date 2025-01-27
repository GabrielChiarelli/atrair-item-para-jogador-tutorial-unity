using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IrAteJogador : MonoBehaviour
{
    [Header("Referências Gerais")]
    private GameObject jogador;
    private Vector2 posicaoDoJogador = new Vector2(0.0f, 0.0f);

    [Header("Movimentação do Objeto")]
    [SerializeField] private float velocidadeDeMovimento = 6.0f;
    [SerializeField] private float distanciaParaSeMovimentar = 2.0f;

    private bool estaSeguindoJogador = false;

    private void Start()
    {
        jogador = FindObjectOfType<ControleDoJogador>().gameObject;
    }

    private void Update()
    {
        PegarPosicaoDoJogador();

        if (!estaSeguindoJogador)
        {
            VerificarDistanciaAteJogador();
        }
        else
        {
            MovimentarObjetoAteJogador();
        }
    }

    private void PegarPosicaoDoJogador()
    {
        posicaoDoJogador = jogador.transform.position;
    }

    private void VerificarDistanciaAteJogador()
    {
        if (Vector2.Distance(transform.position, posicaoDoJogador) <= distanciaParaSeMovimentar)
        {
            estaSeguindoJogador = true;
        }
    }

    private void MovimentarObjetoAteJogador()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicaoDoJogador, velocidadeDeMovimento * Time.deltaTime);
    }
}
