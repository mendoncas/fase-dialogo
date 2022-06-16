using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// using TMPro;
public class DialogueComponent
{
    public string text;
}

public class Question : DialogueComponent
{
    public string text;

    public Answer firstAnswer;

    public Answer secondAnswer;

    public Question(string text, Answer left, Answer right)
    {
        this.firstAnswer = left;
        this.secondAnswer = right;
        this.text = text;
    }

    public Question(string text)
    {
        text = text;
    }
}

public class Answer : DialogueComponent
{
    public DialogueComponent next;

    public Answer(string text, Question next)
    {
        text = text;
        next = next;
    }

    public Answer(string text)
    {
        text = text;
    }
}

public class DisplayText : MonoBehaviour
{
    public Text DialogueText;

    public Answer[] answers;

    public Button firstButton;

    public Button secondButton;

    public Question[] questions;

    [SerializeField] AudioClip[] badMeows;
    [SerializeField] AudioClip[] goodMeows;

    AudioSource audio;

    private string[]
        respostas =
        {
            "Na verdade, não muito bem...",
            "(mentir) Estou ótimo! E você? ",
            "Na verdade, não muito bem...",
            "(insistir) Loucura... Estou bem! Agora, acho que preciso ir",
            "Contar como tem se sentido",
            "Inventar uma desculpa pra escapulir",
            "sim",
            "não"
        };

    private string[] perguntas =
            {
                "Linus! Quanto tempo! Mal te reconheci... Como você tem estado?",
                "Mesmo? Estive preocupado com você... Sumiu de repente por tanto tempo, e ainda aparece assim parecendo que não toma um banho há dias...",
                "Sabia! Meu sentido aranha nunca me engana 😎. Agora, me conta logo o que tá acontecendo contigo. Sei que também sumi um pouco, mas a vida é assim... Ainda somos brothers, né?  ",
                "Meu Deus. Isso é muito pra digerir... Não sou muito bom com essas coisas profundas... Mas não preciso ser bom com isso! Algumas pessoas são pagas pra trabalhar com esse tipo de coisa, sabia? Conheço um ótimo psicólogo. Sei que não faz bem o seu estilo, mas acho que você deveria dar uma chance. O que me diz?",

                // #FRASE SINALIZANDO GOOD ENDING
                "Luca apresenta Linus a um profissional. Buscar ajuda é um passo na direção certa, mas também é o começo de um novo desafio para Linus...",

                // #FRASE SINALIZANDO BAD ENDING
                "Linus não consegue dizer o que sente e isso o mantém preso com os próprios pensamentos. Linus volta pra casa, sabendo que amanhã terá que enfrentar tudo de novo. Mas quem sabe alguma outra vez... Um dia após o outro, né?"
            };

    private DialogueComponent current;

    private bool isDisplaying;

    private int sentenceIndex = 0;

    private int buttonIndex = 0;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        isDisplaying = false;
        DialogueText.text = "";
        firstButton.onClick.AddListener (secondOnClick);
        secondButton.onClick.AddListener (firstOnClick);
    }

    // Update is coalled once per frame
    void Update()
    {
        if (
            Input.GetKeyDown(KeyCode.Space) &&
            isDisplaying == false &&
            sentenceIndex < perguntas.Length
        )
        {
            isDisplaying = true;
            StartCoroutine(displayDialogue(perguntas[sentenceIndex]));
            firstButton.GetComponentInChildren<Text>().text =
                respostas[sentenceIndex];
            secondButton.GetComponentInChildren<Text>().text =
                respostas[sentenceIndex + 1];
            sentenceIndex++;
        }
    }

    private IEnumerator displayDialogue(string phrase)
    {
        stringSplitter (phrase);
        yield return new WaitForSeconds((phrase.Length + 45) * 0.035f);
    }

    private void stringSplitter(string sentence)
    {
        DialogueText.text = "";
        string[] characters = new string[sentence.Length];

        for (int i = 0; i < sentence.Length; i++)
        {
            characters[i] = System.Convert.ToString(sentence[i]);
        }
        StartCoroutine(stringDisplayDelay(characters));
    }

    private IEnumerator stringDisplayDelay(string[] characters)
    {
        for (int i = 0; i < characters.Length; i++)
        {
            DialogueText.text += characters[i];
            yield return new WaitForSeconds(0.025f);
        }
        isDisplaying = false;
    }

    public void firstOnClick()
    {
        Debug.Log("PRIMEIRO BOTÃO CLICADO");
        PlayGoodMeow();
        isDisplaying = true;
        StartCoroutine(displayDialogue(perguntas[sentenceIndex]));
        firstButton.GetComponentInChildren<Text>().text =
            respostas[buttonIndex];
        secondButton.GetComponentInChildren<Text>().text =
            respostas[buttonIndex + 1];
        buttonIndex += 2;
        sentenceIndex++;
    }

    public void secondOnClick()
    {
        Debug.Log("SEGUNDO BOTÃO CLICADO");
        PlayBadMeow();
        // isDisplaying = true;
        // StartCoroutine(displayDialogue(perguntas[sentenceIndex]));
        // firstButton.GetComponentInChildren<Text>().text =
        //     respostas[buttonIndex];
        // secondButton.GetComponentInChildren<Text>().text =
        //     respostas[buttonIndex + 1];
        // buttonIndex += 2;
        // sentenceIndex+=2;
    }
    
    void PlayBadMeow(){
        AudioClip clip = badMeows[UnityEngine.Random.Range(0, badMeows.Length)];
        audio.PlayOneShot(clip);
    }

    void PlayGoodMeow(){
        AudioClip clip = goodMeows[UnityEngine.Random.Range(0, goodMeows.Length)];
        audio.PlayOneShot(clip);
    }
}
