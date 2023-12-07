﻿using SchoolChatGPT_v1._0.NeuralNetworkClasses;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SetWordsForNeuralNetwork
{
    public class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите число:\n0 - ввести новые слова\n1 - ввести новые предложения для обучения нейросети");
                    int num = int.Parse(Console.ReadLine());
                    if (num != 0 || num != 1) { ElseError(); }
                    if (num == 0)
                    { SetWords(Console.ReadLine()); break; }
                    if (num == 1)
                    { SetSentences(); break; }
                }
                catch
                {
                    ElseError();
                }
            } 
        }

        private static void ElseError()
        {
            Console.WriteLine("Введити целое ЧИСЛО 1 ИЛИ 0");
        }

        private static void SetWords(string input)
        {
            Console.WriteLine("Введите слова:");
            Words words = new Words();
            words.SetWords(input);
        }

        private static void SetSentences()
        {
           
            Console.WriteLine("Введите предложения и выходной результат в виде: предложение$(1 или 0):");
            //  string input = Console.ReadLine();
            string input = "Что такое теорема Пифагора? $0: Что такое криволинейные интегралы и как их вычислять? $0: Что такое квадратный корень и как его вычислить? $0: Что такое производная функции и как найти ее значение? $0: Что такое процент и как его рассчитать? $0: Как найти объем цилиндра? $0: Что такое стороны прямоугольного треугольника и как найти их длины? $0: Что такое квадрат и как найти его периметр? $0: Как найти площадь круга? $0: Что такое биссектриса угла и как найти ее положение? $0: Как умножать два десятичных числа? $0: Что такое гипотенуза прямоугольного треугольника и как ее найти? $0: Что такое асимптоты графика функции и как их найти? $0: Как находить среднее арифметическое чисел? $0: Что такое матрицы и как их умножать? $0: Что такое десятичная дробь и как ее записывать? $0: Как найти сумму арифметической прогрессии? $0: Что такое дискриминант квадратного уравнения и как его использовать? $0: Как находить объем параллелепипеда? $0: Что такое угол наклона прямой и как его измерить? $0: Как решать систему линейных уравнений методом подстановки? $0: Что такое медиана выборки и как ее найти? $0: Как найти площадь прямоугольного треугольника? $0: Что такое действительные числа и как их классифицировать? $0: Как находить объем шара? $0: Что такое координаты точки на плоскости и как их определить? $0: Как решать квадратные уравнения методом выделения полного квадрата? $0: Что такое тангенс угла и как его вычислить? $0: Как находить сумму геометрической прогрессии? $0: Что такое логарифм и как его применять? $0: Как находить площадь равнобедренного треугольника? $0: Что такое периметр и как его найти? $0: Как решать системы линейных уравнений методом Гаусса? $0:Что такое формула квадратного уравнения и как ее применить? $0: Как находить объем пирамиды? $0: Что такое алгебраические выражения и как их упрощать? $0: Как находить площадь ромба? $0: Что такое интеграл и как его рассчитать? $0: Как определить симметрию графика функции? $0: Что такое график функции и как его строить? $0: Как находить производную сложной функции? $0: Что такое действительные корни уравнения и как их находить? $0: Как определить асимптоты графика функции? $0: Что такое линейные уравнения и как их решать? $0: Как находить производные высших порядков? $0: Что такое равномерное движение и как его описать математически? $0: Как находить площадь трапеции? $0: Что такое комплексные числа и как их операции выполняются? $0: Как определить угол наклона прямой к оси OX? $0: Что такое линейная зависимость и как ее выявить? $0: Как находить объем цилиндрического бака? $0: Что такое обратная функция и как ее находить? $0: Как определить, пересекаются ли две прямые? $0: Что такое касательная к графику функции и как ее находить? $0: Как находить производную функции в точке? $0: Что такое арифметическая прогрессия и как находить сумму членов? $0: Как находить объем конуса? $0: Что такое знак числа и как его определить? $0: Как определить, является ли функция монотонной? $0: Что такое вершина параболы и как ее найти? $0: Как находить длину дуги графика функции? $0: Что такое бесконечно малая функция и как ее свойства использовать? $0: Как определить, касается ли график функции оси OX? $0: Что такое экстремум функции и как его находить? $0: Как находить корни квадратного уравнения методом дискриминанта? $0: Что такое тождества и как их применять при решении уравнений? $0: Как находить площадь сектора круга? $0: Что такое кубическая функция и как ее график выглядит? $0: Как определить, пересекаются ли два графика функций? $0: Что такое матричные уравнения и как их решать? $0: Как находить обратную матрицу? $0: Как определить, является ли система уравнений совместной? $0: Что такое криволинейные координаты и как ими пользоваться? $0: Как находить объем параллелепипеда с помощью векторов? $0: Что такое собственные числа и собственные векторы матрицы? $0: Как находить ранг матрицы? $0: Что такое ряд Тейлора и как им пользоваться при приближенных вычислениях? $0: Как определить, является ли график функции симметричным относительно осей координат? $0:Какие свойства имеют числа Фибоначчи и как их выразить формулой? $0: Что такое ряды чисел Фибоначчи и как их сумма находится? $0: Какая связь между числами Фибоначчи и золотым сечением? $0: Что такое гармонический ряд и сходимость его членов? $0: Как вычислить площадь круга, используя число π? $0: Как находить объем шара и его поверхностную площадь? $0: Что такое координаты вектора в пространстве и как их находить? $0: Как вычислить площадь сферы и её объем? $0: Какие теоремы используются при вычислении объема и площади фигур? $0: Что такое линейная независимость векторов и как её определить? $0: Как находить производные сложных функций с несколькими переменными? $0: Как определить линейную зависимость векторов в пространстве? $0: Что такое лемма Гаусса и как она применяется в математике? $0: Какие теоремы используются при вычислении интегралов от функций нескольких переменных? $0: Что такое векторное поле и как его изучают? $0: Как определить, касается ли кривая на плоскости горизонтальной прямой? $0: Что такое теорема о среднем значении и как она применяется? $0: Как вычислить интегралы от векторных полей? $0: Как определить, пересекаются ли две кривые на плоскости? $0: Что такое интеграл Коши и как его использовать? $0: Как находить длину и кривизну кривых на плоскости? $0: Как вычислить интегралы от кривизны кривых? $0: Что такое гиперболические функции и как они определены? $0: Какие свойства имеют гиперболические функции? $0: Что такое теорема о вычетах и как она используется в теории функций? $0: Как вычислить интегралы от функций с комплексными переменными? $0: Как определить, является ли ряд абсолютно сходящимся? $0: Что такое преобразование Лапласа и как оно применяется в математике? $0: Как находить преобразования Лапласа от функций? $0: Как определить, является ли ряд условно сходящимся? $0: Что такое обобщенные функции и как они описываются? $0: Как вычислить обобщенные функции от функций-пробников? $0: Как определить, сходится ли ряд по Хаусдорфу и какая связь между сходимостью и предельными точками? $0: Что такое аппроксимация функций и какие методы используются? $0: Как находить аппроксимации функций с использованием полиномов? $0: Как определить, является ли ряд фундаментальным и какие условия фундаментальности существуют? $0: Что такое преобразование Фурье и как оно применяется в математике? $0: Как находить преобразования Фурье от функций? $0: Как определить, сходится ли ряд по Вейерштрассу и какие критерии сходимости применяются? $0: Что такое функциональные ряды и как их сумму находить? $0: Как определить, является ли ряд степенным и какие свойства у степенных рядов? $0: Что такое аналитическая функция и какие условия аналитичности существуют? $0: Как находить аналитическое продолжение функций? $0: Как определить, сходится ли ряд Тейлора и какие методы сходимости применяются? $0: Что такое регулярные и сингулярные точки аналитических функций и как их классифицировать? $0: Как находить разложение Лорана и аналитические продолжения функций? $0: Что такое интегральное уравнение и какие методы его решения? $0: Как определить, существует ли у аналитической функции интеграл с неподвижным пределом? $0: Что такое асимптотические разложения функций и какие условия их справедливости? $0: Как находить асимптотические приближения функций? $0: Как определить, существуют ли у аналитической функции обобщенные интегралы? $0: Что такое криволинейные интегралы и как их вычислять? $0: Как находить площадь криволинейных фигур с использованием криволинейных интегралов? $0: Что такое степень ветвления в точке и как её определить? $0: Как находить вычеты и обобщенные интегралы от мероморфных функций? $0: Что такое собственные и несобственные интегралы и как они связаны с голоморфными функциями? $0: Как определить, существуют ли у аналитической функции обобщенные вычеты? $0: Что такое криволинейные координаты и какие они бывают? $0: Как находить интегралы от мероморфных функций по контуру? $0: Что такое координатные системы второго рода и как с ними работать? $0: Как определить, сходится ли обобщенный интеграл? $0: Что такое операторы Лапласа и их преобразования Фурье? $0: Как находить операторы Лапласа и их обратные преобразования? $0: Что такое аналитические функции нескольких переменных и как они исследуются? $0: Как определить, существуют ли у аналитической функции обобщенные операторы Лапласа? $0: Что такое квазиголоморфные функции и как они изучаются? $0: Как находить аналитические продолжения функций в комплексной плоскости? $0: Что такое аналитические фукнции на римановых поверхностях и как они классифицируются? $0: Как определить, существуют ли у аналитической функции обобщенные интегралы по многомерным контурам? $0: Что такое гармонические функции и какие условия гармоничности существуют? $0: Как определить, существуют ли у аналитической функции обобщенные операторы Даламбера? $0: Что такое интегральное уравнение Фредгольма и его решения? $0: Как находить интегральные уравнения Фредгольма методами приближенного анализа? $0: Как определить, существуют ли у аналитической функции обобщенные операторы Дирака? $0:Чему равен интеграл от функции f(x) = x^2 в интервале [0, 1]? $1: Найдите производную функции y(x) = e^x * sin(x). $1: Решите систему линейных уравнений: 2x + y = 4, x - 3y = 5. $1: Какова площадь треугольника, образованного точками (1, 2), (3, 4) и (5, 6)? $1: Найдите корни уравнения x^2 - 4x + 4 = 0. $1: Рассчитайте объем цилиндра с радиусом основания 2 и высотой 6. $1: Найдите значение выражения 5! (5 факториал). $1: Какова площадь круга с радиусом 3? $1: Решите уравнение sin(x) = 0.5 в интервале [0, 2π]. $1: Сколько существует различных перестановок букв в слове \"МАТЕМАТИКА\"? $1: Найдите сумму первых 10 натуральных чисел. $1: Какова площадь прямоугольника со сторонами 8 и 12? $1: Решите уравнение log(x) = 2. $1: Найдите значение интеграла ∫(2x + 3) dx в интервале [1, 4]. $1: Каков объем параллелепипеда с длиной 5, шириной 3 и высотой 7? $1: Найдите значение косинуса угла между векторами (3, 5) и (4, 1). $1: Решите систему нелинейных уравнений: x^2 + y^2 = 25, x - y = 1. $1: Найдите значение функции f(x) = √(x + 3) в точке x = 4. $1: Каков объем шара с радиусом 6? $1: Найдите производную функции f(x) = ln(x^2) - 3x + 4. $1: Решите уравнение 2^(2x - 1) = 8. $1: Найдите площадь трапеции с основаниями 4 и 8, и высотой 6. $1: Каков объем конуса с радиусом основания 5 и высотой 9? $1: Найдите значение интеграла ∫(4x^3 - 2x + 1) dx в интервале [0, 2]. $1: Найдите значение тангенса угла, если синус угла равен 3/5. $1: Решите систему линейных уравнений: 2x - y + z = 4, 3x + 2y - 2z = 7, x + y + 3z = 5. $1: Какова площадь ромба со стороной 10 и углом в 60 градусов? $1: Найдите производную функции y(x) = cos^2(x). $1: Рассчитайте объем цилиндра с площадью основания 16π и высотой 3. $1: Найдите сумму бесконечного геометрического ряда: 1/2 + 1/4 + 1/8 + 1/16 + ... $1: Какова площадь треугольника, образованного точками (0, 0), (6, 0) и (3, 4)? $1: Решите уравнение √(x + 2) - 5 = 0. $1: Найдите значение логарифма log(100) по основанию 10. $1: Какова площадь квадрата со стороной 7? $1: Найдите интеграл ∫(e^(2x) - 2sin(x)) dx. $1: Найдите объем пирамиды с площадью основания 25 и высотой 6. $1: Найдите значение арктангенса отношения 3/4. $1: Решите систему нелинейных уравнений: x^2 + y^2 = 20, x^2 - y^2 = 4. $1: Найдите производную функции f(x) = 1/x. $1: Рассчитайте объем шарового слоя между сферами с радиусами 4 и 6. $1: Найдите сумму бесконечного арифметического ряда: 1/3 + 1/6 + 1/12 + 1/24 + ... $1: Какова площадь ромба со стороной 12 и углом в 45 градусов? $1: Найдите интеграл ∫(2e^(3x) + 5cos(x)) dx. $1: Найдите объем конуса с площадью основания 9π и высотой 4. $1: Найдите значение арккосинуса отношения 5/13. $1: Решите систему линейных уравнений: x - y + 2z = 5, 2x + y + z = 4, 3x - 2y - 3z = 1. $1: Найдите производную функции y(x) = √(2x + 1). $1: Рассчитайте объем цилиндра с площадью основания 9π и высотой 2. $1: Найдите сумму бесконечного геометрического ряда: 2/3 + 4/9 + 8/27 + 16/81 + ... $1: Какова площадь треугольника, образованного точками (-1, 0), (3, 0) и (1, 5)? $1: Решите уравнение ln(2x) - 3 = 0. $1: Найдите значение секанса угла, если косинус угла равен 4/5. $1: Решите систему нелинейных уравнений: x^2 - y^2 = 9, x + y = 6. $1: Найдите производную функции f(x) = 1/x^2. $1: Рассчитайте объем шара с площадью поверхности 144π. $1: Найдите сумму бесконечного арифметического ряда: 1/2 + 1/6 + 1/18 + 1/54 + ... $1: Какова площадь параллелограмма с основанием 7 и высотой 9? $1: Найдите интеграл ∫(3e^(2x) - 4sin(x)) dx. $1: Найдите объем пирамиды с площадью основания 36 и высотой 8. $1: Найдите значение тангенса угла, если котангенс угла равен 7/24. $1: Решите систему линейных уравнений: 2x + 3y - z = 4, x - y + 2z = 5, 3x + y - 2z = 6. $1: Найдите производную функции y(x) = e^(2x) - 2cos(x). $1: Рассчитайте объем конуса с радиусом основания 3 и высотой 7. $1: Найдите сумму бесконечного геометрического ряда: 3/4 + 9/16 + 27/64 + 81/256 + ... $1: Какова площадь круга с радиусом 10? $1: Решите уравнение 4^(x - 1) = 2. $1: Найдите значение косинуса угла, если тангенс угла равен 5/12. $1: Решите систему линейных уравнений: 2x - y + 3z = 1, x + 4y - z = 8, 3x + 2y - 2z = 7. $1: Найдите производную функции f(x) = ln(3x) + 2x^2. $1: Рассчитайте объем цилиндра с радиусом основания 4 и высотой 5. $1: Найдите сумму бесконечного арифметического ряда: 1/5 + 1/25 + 1/125 + 1/625 + ... $1: Какова площадь треугольника, образованного точками (0, 0), (4, 0) и (0, 3)? $1: Решите уравнение sin(2x) = 1 в интервале [0, π]. $1: Найдите значение логарифма log(64) по основанию 4. $1: Каков объем шарового слоя между сферами с радиусами 5 и 7? $1: Найдите интеграл ∫(5e^(x) - 3cos(x)) dx. $1: Найдите объем пирамиды с площадью основания 9 и высотой 6. $1: Найдите значение арксинуса отношения 15/17. $1: Решите систему линейных уравнений: 2x - 3y + z = 3, x + y - 2z = 6, 3x + 2y - z = 9. $1: Найдите производную функции y(x) = tan(3x) + 2ln(x). $1: Рассчитайте объем конуса с площадью основания 25π и высотой 5. $1:Рассмотрим функцию f(x) = 2x^3 - 5x^2 + 8x - 4. Найдите её производную и определите точки, в которых производная равна нулю.\"$1: \"Пусть у вас есть треугольник ABC, где AB = 5 см, BC = 7 см и угол BAC равен 60 градусов. Найдите длину стороны AC и площадь треугольника.\"$1: \"Вы проводите эксперимент, в котором измеряете температуру воздуха каждый час в течение 24 часов. Получившиеся данные представлены в виде графика. Какие методы статистики можно применить для анализа этого набора данных?\"$1: \"Рассмотрим систему уравнений:\\n 2x + 3y - z = 10\\n x - 2y + 4z = 5\\n 3x + 2y - 2z = 15\\n Решите эту систему методом Гаусса.\"$1: \"У вас есть параллелепипед со следующими размерами: длина 8 см, ширина 6 см и высота 12 см. Найдите его объем и площадь поверхности.\"$1: \"Рассмотрим график функции f(x) = sin(2x) + cos(3x) на интервале [0, 2π]. Найдите точки, в которых функция имеет локальные минимумы и максимумы.\"$1: \"Вы исследуете рост растений в течение года и записываете данные каждый месяц. Какой вид математической модели можно использовать для предсказания роста растений в будущем?\"$1: \"Пусть у вас есть круг с радиусом 10 см и вписанный в него треугольник. Найдите длины сторон треугольника, если известно, что он равнобедренный, и один из углов при основании равен 60 градусов.\"$1: \"Вася и Петя играют в карточную игру. В начале у Васи 5 карт, а у Пети 3 карты. Вероятность выигрыша зависит от комбинации карт. Какова вероятность того, что у Васи будет выигрышная комбинация, если известно, что у Пети есть две карты, которые могли бы помочь ему победить?\"$1: \"Представьте, что вы исследуете движение тела под действием гравитации. Напишите уравнение движения для этой системы и определите, как будет меняться скорость и положение тела в зависимости от времени.\"$1:Найдите производную функции y(x) = 3x^4 - 8x^3 + 6x^2 - 2x + 5. Определите точки, в которых производная равна нулю.\"$1: \"Пусть у вас есть треугольник XYZ, где XY = 6 см, XZ = 8 см и угол XYZ равен 45 градусов. Найдите длину стороны YZ и площадь треугольника.\"$1: \"Вы изучаете скорость реакции на различные стимулы и записываете время реакции для группы испытуемых. Какие методы статистического анализа можно использовать для определения среднего времени реакции и разброса результатов?\"$1: \"Рассмотрим систему уравнений:\\n 3x - 2y + 5z = 12\\n 2x + 4y - 3z = 7\\n x - 3y + 2z = 5\\n Решите эту систему уравнений с использованием метода Крамера.\"$1: \"У вас есть прямоугольный параллелепипед с длиной 10 см, шириной 4 см и высотой 6 см. Найдите его объем и площадь всех его граней.\"$1: \"Рассмотрим график функции f(x) = ln(x) на интервале (0, ∞). Найдите точки, в которых функция имеет асимптоты и асимптотическое поведение функции на бесконечности.\"$1: \"Вы исследуете зависимость массы тела от высоты человека и записываете данные для группы людей. Какую математическую модель можно использовать для описания этой зависимости и какие параметры этой модели следует определить?\"$1: \"Пусть у вас есть правильный шестиугольник с радиусом описанной окружности равным 5 см. Найдите длину стороны шестиугольника и его площадь.\"$1: \"Вероятность попадания мяча в баскетбольное кольцо при броске составляет 0.7. Если игрок сделал 10 бросков, какова вероятность того, что он забросит хотя бы 7 мячей?\"$1: \"Представьте, что вы исследуете движение маятника в зависимости от начальной амплитуды колебаний. Какие параметры маятника и какие уравнения описывают его движение?\"$1: \"Рассмотрим функцию f(x) = cos(x) на интервале [0, π]. Найдите точки, в которых функция имеет локальные минимумы и максимумы.\"$1: \"Пусть у вас есть прямая линия, которая проходит через точки (2, 3) и (5, 8). Найдите уравнение этой прямой и угол наклона к горизонтали.\"$1: \"Вы исследуете распределение возраста в городе и собираете данные о возрасте жителей. Какие методы статистики можно применить для анализа распределения возраста и определения характерных значений?\"$1: \"Рассмотрим квадратное уравнение: 2x^2 - 7x + 6 = 0. Найдите корни этого уравнения с использованием дискриминанта.\"$1: \"У вас есть куб со стороной 4 см. Найдите его объем, площадь поверхности и диагональ куба.\"$1: \"Рассмотрим график функции f(x) = e^x на интервале (-∞, ∞). Найдите точки, в которых функция пересекает ось x и ось y.\"$1: \"Вы исследуете влияние концентрации вещества на скорость химической реакции и записываете данные. Какие математические модели можно использовать для описания зависимости между концентрацией и скоростью реакции?\"$1: Найдите НОД чисел 18 и 24. $1: Вычислите квадратный корень из 144. $1: Найдите угол, дополнительный к углу 45 градусов. $1: Переведите число 1011 из двоичной системы счисления в десятичную. $1: Решите уравнение x^2 + 5x + 6 = 0. $1: Если цена товара составляет 80 долларов, и вы сэкономили 20%, сколько вы заплатите? $1: Упростите выражение (A + B) * (A - B). $1: Найдите объем куба с ребром длиной 5 см. $1: Определите, является ли треугольник со сторонами 3, 4 и 5 прямоугольным. $1: Решите уравнение 2^x = 8. $1: Найдите 10-й член арифметической прогрессии: 2, 5, 8, 11, ... $1: Проверьте, является ли число 37 простым. $1: Найдите интеграл ∫(3x^2 + 2x - 1) dx. $1: Найдите уравнение окружности, центр которой находится в точке (2, 3), а радиус равен 4. $1: Докажите теорему Пифагора для треугольника со сторонами 3, 4 и 5. $1: Решите систему уравнений: 2x + 3y = 10 и 4x - y = 5. $1: Используя метод Монте-Карло, оцените число π, бросая иголки на лист бумаги с параллельными линиями. $1: Умножьте матрицу A (2x3) на матрицу B (3x2). $1: Используя биномиальную теорему, вычислите (2x + 3)^4. $1: Постройте график распределения частоты появления чисел от 1 до 10 в выборке данных. $1:Используя метод Монте-Карло, оцените число пи, бросая иголки на лист бумаги с параллельными линиями. $1:Используя метод Монте-Карло, оцените число Пи, бросая иголки на лист бумаги с параллельными линиями. $1:Что такое наибольший общий делитель (НОД) двух чисел? $0: Как вычислить корень квадратный из числа без калькулятора? $0: Какие существуют виды углов в геометрии? $0: Что такое десятичная система счисления? $0: Какие основные операции выполняются с комплексными числами? $0: Что такое процент и как его вычислить? $0: Какие принципы логики лежат в основе алгебры булевых функций? $0: Как найти объем куба, если известна длина его ребра? $0: Какие виды треугольников существуют, и как их классифицировать? $0: Что такое экспоненциальная функция? $0: Что означает термин \"арифметическая прогрессия\"? $0: Как определить, является ли число простым? $0: Что такое интеграл в математическом анализе? $0: Какие основные геометрические фигуры можно описать с помощью уравнений второй степени? $0: Что такое теорема Пифагора и как она формулируется? $0: Как решать системы линейных уравнений? $0: Какие методы существуют для вычисления числа π? $0: Какие основные свойства действий с матрицами? $0: Что такое биномиальная теорема? $0: Какие основные виды графиков используются в статистике и анализе данных? $0";
            string inputWords = Regex.Replace(input, "1", " ");
            inputWords = Regex.Replace(input, "0", " ");
            SetWords(inputWords);
            Sentences sentences = new Sentences(input);
            sentences.SetTrainingData();
            
        }
    }
}