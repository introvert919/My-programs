#include<iostream>
#include<string>
#include<fstream>
#include "JsonLib.h"

using namespace std;


int main()
{
	string Result;

	// ����� �������� ���������� �����.

	/*Result = parse("Example1.txt", "Name", 2);

	cout << Result << endl;*/


	// ����� ���� ��������. ����������� ���������� �������� ��������� ������.
	/*for (int i = 0; i < 1829; i++)
	{
		Result = parse("Example1.txt", "Name", i);

		cout << Result << endl;
	}*/


	// ����� �������� ���������� ������ � ���������.

	/*for (int i = 0; i <3; i++)
	{
		if( i>=1 && i<=2)
		{
			Result = parse("Example1.txt", "Name", i);

			cout << Result << endl;
		}
	}*/


    //����� ���������� � ���������� ������ ���������� ������.

	/*Result = parse_info("Example1.txt", "Name");

	cout << Result << endl;*/


	return 0;
}