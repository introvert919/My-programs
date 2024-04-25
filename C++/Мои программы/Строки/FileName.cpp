#include<iostream>
#include<string>
#include<thread>
#include<chrono>
#include <windows.h>

#include <stdio.h>
#include <conio.h>
#include <mmsystem.h>
#pragma comment (lib , "winmm.lib")

#include "Data.h"

using namespace std;

/* Программы выдодит на экран слово или словосочетание, которое пользователь
   вводит с клавиатуры, в виде больших букв, составленных их символа '*'.
   Количество символов не ограничено.*/


int main()
{
	//Ввод и вывод символов на русском языке

	setlocale(LC_ALL, "ru");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	
	//Переменные
	string a; 
	int StrLength; // Длинна строки.
	int string_iter_count; // Количество итераций для разделения строки на подстроки.
	int cout_iter_count; // Количество итераций при выводе массивов с символом '*'.
	int n = 0; // Номер символа, начиная с которого строка разбивается на подстроки.
	
	int m = 0;

	// Ввод словосочетания

	cout << "Введите слово или словосочетание (с маленькой буквы)" << endl;
	getline(cin, a);
	std::cout << endl;
	
	StrLength=a.length ();
	
	
	//Воспроизведение звука

	PlaySoundA((LPCSTR)"backsound", NULL, SND_RESOURCE | SND_ASYNC);
	this_thread::sleep_for(chrono::milliseconds(800));

	//Перенос слов, по 10 символов, включая пробелы

	if (StrLength <= 10)
	{
		string_iter_count = 1;
		m = 20000 / 10;
	}
	else 
	{
		string_iter_count = (StrLength / 10)+1;
		m = (20000 / 10) / string_iter_count;
	}

	/* Строка разбивается на подстроки по 10 символов,
	   подстрока переводится в массив char, каждому символу
	   соответствует 9 массивов с символами '*'. Они
	   выводятся на экран циклом for. */

	for (int i = 0; i < string_iter_count; i++)
	{
		string b = a.substr(n, 10);
		char* str = const_cast <char*> (b.c_str());
		cout_iter_count = b.length();
		n = n + 10;

	    //Первая линия
        std::cout << Tab;
        for (int i = 0; i < cout_iter_count; i++)
    		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A1;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B1;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V1;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G1;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D1;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E1;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE1;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J1;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z1;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I1;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II1;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K1;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L1;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M1;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N1;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O1;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P1;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R1;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S1;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T1;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U1;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F1;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H1;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS1;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH1;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH1;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH1;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn1;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III1;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn1;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE1;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU1;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA1;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Вторая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A2;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B2;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V2;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G2;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D2;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E2;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE2;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J2;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z2;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I2;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II2;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K2;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L2;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M2;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N2;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O2;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P2;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R2;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S2;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T2;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U2;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F2;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H2;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS2;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH2;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH2;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH2;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn2;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III2;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn2;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE2;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU2;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA2;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Третья линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A3;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B3;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V3;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G3;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D3;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E3;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE3;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J3;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z3;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I3;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II3;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K3;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L3;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M3;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N3;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O3;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P3;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R3;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S3;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T3;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U3;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F3;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H3;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS3;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH3;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH3;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH3;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn3;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III3;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn3;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE3;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU3;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA3;
			std::cout << Tab;
			break;
			}
			}
		}
		
		this_thread::sleep_for(chrono::milliseconds(m));

		//Четвертая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A4;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B4;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V4;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G4;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D4;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E4;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE4;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J4;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z4;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I4;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II4;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K4;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L4;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M4;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N4;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O4;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P4;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R4;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S4;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T4;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U4;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F4;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H4;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS4;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH4;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH4;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH4;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn4;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III4;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn4;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE4;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU4;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA4;
			std::cout << Tab;
			break;
			}
			}
		}
		
		this_thread::sleep_for(chrono::milliseconds(m));

		//Пятая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A5;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B5;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V5;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G5;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D5;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E5;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE5;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J5;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z5;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I5;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II5;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K5;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L5;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M5;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N5;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O5;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P5;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R5;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S5;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T5;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U5;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F5;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H5;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS5;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH5;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH5;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH5;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn5;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III5;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn5;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE5;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU5;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA5;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Шестая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A6;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B6;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V6;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G6;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D6;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E6;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE6;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J6;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z6;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I6;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II6;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K6;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L6;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M6;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N6;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O6;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P6;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R6;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S6;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T6;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U6;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F6;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H6;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS6;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH6;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH6;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH6;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn6;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III6;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn6;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE6;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU6;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA6;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Седьмая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A7;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B7;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V7;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G7;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D7;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E7;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE7;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J7;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z7;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I7;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II7;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K7;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L7;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M7;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N7;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O7;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P7;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R7;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S7;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T7;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U7;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F7;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H7;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS7;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH7;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH7;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH7;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn7;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III7;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn7;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE7;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU7;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA7;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Восьмая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A8;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B8;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V8;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G8;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D8;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E8;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE8;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J8;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z8;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I8;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II8;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K8;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L8;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M8;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N8;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O8;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P8;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R8;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S8;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T8;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U8;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F8;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H8;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS8;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH8;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH8;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH8;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn8;
			std::cout << Tab;
			break;
			}
			case 'ы':
			{std::cout << III8;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn8;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE8;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU8;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA8;
			std::cout << Tab;
			break;
			}
			}
		}

		this_thread::sleep_for(chrono::milliseconds(m));

		//Девятая линия
		std::cout << endl;
		std::cout << Tab;
		for (int i = 0; i < cout_iter_count; i++)
		{
			switch (str[i])
			{
			case ' ':
			{std::cout << Tab;
			break;
			}
			case 'а':
			{std::cout << A9;
			std::cout << Tab;
			break;
			}
			case 'б':
			{std::cout << B9;
			std::cout << Tab;
			break;
			}
			case 'в':
			{std::cout << V9;
			std::cout << Tab;
			break;
			}
			case 'г':
			{std::cout << G9;
			std::cout << Tab;
			break;
			}
			case 'д':
			{std::cout << D9;
			std::cout << Tab;
			break;
			}
			case 'е':
			{std::cout << E9;
			std::cout << Tab;
			break;
			}
			case 'ё':
			{std::cout << EE9;
			std::cout << Tab;
			break;
			}
			case 'ж':
			{std::cout << J9;
			std::cout << Tab;
			break;
			}
			case 'з':
			{std::cout << Z9;
			std::cout << Tab;
			break;
			}
			case 'и':
			{std::cout << I9;
			std::cout << Tab;
			break;
			}
			case 'й':
			{std::cout << II9;
			std::cout << Tab;
			break;
			}
			case 'к':
			{std::cout << K9;
			std::cout << Tab;
			break;
			}
			case 'л':
			{std::cout << L9;
			std::cout << Tab;
			break;
			}
			case 'м':
			{std::cout << M9;
			std::cout << Tab;
			break;
			}
			case 'н':
			{std::cout << N9;
			std::cout << Tab;
			break;
			}
			case 'о':
			{std::cout << O9;
			std::cout << Tab;
			break;
			}
			case 'п':
			{std::cout << P9;
			std::cout << Tab;
			break;
			}
			case 'р':
			{std::cout << R9;
			std::cout << Tab;
			break;
			}
			case 'с':
			{std::cout << S9;
			std::cout << Tab;
			break;
			}
			case 'т':
			{std::cout << T9;
			std::cout << Tab;
			break;
			}
			case 'у':
			{std::cout << U9;
			std::cout << Tab;
			break;
			}
			case 'ф':
			{std::cout << F9;
			std::cout << Tab;
			break;
			}
			case 'х':
			{std::cout << H9;
			std::cout << Tab;
			break;
			}
			case 'ц':
			{std::cout << TS9;
			std::cout << Tab;
			break;
			}
			case 'ч':
			{std::cout << CH9;
			std::cout << Tab;
			break;
			}
			case 'ш':
			{std::cout << SH9;
			std::cout << Tab;
			break;
			}
			case 'щ':
			{std::cout << SCH9;
			std::cout << Tab;
			break;
			}
			case 'ъ':
			{std::cout << TZn9;
			std::cout << Tab; break;
			}
			case 'ы':
			{std::cout << III9;
			std::cout << Tab;
			break;
			}
			case 'ь':
			{std::cout << MZn9;
			std::cout << Tab;
			break;
			}
			case 'э':
			{std::cout << IIE9;
			std::cout << Tab;
			break;
			}
			case 'ю':
			{std::cout << IIU9;
			std::cout << Tab;
			break;
			}
			case 'я':
			{std::cout << IIA9;
			std::cout << Tab;
			break;
			}
			}
		}
		
		this_thread::sleep_for(chrono::milliseconds(m));
		std::cout << endl << endl << endl;
	}
    	this_thread::sleep_for(chrono::milliseconds(1600));
		std::cout << endl;
		system("pause");
		return 0;

		
}
	
