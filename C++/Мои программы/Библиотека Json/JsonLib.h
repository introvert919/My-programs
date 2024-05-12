#pragma once

#include<iostream>
#include<string>
#include<fstream>

using namespace std;
		
// ����� �������� ������ �����.

string parse(string Data, string Key, int Number)
{
	// ���������� � ����� �������, ����� ����� �������� � ���������.
	string Key_iter = "\"" + Key + "\"";

	// ������ �����.
	ifstream DataIn;
	DataIn.open(Data);

	string Line;
	string Data_iter;

	// ������ ���� ����� � ����� � ���� ������.
	while (getline(DataIn, Line))
	{
		Data_iter += Line;
	}

	DataIn.close();

	// ����� ������ � ��������. 

	int Pos = 0; // ������� ��� ������� ���������� ������ � ������.
	int Iter_count = 0; // ������� ���������� ������ ��� ������.
	string Value_iter; // ��������� � ������ ����� ����������� ����� ��������.
	string Value; // ���������.

	while ((Pos = Data_iter.find(Key_iter, Pos)) != string::npos) // ���� ������ ���� � ������.
	{
		string Data_iter1 = Data_iter; // ����� ������ ��� ����������� ������ ���������, ��� ��� Pos ����� substr �� ��������, � ����� �������� �������.

		Value_iter = Data_iter1.substr(Pos + Key_iter.length(), string::npos); // ������� ����.

		Pos += +1; // �������� ������� �� 1 ������ ��� ������ ���������� ����������� �����.

		int Count1 = 0; // ����� ������� ��� ����� �����.
		int Count2 = 0; // ������� ��� �������� � ���� ������.
		int Count3 = 0; // ������� ��� �������� � ���� �������.

		int Pos1 = 0; // �������� ��� substr ��������.
		int Pos2 = 0;

		char Char1 = '"'; // ������� ��� ������ � ������.
		char Char2 = '{';
		char Char3 = '[';
		char Char4 = '}';
		char Char5 = ']';

		string Check1; // ������ ��� �������� ������� �������������� ��������.
		string Check2;

		// ���������� ��������, ������ ��� ������.

		int Pos3 = 0; // �������� ��� ����������� ��������, ������ ��� ������.
		int Pos4 = 0;

		for (int i = 0; i < Value_iter.length(); i++)
		{
			if (Value_iter[i] == Char1) // ���� ������ ������ �������, �� ������.
			{
				Pos3 = 1;
				break;
			}
			if (Value_iter[i] == Char2 || Value_iter[i] == Char3) // ���� ������ ������ ����������� ������, �� ������.
			{
				Pos4 = 1;
				break;
			}
		}


		for (int i = 0; i < Value_iter.length(); i++)
		{
			// �������� � ���� �����.
			if (Pos3 == 1) // ���������� �������� - ������ ��� ������.
			{
				Check1 += Value_iter[i];

				if (Value_iter[i] == Char1)
				{
					Count2 += 1;
					if (Count2 == 1) // ���������� ������� ������ �������.
					{
						Pos1 = Count1;
					}
					if (Count2 > 1)
					{
						if (Check1.find("\\\"") != -1) // ��������� ���� �� � ������ �������������� ������� \".
						{
							Check1.erase();
							Count1 += 1; // Continue ���������� � ������ �����, � �������� �� �������� ����� �� �������, ������� ����� ���������� �����.
							continue;
						}
						else
						{
							Pos2 = Count1; // ���� ��� �������������� ������� ��������, �� ���������� ������� ������ �������.
							break;
						}
					}
				}
			}

			// ������
			if (Pos4 == 1) // ���������� �������� - ������ ��� ������.
			{
				Check2 += Value_iter[i];

				if (Value_iter[i] == Char2 || Value_iter[i] == Char3) // ���� ������ �����������, � �������� ���������� 1.
				{
					Count3 += 1;
					if (Count3 == 1)
					{
						if (Pos1 == 0) // ���������� ������� ������ ������.
						{
							Pos1 = Count1;
						}
					}

					if (Check2.find("\\[") != -1 || Check2.find("\\{") != -1) // ��������� ���� �� �������������� ����������� ������.
					{
						Check2.erase();
						Count3 -= 1;  // ���������� �������������� ���������� ������, ������� �������� 1.
					}
				}

				if (Value_iter[i] == Char4 || Value_iter[i] == Char5) // ���� ������ �����������, �������� � �������� 1.
				{
					Count3 = Count3 - 1;

					if (Check2.find("\\]") != -1 || Check2.find("\\}") != -1) // ��������� ���� �� �������������� ����������� ������.
					{
						Check2.erase();
						Count3 += 1;  // ���������� �������������� ����������� ������, ������� ���������� 1.
					}

					if (Count3 == 0)   // ���� ����� ����������� � ����������� ������ ����� ����, � �������������� �������� ������ ���, 
					{                  // ���������� ������� ��������� ������.
						Pos2 = Count1;
						break;
					}
				}
			}
			Count1 += 1; // ���� ��������, ����������� ������� �� 1.
		}

		Value = Value_iter.substr(Pos1, Pos2 - Pos1 + 1); // ����� ��������� �� ���������.

		Iter_count += 1;
				// ����� ������ ��������.

				if (Iter_count == Number)
				{
					return Value;
				}

				Value.erase();
			}
		}


// ����� ���������� � ���������� ������ ���������� ��������.

string parse_info(string Data, string Key)
{
	// ���������� � ����� �������, ����� ����� �������� � ���������.
	string Key_iter = "\"" + Key + "\"";

	// ������ �����.
	ifstream DataIn;
	DataIn.open(Data);

	int Count4 = 0; // ������� ������� ���������� ��������.
	string Line;
	string Find_key;

	// ���������� � ������ Find_iter ������ ������ �� Line, � ���� � ��� ����. 
	// ���� ���� ������, �� ���� ����� ��������� ���������� ����� ����������� �����.

		while (getline(DataIn, Line))
		{
			for (int i = 0; i < Line.length(); i++)
			{
				Find_key += Line[i];
				if (Find_key.find(Key_iter) != -1)
				{
					Count4 += 1;
					Line.insert(i + 1, " - " + to_string(Count4));
					Find_key.erase();
				}
			}

			cout << Line << endl;
		}
		DataIn.close();

	return 0;
}

