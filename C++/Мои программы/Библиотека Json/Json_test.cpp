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
	/*for (int i = 0; i < 3; i++)
	{
		Result = parse("Example1.txt", "Name", i+1);

		cout << Result << endl;
	}*/


	// ����� �������� ���������� ������ � ���������.

	/*for (int i = 0; i <3; i++)
	{
		if( i+1>=2 && i+1<=3)
		{
			Result = parse("Example1.txt", "Name", i+1);

			cout << Result << endl;
		}
	}*/


	// ����� ���������� � ���������� ������ ���������� ������.

	/*Result = parse_info("Example1.txt", "Name");

	cout << Result << endl;*/


	return 0;
}