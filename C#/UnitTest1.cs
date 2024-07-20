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
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле "Укажите данные".
        // Тест: поле "Укажите данные". Тест-кейс: текст поля.
        [Test]
        public void Title2_text()
        {
            var Title2 = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/p"));
            string Actual = Title2.Text;
            string Expected = "УКАЖИТЕ ДАННЫЕ";
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле " Ваш официальный доход".
        // Тест: поле "Ваш официальный доход", Тест-кейс: текст поля.

        [Test]
        public void Offitial_income_text()
        {
            var Оfficial_income = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/label"));
            string Actual = Оfficial_income.Text;
            string Expected = "Ваш официальный доход";
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: поле "Ваш официальный доход". Тест - кейс: переключение элементов списка.

        [TestCase("до 80 000 ₽", 0, "//*[@id=\"Ваш официальный доход\"]", 
         "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")] // Значение "от 80 000".
        [TestCase("от 80 000 до 150 000 ₽", 1, "//*[@id=\"Ваш официальный доход\"]", 
         "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")] // Значение "от 80 000 до 150 000".
        [TestCase("от 150 000 ₽", 2, "//*[@id=\"Ваш официальный доход\"]", 
         "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[1]/div/div/div/span[2]")] // Значение "от 150 000".

        public void Offitial_income_value(string Expected, int Key_count, string XPath_str, string XPath_str2)
        {
            var Оfficial_income = driver.FindElement(By.XPath(XPath_str));

            Оfficial_income.SendKeys(Keys.Enter);
            for (int i = 0; i < Key_count; i++) { Оfficial_income.SendKeys(Keys.Down); }
            Оfficial_income.SendKeys(Keys.Enter);

            var Оfficial_income_text = driver.FindElement(By.XPath(XPath_str2));
            string Actual = Оfficial_income_text.Text;
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле "Сумма взносов в Программу в месяц"
        // Тест: поле "Сумма взносов в Программу в месяц". Тест-кейс: текст поля.

        [Test]
        public void Contributions_text()
        {
            var Contributions_value = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[2]/div/div/div/label"));
            string Actual = Contributions_value.Text;
            string Expected = "Сумма взносов в Программу в месяц";
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: поле "Сумма взносов в Программу в месяц", тест-кейс: ввод данных.

        [TestCase("1 ₽", "1", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Позитивный, минимум "1".
        [TestCase("9 999 999 ₽", "9999999", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Позитивный, максимум "9 999 999".
        [TestCase("", "0", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, ноль.
        [TestCase("", "-", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, знак "-".
        [TestCase("1 000 000 ₽", "10000000", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, максимум, 10 000 000.
        [TestCase("", "д", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, русские буквы, нижний регистр.
        [TestCase("", "Д", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, русские буквы вехний регистр.
        [TestCase("", "d", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, английские буквы нижний регистр.
        [TestCase("", "D", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, английские буквы верхний регистр.
        [TestCase("", "!", "//*[@id=\"Сумма взносов в Программу в месяц\"]")] // Негативный, специальные символы.

        public void Contributions_value(string Expected, string Key_str, string XPath_str)
        {
            var Contributions_number = driver.FindElement(By.XPath(XPath_str));
            Contributions_number.Click();
            Contributions_number.SendKeys(Keys.Backspace);
            Contributions_number.SendKeys(Key_str);
            string Actual = Contributions_number.GetAttribute("value");

            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле "Перевод накоплений ОПС в Программу".
        // Тест: поле "Перевод накоплений ОПС в Программу". Тест-кейс: текст поля.

        [Test]
        public void Transaction_text()
        {
            var Transaction_value = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[1]/div/div/div/label"));
            string Actual = Transaction_value.Text;
            string Expected = "Перевод накоплений ОПС в Программу";
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: поле "Перевод накоплений ОПС в Программу", тест-кейс: ввод данных.

        [TestCase("1 ₽", "1", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Позитивный, минимум "1".
        [TestCase("9 999 999 ₽", "9999999", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Позитивный, максимум "9 999 999".
        [TestCase("", "0", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, ноль.
        [TestCase("", "-", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, знак "-".
        [TestCase("1 000 000 ₽", "10000000", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, максимум, 10 000 000.
        [TestCase("", "д", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, русские буквы, нижний регистр.
        [TestCase("", "Д", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, русские буквы вехний регистр.
        [TestCase("", "d", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, английские буквы нижний регистр.
        [TestCase("", "D", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, английские буквы верхний регистр.
        [TestCase("", "!", "//*[@id=\"Перевод накоплений ОПС в Программу\"]")] // Негативный, специальные символы.

        public void Transactions_data_enter(string Expected, string Key_str, string XPath_str)
        {
            var Transactions_number = driver.FindElement(By.XPath(XPath_str));
            Transactions_number.Click();
            Transactions_number.SendKeys(Keys.Backspace);
            Transactions_number.SendKeys(Key_str);
            string Actual = Transactions_number.GetAttribute("value");

            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле чекбокс.
        // Тест: чекбокс. Тест кейс: текст.

        [Test]
        public void Check_box_text()
        {
            var Check_box = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[3]/div[2]/label/span[2]"));
            string Actual = Check_box.Text;
            string Expected = "Учитывать накопления ОПС";
            ClassicAssert.AreEqual(Expected, Actual);
             
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
            ClassicAssert.False(Checkbox_off);

            var Transactions = driver.FindElement(By.XPath("//*[@id=\"Перевод накоплений ОПС в Программу\"]"));
            bool Transactions_off = Transactions.Enabled;
            ClassicAssert.False(Transactions_off);

            // Включение

            Check_box.SendKeys(Keys.Space);
            Checkbox_off = Check_box.Selected;
            ClassicAssert.True(Checkbox_off);

            Transactions_off = Transactions.Enabled;
            ClassicAssert.True(Transactions_off);
             
        }

        // Поле "Налоговый вычет".
        // Тест: поле "Налоговый вычет". Тест-кейс: текст.

        [Test]
        public void Tax_deduction_text()
        {
            var Tax_deduction = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/label"));
            string Actual = Tax_deduction.Text;
            string Expected = "Налоговый вычет";
            ClassicAssert.AreEqual(Expected, Actual);
        }

        // Тест: поле "Налоговый вычет". Тест - кейс: переключение элементов списка.

        [TestCase("Не вкладывать в Программу", 0, "//*[@id=\"Налоговый вычет\"]", 
         "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/div/div/span[2]")] // Первый элемент списка.
        [TestCase("Вкладывать в Программу", 1, "//*[@id=\"Налоговый вычет\"]", 
         "//*[@id=\"calc\"]/div/form/div[1]/div[1]/div[4]/div/div/div/span[2]")] // Второй элемент списка.
        public void Tax_deduction_value(string Expected, int Key_count, string XPath_str, string XPath_str2)
        {
            var Tax_deduction = driver.FindElement(By.XPath(XPath_str));
            Tax_deduction.SendKeys(Keys.Enter);
            for (int i = 0; i < Key_count; i++) { Tax_deduction.SendKeys(Keys.Down); }
            Tax_deduction.SendKeys(Keys.Enter);

            var Tax_deduction_off = driver.FindElement(By.XPath(XPath_str2));
            string Actual = Tax_deduction_off.Text;
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Поле "Пол".
        // Тест: переключатель "Пол". Тест-кейс: текст кнопок.

        [Test]
        public void Gender_switch_text()
        {
            // Текст кнопки "М".

            var Gender_switch_text1 = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[1]/span[2]"));
            string Actual = Gender_switch_text1.Text;
            string Expected = "М";
            ClassicAssert.AreEqual(Expected, Actual);

            // Текст кнопки "Ж".

            var Gender_switch_text2 = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[2]/span[2]"));
            Actual = Gender_switch_text2.Text;
            Expected = "Ж";
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: переключатель "Пол". Тест-кейс: переключение кнопок.

        [Test]
        public void Gender_switch()
        {
            // Кнопка "М" включена, кнопка "Ж" выключена.

            var Male_switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[1]/span[1]/input"));
            bool Male_switch_off = Male_switch.Selected;
            ClassicAssert.True(Male_switch_off);
            var Female_switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div/label[2]/span[1]/input"));
            bool Female_switch_on = Female_switch.Selected;
            ClassicAssert.False(Female_switch_on);

            // Переключаем кнопку

            var Switch = driver.FindElement(By.XPath("//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[1]/div"));
            Switch.Click();

            // Кнопка "М" выключена, кнопка "Ж" включена.

            Male_switch_off = Male_switch.Selected;
            ClassicAssert.False(Male_switch_off);
            Female_switch_on = Female_switch.Selected;
            ClassicAssert.True(Female_switch_on);
             
        }

        // Поле "Ваш возраст".
        // Тест: поле "Ваш возраст". Тест-кейс: текст поля.

        [TestCase("Ваш возраст", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/label")] // Текст "Ваш возраст".
        [TestCase("18 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[2]/span[1]")] // Текст "18 лет".
        [TestCase("80 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[2]/span[2]")] // Текст "80 лет".
        public void Age_switch_text(string Expected, string XPath_str)
        {
            var Age_switch_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Age_switch_text.Text;
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: поле "Ваш возраст". Тест-кейс: переключение кнопки.

        [TestCase("18", "Left", 17, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, минимум.
        [TestCase("80", "Right", 45, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, максимум.
        [TestCase("18", "Left", 18, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] // Негативный, минимум.
        [TestCase("80", "Right", 46, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]")] // Негативный, максимум.
        public void Age_switch(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Age_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Left);}
                Actual = Age_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
            }
            if (Direction == "Right")
            {
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Right);}
                Actual = Age_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
            }
             
        }

        // Поле "Возраст начала получения выплат".
        // Тест: поле "Возраст начала получения выплат". Тест-кейс текст поля.

        [TestCase("Возраст начала получения выплат", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/label")] // Текст "Возраст начала получения выплат".
        [TestCase("50 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[2]/span[1]")] // Текст "50 лет".
        [TestCase("90 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[2]/span[2]")] // Текст "90 лет".
        public void Start_payment_text(string Expected, string XPath_str)
        {
            var Start_payment_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Start_payment_text.Text;
            ClassicAssert.AreEqual(Expected, Actual);
             
        }


        // Тест: поле "Возраст начала получения выплат". Тест-кейс переключение кнопки.

        [TestCase("50", "Left", 10, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, минимум.
        [TestCase("90", "Right", 30, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, максимум.
        [TestCase("50", "Left", 11, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Негативный, минимум.
        [TestCase("90", "Right", 31, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Негативный, максимум.
        public void Start_payment_switch(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Start_payment_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                for (int i = 0; i < Key_count; i++) {Start_payment_switch.SendKeys(Keys.Left);}
                Actual = Start_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
            }
            if (Direction == "Right")
            {
                for (int i = 0; i < Key_count; i++) {Start_payment_switch.SendKeys(Keys.Right);}
                Actual = Start_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
            }
             
        }

        // Поле "Ваш возраст" и "Возраст начала получения выплат".
        // Тест: соотношение переключателя "Ваш возраст" и "Возраст начала получения выплат". Тест-кейс: переключатели.
        // Негативные тесты не требуются, так как выход за границы поля проверяются в тестах "Ваш возраст" и "Возраст начала получения выплат".

        [TestCase("33", "Left", 17, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
         "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, 18 лет.
        [TestCase("60", "Right", 10, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
         "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, 45 лет.
        [TestCase("60", "Right", 22, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
         "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, 57 лет.
        [TestCase("62", "Right", 23, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
         "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, 58 лет.
        [TestCase("84", "Right", 45, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[1]/div[2]/div[1]/div/div[5]/div[4]",
         "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[2]/div[1]/div/div[5]/div[4]")] // Позитивный, 80 лет.
        public void Age_and_start_payment(string Expected, string Direction, int Key_count, string XPath_str, string XPath_str2)
        {
            var Age_switch = driver.FindElement(By.XPath(XPath_str));
            var Start_payment_switch = driver.FindElement(By.XPath(XPath_str2));
            string Actual;
            if (Direction == "Left")
            {
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Left); }
                Actual = Start_payment_switch.GetDomAttribute("aria-valuemin");
                ClassicAssert.AreEqual(Expected, Actual);
            }
            if (Direction == "Right")
            {
                for (int i = 0; i < Key_count; i++) { Age_switch.SendKeys(Keys.Right); }
                Actual = Start_payment_switch.GetDomAttribute("aria-valuemin");
                ClassicAssert.AreEqual(Expected, Actual);
            }
             
        }

        // Поле "Срок срочной выплаты".
        // Тест: поле "Срок срочной выплаты". Тест-кейс текст поля.

        [TestCase("Срок срочной выплаты", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/label")] // Текст "Срок срочной выплаты".
        [TestCase("5 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[2]/span[1]")] // Текст "5 лет".
        [TestCase("30 лет", "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[2]/span[2]")] // Текст "30 лет".
        public void Express_payment_text(string Expected, string XPath_str)
        {
            var Express_payment_text = driver.FindElement(By.XPath(XPath_str));
            string Actual = Express_payment_text.Text;
            ClassicAssert.AreEqual(Expected, Actual);
             
        }

        // Тест: поле "Срок срочной выплаты". Тест-кейс переключение кнопки.

        [TestCase("5", "Left", 5, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")] // Позитивный, минимум.
        [TestCase("30", "Right", 20, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")] // Позитивный, максимум.
        [TestCase("5", "Left", 6, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")] // Негативный, минимум.
        [TestCase("30", "Right", 21, "//*[@id=\"calc\"]/div/form/div[1]/div[2]/div[3]/div[1]/div/div[5]/div[4]")] // Негативный, максимум.
        public void Express_payment_switch(string Expected, string Direction, int Key_count, string XPath_str)
        {
            var Express_payment_switch = driver.FindElement(By.XPath(XPath_str));
            string Actual;
            if (Direction == "Left")
            {
                for (int i = 0; i < Key_count; i++) {Express_payment_switch.SendKeys(Keys.Left);}
                Actual = Express_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
            }
            if (Direction == "Right")
            {
                for (int i = 0; i < Key_count; i++) {Express_payment_switch.SendKeys(Keys.Right);}
                Actual = Express_payment_switch.GetDomAttribute("aria-valuenow");
                ClassicAssert.AreEqual(Expected, Actual);
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
            ClassicAssert.AreEqual(Expected, Actual);
             
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
            ClassicAssert.AreEqual(Expected, Actual);
             
        }
    }
}
