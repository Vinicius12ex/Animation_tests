using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour {

    float velocidadeAtual;
    public float velocidadeMaxima = 3f;

    public float aceleracaoInicial = 0.02f;
    public float aceleracao = 0.01f;
    public float desaceleracao = 0.07f;

    public float velocidadeRotacao = 130f;

    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //rotacao
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 rotacao = Vector3.up * h * velocidadeRotacao * Time.deltaTime;

        //movimentacao

        float v = Input.GetAxisRaw("Vertical");
        if (v != 0 && velocidadeAtual < velocidadeMaxima)
        {
            velocidadeAtual += (velocidadeAtual == 0f) ? aceleracaoInicial : aceleracao;
        }
        else if (v == 0 && velocidadeAtual > 0)
        {
            velocidadeAtual -= desaceleracao;
        }

        velocidadeAtual = Mathf.Clamp(velocidadeAtual, 0, velocidadeMaxima);

        if (velocidadeAtual > 0)
        {
            transform.Rotate(rotacao); 
        }

        transform.Translate(Vector3.forward * velocidadeAtual * Time.deltaTime);

        float valorAnimacao = Mathf.Clamp(velocidadeAtual / velocidadeMaxima, 0, 1);
        animator.SetFloat("Speed", valorAnimacao);
	}
}
