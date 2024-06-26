#pragma once

#include<iostream>
#include<string>
#include<fstream>

using namespace std;
		
// Вывод значения ключа.

string parse(string Data, string Key, int Number)
{
	// Добавление к ключу кавычек, поиск ключа проходит с кавычками.
	string Key_iter = "\"" + Key + "\"";

	// Чтение файла.
	ifstream DataIn;
	DataIn.open(Data);

	string Line;
	string Data_iter;

	// Запись всех строк в файле в одну строку.
	while (getline(DataIn, Line))
	{
		Data_iter += Line;
	}

	DataIn.close();

	// Поиск ключей и значений. 

	int Pos = 0; // Счетчик для позиции одинаковых ключей в строке.
	int Iter_count = 0; // Счетчик одинаковых ключей для вывода.
	string Value_iter; // Подстрока в коорой будет происходить поиск значения.
	string Value; // Результат.

	while ((Pos = Data_iter.find(Key_iter, Pos)) != string::npos) // Ищем первый ключ в строке.
	{
		string Data_iter1 = Data_iter; // Нужно каждый раз присваивать строку полностью, так как Pos после substr не меняется, и будет смещение позиции.

		Value_iter = Data_iter1.substr(Pos + Key_iter.length(), string::npos); // Убираем ключ.

		Pos += +1; // Сдвигаем позицию на 1 символ для поиска следующего одинакового ключа.

		int Count1 = 0; // Общий счетчик для всего цикла.
		int Count2 = 0; // Счеткик для значения в виде строки.
		int Count3 = 0; // Счетчик для значения в виде объекта.

		int Pos1 = 0; // Счетчики для substr значения.
		int Pos2 = 0;

		char Char1 = '"'; // Символы для поиска в строке.
		char Char2 = '{';
		char Char3 = '[';
		char Char4 = '}';
		char Char5 = ']';

		string Check1; // Строки для проверки наличия экранированных символов.
		string Check2;

		// Определяем значение, строка или объект.

		int Pos3 = 0; // Счетчики для обозначения значения, строка или объект.
		int Pos4 = 0;

		for (int i = 0; i < Value_iter.length(); i++)
		{
			if (Value_iter[i] == Char1) // Если первый символ кавычки, то строка.
			{
				Pos3 = 1;
				break;
			}
			if (Value_iter[i] == Char2 || Value_iter[i] == Char3) // Если первый символ открывающая скобка, то объект.
			{
				Pos4 = 1;
				break;
			}
		}


		for (int i = 0; i < Value_iter.length(); i++)
		{
			// Значение в виде сроки.
			if (Pos3 == 1) // Определяем значение - строка или объект.
			{
				Check1 += Value_iter[i];

				if (Value_iter[i] == Char1)
				{
					Count2 += 1;
					if (Count2 == 1) // Записываем позицию первой кавычки.
					{
						Pos1 = Count1;
					}
					if (Count2 > 1)
					{
						if (Check1.find("\\\"") != -1) // Проверяем есть ли в строке экранированные кавычки \".
						{
							Check1.erase();
							Count1 += 1; // Continue возвращает в начало цикла, и итерация до счетчика внизу не доходит, поэтому нужно обозначить здесь.
							continue;
						}
						else
						{
							Pos2 = Count1; // Если все экранированные символы пройдены, то записываем позицию второй кавычки.
							break;
						}
					}
				}
			}

			// Объект
			if (Pos4 == 1) // Определяем значение - строка или объект.
			{
				Check2 += Value_iter[i];

				if (Value_iter[i] == Char2 || Value_iter[i] == Char3) // Если скобка открывающая, к счетчику прибавляем 1.
				{
					Count3 += 1;
					if (Count3 == 1)
					{
						if (Pos1 == 0) // Записываем позицию первой скобки.
						{
							Pos1 = Count1;
						}
					}

					if (Check2.find("\\[") != -1 || Check2.find("\\{") != -1) // Проверяем есть ли экранированные открывающие скобки.
					{
						Check2.erase();
						Count3 -= 1;  // Пропускаем экранированную окрывающую скобку, поэтому отнимаем 1.
					}
				}

				if (Value_iter[i] == Char4 || Value_iter[i] == Char5) // Если скобка закрывающая, отнимаем у счетчика 1.
				{
					Count3 = Count3 - 1;

					if (Check2.find("\\]") != -1 || Check2.find("\\}") != -1) // Проверяем есть ли экранированные закрывающие скобки.
					{
						Check2.erase();
						Count3 += 1;  // Пропускаем экранированную закрывающую скобку, поэтому возвращаем 1.
					}

					if (Count3 == 0)   // Если число откпывающих и закрывающих скобок равно нулю, и экранированных символов больше нет, 
					{                  // записываем позицию последней скобки.
						Pos2 = Count1;
						break;
					}
				}
			}
			Count1 += 1; // Цикл закончен, увеличиваем счетчик на 1.
		}

		Value = Value_iter.substr(Pos1, Pos2 - Pos1 + 1); // Берем подстроку со значением.
		
				// Вывод одного значения.

				if (Iter_count == Number)
				{
					return Value;
				}
		
		                Iter_count += 1;

				Value.erase();
			}
		}


// Вывод информации о порядковом номере одинаковых значений.

string parse_info(string Data, string Key)
{
	// Добавление к ключу кавычек, поиск ключа проходит с кавычками.
	string Key_iter = "\"" + Key + "\"";

	// Чтение файла.
	ifstream DataIn;
	DataIn.open(Data);

	int Count4 = 0; // Счетчик номеров одинаковых значений.
	string Line;
	string Find_key;

	// Записываем в строку Find_iter каждый символ из Line, и ищем в ней ключ. 
	// Если ключ найден, на этом месте вставляем порядковый номер одинакового ключа.

		while (getline(DataIn, Line))
		{
			for (int i = 0; i < Line.length(); i++)
			{
				Find_key += Line[i];
				if (Find_key.find(Key_iter) != -1)
				{
					Line.insert(i + 1, " - " + to_string(Count4));
					Find_key.erase();
					Count4 += 1;
				}
			}

			cout << Line << endl;
		}
		DataIn.close();

	return 0;
}

