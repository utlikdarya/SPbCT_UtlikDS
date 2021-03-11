package com.company;
import java.io.*;
import java.util.Random;

import java.util.Scanner;

public class Main {

    static long ShiftRegister = (long) (Math.random() * (((666 - 169)) + 13) / 13));
    static String opent = "";

    public static void main(String[] args ) throws IOException {
	// write your code here

        FileReader reader = new FileReader("resources\\opent.txt");
        // читаем посимвольно
        int c;
        while((c=reader.read())!=-1)
            opent +=(char)c;

        //записываем в файл начальное значение скремблера
        FileWriter writer = new FileWriter("resources\\key.txt", false);
        writer.write(Long.toString(ShiftRegister));
        writer.flush();


        System.out.println("\n_______________________ENCRYPTING_______________________");
        System.out.printf("Scrambler initial value: %d (%s)\n",ShiftRegister,Long.toBinaryString(ShiftRegister));
        System.out.println("Open text from file: "+opent);
        char[] arr = opent.toCharArray(); //разбиваем строку на массив символов
        int n = arr.length * 8; //вычисляем длину ключа
        //генерируем ключ (гамму)
        String keyBin =Long.toString(ShiftRegister & 0x01);
        for(int i = 0; i <n-1; i++) {
            keyBin+=LFSR();
        }

        //переводим исходный текст в hex и bin системы
        String openHex = "", openBin ="";
        System.out.println("Key(gamma): "+keyBin);
        for (int i = 0; i<arr.length; i++)
        {
            int b = (int)arr[i];
            openHex += String.format("%x ", b);
            if((Integer.toBinaryString(b).length() == 7))
                openBin += "0";
            else if ((Integer.toBinaryString(b).length() == 6))
                openBin += "00";
            openBin += Integer.toBinaryString(b);
        }
        System.out.println("Open text in hex: "+openHex);
        System.out.println("Open text in bin: "+openBin);

        //выполняем операцию xor между гаммой и исходным текстом
        String closeBin = "", closeHex = "";
        for (int i = 0, j = 0; i < keyBin.length(); i++, j++)
            closeBin += (int)keyBin.charAt(i)^(int) openBin.charAt(i);
        System.out.println("Close text in bin: "+closeBin);

        //переводим зашифрованный текст в hex и bin системы
        String[] A = closeBin.split("(?<=\\G.{8})");
        String closet = "";
        for (int i =0 ; i<A.length;i++ )
        {
            closeHex+=String.format("%x ",Integer.parseInt(A[i],2));
            closet += (char)Integer.parseInt(A[i],2);
        }

        System.out.println("Close text in hex: "+closeHex);
        System.out.println("Close text: "+ closet);

        //записываем зашифрованный текст в файл
        writer = new FileWriter("resources\\closet.txt", false);
        writer.write(closet);
        writer.flush();

        System.out.println("\n_______________________DECRYPTING_______________________");
        String openDBin = "";
        //выполняем операцию xor между ключом и зашифрованным текстом
        for (int i = 0, j = 0; i < keyBin.length(); i++, j++)
            openDBin += (int)keyBin.charAt(i)^(int) closeBin.charAt(i);
        System.out.println("Open text in bin after decrypting: "+openDBin);

        //переводим расшифрованный текст в hex и bin системы
        String[] B = openDBin.split("(?<=\\G.{8})");
        String openDt = "", openDHex = "";
        for (int i =0 ; i<B.length;i++ )
        {
            openDHex+=String.format("%x ",Integer.parseInt(B[i],2));
            openDt += (char)Integer.parseInt(B[i],2);
        }
        System.out.println("Open text in hex after decrypting: "+openDHex);
        System.out.println("Open text after decrypting: "+ openDt);


    }

    public static long LFSR ()
    {
        ShiftRegister =
                ((((ShiftRegister >> 5) ^ (ShiftRegister >> 2)) & 0x01) << 8) | (ShiftRegister >> 1);
        return (ShiftRegister & 0x01);
    }
}
