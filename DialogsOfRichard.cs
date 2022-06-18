using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogsOfRichard : MonoBehaviour
{
    //Tudo novo nessa porra
    public Text canvas_text;
    public Text canvas_first_text;
    public Text canvas_second_text;
    public string fase = "";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Crie os eventos aqui
    /*
     * Cada FIRST + SECOND é uma posição do nó na árvore.
     * Tome cuidado quando o first e o second forem iguais. Pois eles cairão no mesmo evento.
     * Basicamente se for 1 e 1, não importa o que o cara fizer anteriormente, ele vai cair igualmente.
     * Recomendo usar isso para colocar pontos de interseção de historia, exemplo: Você sempre cairá no evento de matar os funcionarios sla
     */
    public void change(string decisao, bool overwrite) {
        Debug.Log(this.fase);
        if(overwrite){
            this.fase = decisao;
        }else{
            this.fase+=decisao;
        }
        if (this.fase == "") {
            canvas_text.text = "Linus! Quanto tempo! Mal te reconheci... Como você tem estado?";
            canvas_first_text.text = "Na verdade, não muito bem...";
            canvas_second_text.text = "(mentir) Estou ótimo! E você? ";
        }
        if (this.fase=="1") {
            canvas_text.text = "Mesmo? Estive preocupado com você... Sumiu de repente por tanto tempo, e ainda aparece assim parecendo que não toma um banho há dias...";
            canvas_first_text.text = "Na verdade, não estou muito bem...";
            canvas_second_text.text = "Loucura... Estou bem! Agora, acho que preciso ir";
        }
        if(this.fase=="0"){
            change("10", true);
        }
         if (this.fase =="11") {
            canvas_text.text = "Linus não consegue dizer o que sente e isso o mantém preso com os próprios pensamentos. Linus volta pra casa, sabendo que amanhã ter    á que enfrentar tudo de novo. Mas quem sabe alguma outra vez... Um dia após o outro, né?";
            canvas_first_text.text = "";
            canvas_second_text.text = "";
        }              
        if (this.fase =="10") {
            canvas_text.text = "Sabia! Meu sentido aranha nunca me engana 😎. Agora, me conta logo o que tá acontecendo contigo. Sei que também sumi um pouco,     mas a vida é assim... O fluxo das coisas faz a gente se afastar sem nem perceber. Ainda somos brothers, né?";
            canvas_first_text.text = "Contar como tem se sentido";
            canvas_second_text.text = "Inventar uma desculpa para escapulir";
        }
        if (this.fase=="101") {
            change("11", true);
        }
        if(this.fase=="100"){
            canvas_text.text = "Meu Deus. Isso é muito pra digerir... Não sou muito bom com essas coisas profundas... Mas não preciso ser bom com isso! Alguma    s pessoas são pagas pra trabalhar com esse tipo de coisa, sabia? Conheço um ótimo psicólogo. Sei que não faz bem o seu estilo, mas acho que você deveria dar uma chance. O que me diz";
            canvas_first_text.text = "Quero dar uma chance";
            canvas_second_text.text = "Não quero fazer isso...";
        }
        if(this.fase=="1001"){
            change("11", true);
        }
        if(this.fase=="1000"){
            canvas_text.text = "Luca apresenta Linus a um profissional. Buscar ajuda é um passo na direção certa, mas também é o começo de um novo desafio para Linus...";
            canvas_first_text.text = "";
            canvas_second_text.text = "";
        }

    }
}
