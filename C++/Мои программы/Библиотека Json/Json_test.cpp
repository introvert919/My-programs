#include<iostream>
#include<string>
#include<fstream>
#include "JsonLib.h"

using namespace std;


int main()
{
	string Result;

	// Вывод значения указанного ключа.

	/*Result = parse("Example1.txt", "Name", 2);

	cout << Result << endl;*/


	// Вывод всех значений. Поочередное присвоение значений указанной строке.
	/*for (int i = 0; i < 3; i++)
	{
		Result = parse("Example1.txt", "Name", i+1);

		cout << Result << endl;
	}*/


	// Вывод значений одинаковых ключей в диапазоне.

	/*for (int i = 0; i <3; i++)
	{
		if( i+1>=2 && i+1<=3)
		{
			Result = parse("Example1.txt", "Name", i+1);

			cout << Result << endl;
		}
	}*/


	// Вывод информации о порядковом номере одинаковых ключей.

	/*Result = parse_info("Example1.txt", "Name");

	cout << Result << endl;*/


	return 0;
}