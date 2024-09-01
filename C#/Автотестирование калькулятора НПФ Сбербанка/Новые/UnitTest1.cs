using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using System.Drawing;
using System.Configuration;

namespace UnitTestProject2
{
    [TestFixture]
    public class UnitTests
    {

        IWebDriver driver;

        [OneTimeSetUp]

        //Открываем страницу
        public void Open_url()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://npfsberbanka.ru/pds");
            driver.Manage().Window.Maximize();
        }

        //Закрываем страницу
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        // Обновляем страницу
        [TearDown]
        public void TearDown1()
        {
            driver.Navigate().Refresh();
        }


        // Поле "Калькулятор долгосрочных сбережений".
        // Тест: поле "Калькулятор долгосрочных сбережений". Тест-кейс: текст поля.

        [Test]
        
        public void Title1_text()
        {
            var Title1 = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/h2"));
            string Actual = Title1.Text;
            string Expected = "Калькулятор долгосрочных сбережений";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Поле "Укажите данные".
        // Тест: поле "Укажите данные". Тест-кейс: текст поля.
        [Test]
        
        public void Title2_text()
        {
            var Title2 = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/p"));
            string Actual = Title2.Text;
            string Expected = "УКАЖИТЕ ДАННЫЕ";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Поле " Ваш официальный доход".
        // Тест: поле "Ваш официальный доход", Тест-кейс: текст поля.

        [Test]
        
        public void Offitial_income_text()
        {
            var Оfficial_income = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/label"));
            string Actual = Оfficial_income.Text;
            string Expected = "Ваш официальный доход";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Ваш официальный доход". Тест - кейс: переключение элементов списка.

        // Значение "от 80 000".
        [TestCase("до 80 000 ₽", "3 166 548 ₽", 0,                                  // string Expected, string Expected_result, int Key_count
            "//*[@id=\"Ваш официальный доход\"]",                                   // string XPath_str
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")] // string XPath_str2
        // Значение "от 80 000 до 150 000".
        [TestCase("от 80 000 до 150 000 ₽", "2 594 748 ₽", 1, 
            "//*[@id=\"Ваш официальный доход\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")]
        // Значение "от 150 000".
        [TestCase("от 150 000 ₽", "2 308 848 ₽", 2, 
            "//*[@id=\"Ваш официальный доход\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")] 
        
        public void Offitial_income_value(string Expected, string Expected_result, int Key_count, 
                                          string XPath_str, string XPath_str2)
        {
            // Значение поля.
            var Оfficial_income = driver.FindElement(By.XPath(XPath_str));

            Оfficial_income.SendKeys(Keys.Enter);
            for (int i = 0; i < Key_count; i++) { Оfficial_income.SendKeys(Keys.Down); }
            Оfficial_income.SendKeys(Keys.Enter);

            var Оfficial_income_text = driver.FindElement(By.XPath(XPath_str2));
            string Actual = Оfficial_income_text.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));

            // Значение рассчета.
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button")); // Одна кнопка для всех тестов.
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]")); // Значения в одном и том же поле во всех тестах.
            string Actual_result = Result.Text;
            ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));
        }

        // Поле "Сумма взносов в Программу в месяц"
        // Тест: поле "Сумма взносов в Программу в месяц". Тест-кейс: текст поля.

        [Test]
        
