using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNumber;

namespace UnitTestProject1
{
    [TestClass]
    public class NumTests
    {
        [TestMethod]
        public void FullNumber() // полный корректный автомобильный номер
        {
            // исходные данные
            string text = "А123ВС";
            string expected = "А123ВС"; // ожидаемое значение

            // получение значения с помощью тестируемого метода:
            Tasks g = new Tasks();
            string actual = g.Task1(text);

            // сравнение ожидаемого результата с полученным:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InvalidString() // некорректная входящая строка
        {
            string text = "Ыа342БФ$Y";
            Tasks g = new Tasks();
            Assert.ThrowsException<ArgumentException>(() => g.Task2(text));
        }

        [TestMethod]
        public void NumberСoincidences() // количество совпадений
        {
            string text = "В";
            int expected = 5;

            Tasks g = new Tasks();
            int actual = g.Task3(text);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Restart() // перезапуск программы
        {
            string key = "+";
            bool expected = true;

            Tasks g = new Tasks();
            bool actual = g.Task4(key);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExitESC() // выход по ESC
        {
            ConsoleKey key = ConsoleKey.Escape;
            bool expected = true;

            Tasks g = new Tasks();
            bool actual = g.Task5(key);
            Assert.AreEqual(expected, actual);
        }
    }
}