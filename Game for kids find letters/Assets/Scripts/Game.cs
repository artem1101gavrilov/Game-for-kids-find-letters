using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

    string Alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"; //тут 33 буквы
    int[] ArrayPovtor; 

    int NumberZagadka;

    public GameObject LeftLet;

    public Camera MainCamera;

    public UnityEngine.UI.Text Zadanie;

    public AudioClip [] impact;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        //Меняем цвет фона
        MainCamera.backgroundColor = new Color((float)Random.Range(0,256)/256.0f, (float)Random.Range(0, 256) / 256.0f, (float)Random.Range(0, 256) / 256.0f);

        ArrayPovtor = new int[Alphabet.Length];
        for (int i = 0; i < Alphabet.Length; i++) ArrayPovtor[i] = 0;

        //Какая буква будет загадана
        //NumberZagadka = Random.Range(0, Alphabet.Length);
        NumberZagadka = Random.Range(0, 3);
        audioSource.PlayOneShot(impact[NumberZagadka], 1F);
        //Выводим задание на экран
        Zadanie.text = Alphabet[NumberZagadka].ToString();
        ArrayPovtor[NumberZagadka]++;

        //Пишем РАндомную букву в любой квадрат
        int RandomPosition = Random.Range(0, 10);
        LeftLet.transform.GetChild(RandomPosition).transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Zadanie.text;
        LeftLet.transform.GetChild(RandomPosition).GetComponent<MoveBox>().IsZadanie = true;

        for (int i = 0; i < LeftLet.transform.childCount; i++)
        {
            while(LeftLet.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text == "")
            {
                int rand = Random.Range(0, Alphabet.Length);
                if(ArrayPovtor[rand] == 0)
                {
                    ArrayPovtor[rand]++;
                    LeftLet.transform.GetChild(i).transform.GetChild(0).transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = Alphabet[rand].ToString();
                }
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