        public void Contributions_text()
        {
            var Contributions_value = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/div/div/div/label"));
            string Actual = Contributions_value.Text;
            string Expected = "Сумма взносов в Программу в месяц";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Сумма взносов в Программу в месяц", тест-кейс: ввод данных.

        // Позитивный, минимум "1".
        [TestCase("1 ₽", "55 519 ₽", "1",                     // string Expected, string Expected_result, string Key_str
            "//*[@id=\"Сумма взносов в Программу в месяц\"]", // string XPath_str
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")]         // string XPath_str_result
        // Позитивный, максимум "9 999 999".
        [TestCase("9 999 999 ₽", "7 876 118 945 ₽", "9999999", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")] 
        // Негативный, ноль.
        [TestCase("", "Укажите сумму взносов за год", "0", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 
        // Негативный, знак "-".
        [TestCase("", "Укажите сумму взносов за год", "-", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 
        // Негативный, максимум, 10 000 000.
        [TestCase("1 000 000 ₽", "788 895 909 ₽", "10000000", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")] 
        // Негативный, русские буквы, нижний регистр.
        [TestCase("", "Укажите сумму взносов за год", "д", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 
        // Негативный, русские буквы вехний регистр.
        [TestCase("", "Укажите сумму взносов за год", "Д", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 
        // Негативный, английские буквы нижний регистр.
        [TestCase("", "Укажите сумму взносов за год", "d", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")]
        // Негативный, английские буквы верхний регистр.
        [TestCase("", "Укажите сумму взносов за год", "D", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 
        // Негативный, специальные символы.
        [TestCase("", "Укажите сумму взносов за год", "!", 
            "//*[@id=\"Сумма взносов в Программу в месяц\"]",      
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/p")] 

        public void Contributions_value(string Expected, string Expected_result, string Key_str, 
                                        string XPath_str, string XPath_str_result)
        {
            // Значения поля
            var Contributions_number = driver.FindElement(By.XPath(XPath_str));
            Contributions_number.Click();
            Contributions_number.SendKeys(Keys.Backspace);
            Contributions_number.SendKeys(Key_str);
            string Actual = Contributions_number.GetAttribute("value");
            ClassicAssert.That(Actual, Is.EqualTo(Expected));

            // Значение рассчета.
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button")); // Одна кнопка для всех тестов.
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath(XPath_str_result));     // Если значение в поле есть проверяем расчет,
            string Actual_result = Result.Text;                              // если нет, то должно появиться сообщение об ошибке 
            ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));  // "Укажите сумму взносов за год".
        }

        // Поле "Перевод накоплений ОПС в Программу".
        // Тест: поле "Перевод накоплений ОПС в Программу". Тест-кейс: текст поля.

        [Test]
        public void Transaction_text()
        {
            var Transaction_value = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/div/div/div/label"));
            string Actual = Transaction_value.Text;
            string Expected = "Перевод накоплений ОПС в Программу";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Перевод накоплений ОПС в Программу", тест-кейс: ввод данных.

        // Позитивный, минимум "1".
        [TestCase("1 ₽", "3 112 279 ₽", "1",                   // string Expected, string Expected_result, string Key_str
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", // XPath_str
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")]          // XPath_str_result
        // Позитивный, максимум "9 999 999".
        [TestCase("9 999 999 ₽", "57 386 595 ₽", "9999999", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")]
        // Негативный, ноль.
        [TestCase("", "Укажите перевод накоплений", "0", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, знак "-".
        [TestCase("", "Укажите перевод накоплений", "-", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, максимум, 10 000 000.
        [TestCase("1 000 000 ₽", "8 539 706 ₽", "10000000", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/div/div[1]/p[2]")]
        // Негативный, русские буквы, нижний регистр.
        [TestCase("", "Укажите перевод накоплений", "д", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, русские буквы вехний регистр.
        [TestCase("", "Укажите перевод накоплений", "Д", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, английские буквы нижний регистр.
        [TestCase("", "Укажите перевод накоплений", "d", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, английские буквы верхний регистр.
        [TestCase("", "Укажите перевод накоплений", "D", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")]
        // Негативный, специальные символы.
        [TestCase("", "Укажите перевод накоплений", "!", 
            "//*[@id=\"Перевод накоплений ОПС в Программу\"]", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/p")] 

        public void Transactions_value (string Expected, string Expected_result, string Key_str,
                                        string XPath_str, string XPath_str_result)
        {
            // Значение поля.
            var Transactions_number = driver.FindElement(By.XPath(XPath_str));
            Transactions_number.Click();
            Transactions_number.SendKeys(Keys.Backspace);
            Transactions_number.SendKeys(Key_str);
            string Actual = Transactions_number.GetAttribute("value");
            ClassicAssert.That(Actual, Is.EqualTo(Expected));

            // Значение рассчета.
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button")); // Одна кнопка для всех тестов.
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath(XPath_str_result));     // Если значение в поле есть проверяем расчет,
            string Actual_result = Result.Text;                              // если нет, то должно появиться сообщение об ошибке 
            ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));  // "Укажите перевод накоплений".
        }

        // Поле чекбокс.
        // Тест: чекбокс. Тест кейс: текст.

        [Test]

        public void Check_box_text()
        {
            var Check_box = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[2]/label/span[2]"));
            string Actual = Check_box.Text;
            string Expected = "Учитывать накопления ОПС";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: чекбокс. Тест-кейс: вкючение и выключение чекбокса,
        // и одновременно выключение поля для ввода "Перевод накоплений ОПС в Программу".

        [Test]

        public void Check_box_value()
        {
            // Выключение

            var Check_box = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[2]/label/span[1]/input"));
            Check_box.SendKeys(Keys.Space);
            bool Checkbox_off = Check_box.Selected;
            ClassicAssert.That(Checkbox_off, Is.False);

            var Transactions = driver.FindElement(By.XPath("//*[@id=\"Перевод накоплений ОПС в Программу\"]"));
            bool Transactions_off = Transactions.Enabled;
            ClassicAssert.That(Transactions_off, Is.False);

            // Включение (Значение рассчета не нужно, проверяется вместе с предыдущими тестами).

            Check_box.SendKeys(Keys.Space);
            Checkbox_off = Check_box.Selected;
            ClassicAssert.That(Checkbox_off, Is.True);

            Transactions_off = Transactions.Enabled;
            ClassicAssert.That(Transactions_off, Is.True);

            // Значение рассчета при выключенной кнопке.
            Check_box.SendKeys(Keys.Space);
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
            string Actual_result = Result.Text;
            ClassicAssert.That(Actual_result, Is.EqualTo("3 112 274 ₽"));
        }

        // Поле "Налоговый вычет".
        // Тест: поле "Налоговый вычет". Тест-кейс: текст.

        [Test]

        public void Tax_deduction_text()
        {
            var Tax_deduction = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/label"));
            string Actual = Tax_deduction.Text;
            string Expected = "Налоговый вычет";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Налоговый вычет". Тест - кейс: переключение элементов списка.

        // Первый элемент списка.
        [TestCase("Не вкладывать в Программу", "3 166 548 ₽", 0,                    // string Expected, string Expected_result, int Key_count
            "//*[@id=\"Налоговый вычет\"]",                                         // string XPath_str.
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/div/div/span[2]")] // string XPath_str2
        // Второй элемент списка.
        [TestCase("Вкладывать в Программу", "3 591 713 ₽", 1, 
            "//*[@id=\"Налоговый вычет\"]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/div/div/span[2]")] 
       
        public void Tax_deduction_value(string Expected, string Expected_result, int Key_count, string XPath_str, string XPath_str2)
        {
            // Значение поля.
            var Tax_deduction = driver.FindElement(By.XPath(XPath_str));
            Tax_deduction.SendKeys(Keys.Enter);
            for (int i = 0; i < Key_count; i++) { Tax_deduction.SendKeys(Keys.Down); }
            Tax_deduction.SendKeys(Keys.Enter);

            var Tax_deduction_off = driver.FindElement(By.XPath(XPath_str2));
            string Actual = Tax_deduction_off.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));

            // Значение рассчета.
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button")); // Одна кнопка для всех тестов.
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]")); // Значения в одном и том же поле во всех тестах.    
            string Actual_result = Result.Text;                             
            ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));  
        }

        // Поле "Пол".
        // Тест: переключатель "Пол". Тест-кейс: текст кнопок.

        // Кнопка "М".
        [TestCase("М",                                                                       // string Expected
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[1]/span[2]")]  // string XPath_str
        // Кнопка "Ж".
        [TestCase("Ж", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[2]/span[2]")]
        
        public void Gender_switch_text(string Expected, string XPath_str)
        {
            // Текст кнопки "М".

            var Gender_switch_text1 = driver.FindElement(By.XPath(XPath_str));
            string Actual = Gender_switch_text1.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));

            // Текст кнопки "Ж".

            var Gender_switch_text2 = driver.FindElement(By.XPath(XPath_str));
            Actual = Gender_switch_text2.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: переключатель "Пол". Тест-кейс: переключение кнопок.

        [Test]
        
        public void Gender_switch_value()
        {
            // Кнопка "М" включена, кнопка "Ж" выключена. (Значение рассчета проверяется вместе с предыдущими тестами).

            var Male_switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[1]/span[1]/input"));
            bool Male_switch_off = Male_switch.Selected;
            ClassicAssert.That(Male_switch_off, Is.True);
            var Female_switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[2]/span[1]/input"));
            bool Female_switch_on = Female_switch.Selected;
            ClassicAssert.That(Female_switch_on, Is.False);

            // Переключаем кнопку

            var Switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[2]"));
            Switch.Click();

            // Кнопка "М" выключена, кнопка "Ж" включена.

            Male_switch_off = Male_switch.Selected;
            ClassicAssert.That(Male_switch_off, Is.False);
            Female_switch_on = Female_switch.Selected;
            ClassicAssert.That(Female_switch_on, Is.True);

            // Значение рассчета 
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
            Calculate.SendKeys(Keys.Enter);
            var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
            string Actual_result = Result.Text;
            ClassicAssert.That(Actual_result, Is.EqualTo("2 130 083 ₽"));
        }

        // Поле "Ваш возраст".
        // Тест: поле "Ваш возраст". Тест-кейс: текст поля.

        // Текст "Ваш возраст".
        [TestCase("Ваш возраст",                                                     // string Expected
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/label")]  // string XPath_str
        // Текст "18 лет".
        [TestCase("18 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[2]/span[1]")]
        // Текст "80 лет".
        [TestCase("80 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[2]/span[2]")] 
        
        public void Age_switch_text(string Expected, string XPath_str)
        {
            var Age_switch_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Age_switch_text.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Ваш возраст". Тест-кейс: переключение кнопки.

        // Позитивный, минимум.
        [TestCase("18", "Left", 17,                                                             // string Expected, string Direction, int Key_count
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] // string XPath_str
        // Позитивный, максимум.
        [TestCase("80", "Right", 45, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")]
        // Негативный, минимум.
        [TestCase("18", "Left", 18, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")]
        // Негативный, максимум.
        [TestCase("80", "Right", 46, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] 
        
        public void Age_switch_value(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Age_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Left);}
                Actual = Age_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("10 962 465 ₽"));
            }
            if (Direction == "Right")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Right);}
                Actual = Age_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("284 503 ₽"));
            }
        }

        // Поле "Возраст начала получения выплат".
        // Тест: поле "Возраст начала получения выплат". Тест-кейс текст поля.

        // Текст "Возраст начала получения выплат".
        [TestCase("Возраст начала получения выплат",                         // string Expected
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/label")] // string XPath_str
        // Текст "50 лет".
        [TestCase("50 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[2]/span[1]")]
        // Текст "90 лет".
        [TestCase("90 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[2]/span[2]")] 
        
        public void Start_payment_switch_text(string Expected, string XPath_str)
        {
            var Start_payment_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Start_payment_text.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }


        // Тест: поле "Возраст начала получения выплат". Тест-кейс переключение кнопки.

        // Позитивный, минимум.
        [TestCase("50", "Left", 10,                                                      // string Expected, string Direction, int Key_count
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // string XPath_str
        // Позитивный, максимум.
        [TestCase("90", "Right", 30, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]
        // Негативный, минимум.
        [TestCase("50", "Left", 11, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]
        // Негативный, максимум.
        [TestCase("90", "Right", 31, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] 
       
        public void Start_payment_switch_value(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Start_payment_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) {Start_payment_switch.SendKeys(Keys.Left);}
                Actual = Start_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("1 391 098 ₽"));
            }
            if (Direction == "Right")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) {Start_payment_switch.SendKeys(Keys.Right);}
                Actual = Start_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("27 044 734 ₽"));
            }
        }

        // Поле "Ваш возраст" и "Возраст начала получения выплат".
        // Тест: соотношение переключателя "Ваш возраст" и "Возраст начала получения выплат". Тест-кейс: переключатели.
        // Негативные тесты не требуются, так как выход за границы поля проверяются в тестах "Ваш возраст" и "Возраст начала получения выплат".

        // Позитивный, 18 лет.
        [TestCase("33", "10 962 465 ₽", "Left",  17,                                           // string Expected, string Expected_result, string Direction, int Key_count
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]", // string XPath_str
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]       // string XPath_str2
        // Позитивный, 45 лет.
        [TestCase("60", "1 391 098 ₽", "Right", 10, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]
        // Позитивный, 57 лет.
        [TestCase("60", "208 764 ₽", "Right", 22, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]
        // Позитивный, 58 лет.
        [TestCase("62", "284 503 ₽", "Right", 23, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")]
        // Позитивный, 80 лет.
        [TestCase("84", "284 503 ₽", "Right", 45, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] 
        
        public void Age_and_start_payment(string Expected, string Expected_result, string Direction, int Key_count,
                                          string XPath_str, string XPath_str2)
        {
            var Age_switch = driver.FindElement(By.XPath(XPath_str));
            var Start_payment_switch = driver.FindElement(By.XPath(XPath_str2));
            string Actual;
            if (Direction == "Left")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Left); }
                Actual = Start_payment_switch.GetDomAttribute("aria-valuemin");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета.
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));
            }
            if (Direction == "Right")
            {
                //Значение поля.
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Right); }
                Actual = Start_payment_switch.GetDomAttribute("aria-valuemin");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета.
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo(Expected_result));
            }
        }

        // Поле "Срок срочной выплаты".
        // Тест: поле "Срок срочной выплаты". Тест-кейс текст поля.

        // Текст "Срок срочной выплаты".
        [TestCase("Срок срочной выплаты",                                     // string Expected
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/label")]  // string XPath_str
        // Текст "5 лет".
        [TestCase("5 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[2]/span[1]")]
        // Текст "30 лет".
        [TestCase("30 лет", 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[2]/span[2]")] 
        public void Express_payment_switch_text(string Expected, string XPath_str)
        {
            var Express_payment_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Express_payment_text.Text;
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Срок срочной выплаты". Тест-кейс переключение кнопки.

        // Позитивный, минимум. 
        [TestCase("5", "Left", 5,                                                         // string Expected, string Direction, int Key_count
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")]  // string XPath_str
        // Позитивный, максимум.
        [TestCase("30", "Right", 20, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")]
        // Негативный, минимум.
        [TestCase("5", "Left", 6, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")]
        // Негативный, максимум.
        [TestCase("30", "Right", 21, 
            "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")] 
       
        public void Express_payment_switch_value(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Express_payment_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) {Express_payment_switch.SendKeys(Keys.Left);}
                Actual = Express_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("3 166 548 ₽"));
            }
            if (Direction == "Right")
            {
                // Значение поля.
                for (int i = 0; i < Key_count; i++) {Express_payment_switch.SendKeys(Keys.Right);}
                Actual = Express_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.That(Actual, Is.EqualTo(Expected));

                // Значение рассчета 
                var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
                Calculate.SendKeys(Keys.Enter);
                var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[2]"));
                string Actual_result = Result.Text;
                ClassicAssert.That(Actual_result, Is.EqualTo("3 166 548 ₽"));
            }
        }

        // Поле "Рассчитать".
        // Тест: поле "Рассчитать". Тест-кейс: текст кнопки "Рассчитать".

        [Test]
        
        public void Сalculate_text()
        {
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
            string Actual = Calculate.Text;
            string Expected = "Рассчитать";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

        // Тест: поле "Рассчитать". Тест-кейс: нажатие на кнопку "Рассчитать".
        [Test]
        
        public void Сalculate()
        {
            var Calculate = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/button"));
            Calculate.Click();
            var Result = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/div/div[1]/p[1]"));
            string Actual = Result.Text;
            string Expected = "ИТОГОВАЯ СУММА НАКОПЛЕНИЙ В ПРОГРАММЕ";
            ClassicAssert.That(Actual, Is.EqualTo(Expected));
        }

     
    }
}
