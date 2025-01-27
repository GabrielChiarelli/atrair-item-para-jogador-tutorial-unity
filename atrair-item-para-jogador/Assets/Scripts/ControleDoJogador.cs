using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDoJogador : MonoBehaviour
{
    [Header("Referências Gerais")]
    private Rigidbody2D oRigidbody2D;

    [Header("Movimentação do Jogador")]
    [SerializeField] private float velocidadeDeMovimento = 4.0f;
    private Vector2 inputDeMovimento = new Vector2(0.0f, 0.0f);
    private Vector2 direcaoDoMovimento = new Vector2(0.0f, 0.0f);

    private void Start()
    {
        oRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReceberInputs();
    }

    private void FixedUpdate()
    {
        MovimentarJogador();
    }

    private void ReceberInputs()
    {
        inputDeMovimento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void MovimentarJogador()
    {
        direcaoDoMovimento = inputDeMovimento.normalized;
        oRigidbody2D.velocity = direcaoDoMovimento * velocidadeDeMovimento;
    }
}
