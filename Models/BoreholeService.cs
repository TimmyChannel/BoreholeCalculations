using BoreholeCalculations.Models.Calculations;
using BoreholeCalculations.Models.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models
{
	public class BoreholeService
	{
		IBoreholeRepository _repository;

		public int LiquidDensity { get; }

		public BoreholeService(int liquidDensity)
		{
			_repository = new BoreholeRepository(CreateBoreholes());
			LiquidDensity = liquidDensity;
		}
		private List<IBorehole> CreateBoreholes()
		{
			return new List<IBorehole>()
{
	new Borehole("Огненная Стрела", 1, 1500, new System.Windows.Point(59.123456, 68.987654)),
	new Borehole("Тревожный Утёс", 2, 1600, new System.Windows.Point(59.123456, 68.987655)),
	new Borehole("Каменный Ветер", 3, 1700, new System.Windows.Point(59.123456, 68.987656)),
	new Borehole("Золотая Дуга", 4, 1800, new System.Windows.Point(59.123457, 68.987654)),
	new Borehole("Серебряный Овраг", 5, 1900, new System.Windows.Point(59.123457, 68.987655)),
	new Borehole("Радужный Каньон", 6, 2000, new System.Windows.Point(59.123457, 68.987656)),
	new Borehole("Жемчужный Перевал", 7, 2100, new System.Windows.Point(59.123458, 68.987654)),
	new Borehole("Бриллиантовый Поток", 8, 2200, new System.Windows.Point(59.123458, 68.987655)),
	new Borehole("Изумрудный Лес", 9, 2300, new System.Windows.Point(59.123458, 68.987656)),
	new Borehole("Солнечный Берег", 10, 2400, new System.Windows.Point(59.123459, 68.987654)),
	new Borehole("Лунный Край", 11, 2500, new System.Windows.Point(59.123459, 68.987655)),
	new Borehole("Звездный Рубеж", 12, 2600, new System.Windows.Point(59.123459, 68.987656)),
	new Borehole("Тёмная Долина", 13, 2700, new System.Windows.Point(59.123460, 68.987654)),
	new Borehole("Светлая Гряда", 14, 2800, new System.Windows.Point(59.123460, 68.987655)),
	new Borehole("Утренний Заряд", 15, 2900, new System.Windows.Point(59.123460, 68.987656)),
	new Borehole("Полденный Пик", 16, 3000, new System.Windows.Point(59.123461, 68.987654)),
	new Borehole("Вечерняя Роса", 17, 3100, new System.Windows.Point(59.123461, 68.987655)),
	new Borehole("Ночной Вихрь", 18, 3200, new System.Windows.Point(59.123461, 68.987656)),
	new Borehole("Рассветная Грань", 19, 3300, new System.Windows.Point(59.123462, 68.987654)),
	new Borehole("Закатный Отток", 20, 3400, new System.Windows.Point(59.123462, 68.987655)),
	new Borehole("Утренний Туман", 21, 3500, new System.Windows.Point(59.123462, 68.987656)),
	new Borehole("Полденный Зной", 22, 3600, new System.Windows.Point(59.123463, 68.987654)),
	new Borehole("Вечерняя Мгла", 23, 3700, new System.Windows.Point(59.123463, 68.987655)),
	new Borehole("Ночная Тишина", 24, 3800, new System.Windows.Point(59.123463, 68.987656)),
	new Borehole("Рассветный Луч", 25, 3900, new System.Windows.Point(59.123464, 68.987654)),
	new Borehole("Закатный Огонь", 26, 4000,new System.Windows.Point(59.123464, 68.987655)),
	new Borehole("Утренняя Роса", 27, 4100, new System.Windows.Point(59.123464, 68.987656)),
	new Borehole("Полденный Солнцепёк", 28, 4200, new System.Windows.Point(59.123465, 68.987654)),
	new Borehole("Вечерний Перепад", 29, 4300, new System.Windows.Point(59.123465, 68.987655)),
	new Borehole("Ночная Тьма", 30, 4400, new System.Windows.Point(59.123465, 68.987656)),
	new Borehole("Красный Взрыв", 31, 1500, new System.Windows.Point(59.123466, 68.987654)),
	new Borehole("Зеленый Водопад", 32, 1600, new System.Windows.Point(59.123466, 68.987655)),
	new Borehole("Синий Глубинный", 33, 1700, new System.Windows.Point(59.123466, 68.987656)),
	new Borehole("Белый Ледниковый", 34, 1800, new System.Windows.Point(59.123467, 68.987654)),
	new Borehole("Желтый Зеркальный", 35, 1900, new System.Windows.Point(59.123467, 68.987655)),
	new Borehole("Фиолетовый Драгоценный", 36, 2000, new System.Windows.Point(59.123467, 68.987656)),
	new Borehole("Оранжевый Пустынный", 37, 2100, new System.Windows.Point(59.123468, 68.987654)),
	new Borehole("Голубой Океанский", 38, 2200, new System.Windows.Point(59.123468, 68.987655)),
	new Borehole("Пурпурный Королевский", 39, 2300, new System.Windows.Point(59.123468, 68.987656)),
	new Borehole("Черный Магический", 40, 2400, new System.Windows.Point(59.123469, 68.987654)),
	new Borehole("Коричневый Обжигающий", 41, 2500, new System.Windows.Point(59.123469, 68.987655)),
	new Borehole("Розовый Романтичный", 42, 2600, new System.Windows.Point(59.123469, 68.987656)),
	new Borehole("Серый Туманный", 43, 2700, new System.Windows.Point(59.123470, 68.987654)),
	new Borehole("Бежевый Песчаный", 44, 2800, new System.Windows.Point(59.123470, 68.987655)),
	new Borehole("Салатовый Лесной", 45, 2900, new System.Windows.Point(59.123470, 68.987656)),
	new Borehole("Малиновый Вишневый", 46, 3000, new System.Windows.Point(59.123471, 68.987654)),
	new Borehole("Сепия Гармоничный", 47, 3100, new System.Windows.Point(59.123471, 68.987655)),
	new Borehole("Синоптический Предвестник", 48, 3200, new System.Windows.Point(59.123471, 68.987656)),
	new Borehole("Античный Воин", 49, 3300, new System.Windows.Point(59.123472, 68.987654)),
	new Borehole("Футуристический Новатор", 50, 3400, new System.Windows.Point(59.123472, 68.987655))
};
		}
		public async void CalculatePessureInAllBoreholes(CancellationToken cancellationToken, int numSteps)
		{
			var calculator = new PressureCalculator();
			var strategy = new SimplePressureCalculationStrategy();
			calculator.SetPressureCalculationStrategy(strategy);
			foreach (var item in _repository.GetAll())
            {				
				var arr = await calculator.CalculatePressureArray(item.Depth, numSteps, LiquidDensity, cancellationToken);
				var depthStep = item.Depth / numSteps;
				var pressureByDepth = new Dictionary<double, double>();
				for (int i = 0; i < numSteps; i++)
					pressureByDepth.Add(depthStep * i, arr[i]);
				((Borehole)item).PressureByDepth = pressureByDepth;
				Debug.WriteLine($"Borehole name: {item.Name}");
			}
		}
		public List<IBorehole> GetBoreholeList()
		{
			return _repository.GetAll();
		}
	}
}
