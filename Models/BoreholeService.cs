using BoreholeCalculations.Models.Calculations;
using BoreholeCalculations.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
		private ObservableCollection<IBorehole> CreateBoreholes()
		{
			return new ObservableCollection<IBorehole>()
			{
				new Borehole("Огненная Стрела", 1, 1500, new System.Windows.Point(59.123456, 68.987654), 895.3),
				new Borehole("Тревожный Утёс", 2, 1600, new System.Windows.Point(59.123456, 68.987655), 1023.76),
				new Borehole("Каменный Ветер", 3, 1700, new System.Windows.Point(59.123456, 68.987656), 912.4),
				new Borehole("Золотая Дуга", 4, 1800, new System.Windows.Point(59.123457, 68.987654), 1001.2),
				new Borehole("Серебряный Овраг", 5, 1900, new System.Windows.Point(59.123457, 68.987655), 920.8),
				new Borehole("Радужный Каньон", 6, 2000, new System.Windows.Point(59.123457, 68.987656), 1034.5),
				new Borehole("Жемчужный Перевал", 7, 2100, new System.Windows.Point(59.123458, 68.987654), 934.7),
				new Borehole("Бриллиантовый Поток", 8, 2200, new System.Windows.Point(59.123458, 68.987655), 1021.8),
				new Borehole("Изумрудный Лес", 9, 2300, new System.Windows.Point(59.123458, 68.987656), 915.2),
				new Borehole("Солнечный Берег", 10, 2400, new System.Windows.Point(59.123459, 68.987654), 997.1),
				new Borehole("Лунный Край", 11, 2500, new System.Windows.Point(59.123459, 68.987655), 932.5),
				new Borehole("Звездный Рубеж", 12, 2600, new System.Windows.Point(59.123459, 68.987656), 1043.9),
				new Borehole("Тёмная Долина", 13, 2700, new System.Windows.Point(59.123460, 68.987654), 948.3),
				new Borehole("Светлая Гряда", 14, 2800, new System.Windows.Point(59.123460, 68.987655), 1056.7),
				new Borehole("Утренний Заряд", 15, 2900, new System.Windows.Point(59.123460, 68.987656), 923.1),
				new Borehole("Полденный Пик", 16, 3000, new System.Windows.Point(59.123461, 68.987654), 1012.4),
				new Borehole("Вечерняя Роса", 17, 3100, new System.Windows.Point(59.123461, 68.987655), 940.2),
				new Borehole("Ночной Вихрь", 18, 3200, new System.Windows.Point(59.123461, 68.987656), 1037.5),
				new Borehole("Рассветная Грань", 19, 3300, new System.Windows.Point(59.123462, 68.987654), 931.8),
				new Borehole("Закатный Отток", 20, 3400, new System.Windows.Point(59.123462, 68.987655), 1046.2),
				new Borehole("Утренний Туман", 21, 3500, new System.Windows.Point(59.123462, 68.987656), 920.4),
				new Borehole("Полденный Зной", 22, 3600, new System.Windows.Point(59.123463, 68.987654), 1015.7),
				new Borehole("Вечерняя Мгла", 23, 3700, new System.Windows.Point(59.123463, 68.987655), 980.2),
				new Borehole("Ночная Тишина", 24, 3800, new System.Windows.Point(59.123463, 68.987656), 1070.5),
				new Borehole("Рассветный Луч", 25, 3900, new System.Windows.Point(59.123464, 68.987654), 1025.1),
				new Borehole("Закатный Огонь", 26, 4000, new System.Windows.Point(59.123464, 68.987655), 1002.8),
				new Borehole("Утренняя Роса", 27, 4100, new System.Windows.Point(59.123464, 68.987656), 1055.6),
				new Borehole("Полденный Солнцепёк", 28, 4200, new System.Windows.Point(59.123465, 68.987654), 1078.3),
				new Borehole("Вечерний Перепад", 29, 4300, new System.Windows.Point(59.123465, 68.987655), 950.7),
				new Borehole("Ночная Тьма", 30, 4400, new System.Windows.Point(59.123465, 68.987656), 980.5),
				new Borehole("Красный Взрыв", 31, 1500, new System.Windows.Point(59.123466, 68.987654), 980.1),
				new Borehole("Зеленый Водопад", 32, 1600, new System.Windows.Point(59.123466, 68.987655), 1030.2),
				new Borehole("Синий Глубинный", 33, 1700, new System.Windows.Point(59.123466, 68.987656), 1015.6),
				new Borehole("Белый Ледниковый", 34, 1800, new System.Windows.Point(59.123467, 68.987654), 1052.1),
				new Borehole("Желтый Зеркальный", 35, 1900, new System.Windows.Point(59.123467, 68.987655), 1010.9),
				new Borehole("Фиолетовый Драгоценный", 36, 2000, new System.Windows.Point(59.123467, 68.987656), 970.4),
				new Borehole("Оранжевый Пустынный", 37, 2100, new System.Windows.Point(59.123468, 68.987654), 1012.3),
				new Borehole("Голубой Океанский", 38, 2200, new System.Windows.Point(59.123468, 68.987655), 1035.6),
				new Borehole("Пурпурный Королевский", 39, 2300, new System.Windows.Point(59.123468, 68.987656), 985.7),
				new Borehole("Черный Магический", 40, 2400, new System.Windows.Point(59.123469, 68.987654), 1079.2),
				new Borehole("Коричневый Обжигающий", 41, 2500, new System.Windows.Point(59.123469, 68.987655), 987.5),
				new Borehole("Розовый Романтичный", 42, 2600, new System.Windows.Point(59.123469, 68.987656), 1001.8),
				new Borehole("Серый Туманный", 43, 2700, new System.Windows.Point(59.123470, 68.987654), 1050.9),
				new Borehole("Бежевый Песчаный", 44, 2800, new System.Windows.Point(59.123470, 68.987655), 1025.4),
				new Borehole("Салатовый Лесной", 45, 2900, new System.Windows.Point(59.123470, 68.987656), 1032.7),
				new Borehole("Малиновый Вишневый", 46, 3000, new System.Windows.Point(59.123471, 68.987654), 1065.3),
				new Borehole("Сепия Гармоничный", 47, 3100, new System.Windows.Point(59.123471, 68.987655), 980.6),
				new Borehole("Синоптический Предвестник", 48, 3200, new System.Windows.Point(59.123471, 68.987656), 1005.2),
				new Borehole("Античный Воин", 49, 3300, new System.Windows.Point(59.123472, 68.987654), 1098.4),
				new Borehole("Футуристический Новатор", 50, 3400, new System.Windows.Point(59.123472, 68.987655), 1012.9)
			};
		}
		public Thread CalculatePessureInAllBoreholes(CancellationToken cancellationToken, int numSteps, Action<int> progressCallback)
		{
			Thread thread = new Thread(new ParameterizedThreadStart(CalculatePessureInAllBoreholes));
			thread.Start(new CalcParams(cancellationToken, numSteps, progressCallback));
			return thread;
		}
		private void CalculatePessureInAllBoreholes(object param)
		{
			if (param is CalcParams parametrs)
			{
				var numSteps = parametrs.NumSteps;
				var cancellationToken = parametrs.CancellationToken;
				var progressCallback = parametrs.ProgressCallback;
				var calculator = new PressureCalculator();
				var strategy = new SimplePressureCalculationStrategy();
				calculator.SetPressureCalculationStrategy(strategy);
				var counter = 0;
				var collectionPressureByDepth = new List<Dictionary<double, double>>();
				try
				{
					foreach (var item in _repository.GetAll())
					{
						var arr = calculator.CalculatePressureArray(item.Depth, numSteps, item.AverageLiquidDensity, cancellationToken).Result;
						var depthStep = item.Depth / numSteps;
						var pressureByDepth = new Dictionary<double, double>();
						for (int i = 0; i < numSteps; i++)
							pressureByDepth.Add(depthStep * i, arr[i]);
						collectionPressureByDepth.Add(pressureByDepth);
						counter++;
						progressCallback?.Invoke(counter);
					}
					int c = 0;
					foreach (var item in collectionPressureByDepth)
					{
						((Borehole)_repository.GetAll()[c]).PressureByDepth = item;
						c++;
					}
				}
				catch (AggregateException)
				{
					Debug.WriteLine("The operation was canceled");
					Thread.CurrentThread.Abort();
				}
				catch (OutOfMemoryException)
				{
					Debug.WriteLine("Lack of memory");
					Thread.CurrentThread.Abort();
					throw;
				}
			}
		}
		public ObservableCollection<IBorehole> GetBoreholeList()
		{
			return _repository.GetAll();
		}
		public void UpdateBorehole(IBorehole borehole)
		{
			_repository.Update(borehole);
		}
		public void DeleteBorehole(int id)
		{
			_repository.Delete(id);
		}
		public void AddBorehole(IBorehole borehole)
		{
			_repository.Add(borehole);
		}
		public delegate void EventHandlerDelegate(object sender, PropertyChangedEventArgs e);

		public void SubscribeToEvents(PropertyChangedEventHandler eventHandler)
		{
			foreach (var item in _repository.GetAll())
			{
				item.PropertyChanged += eventHandler;
			}
		}

		private class CalcParams
		{
			public CalcParams(CancellationToken cancellationToken, int numSteps, Action<int> progressCallback)
			{
				CancellationToken = cancellationToken;
				NumSteps = numSteps;
				ProgressCallback = progressCallback;
			}

			public CancellationToken CancellationToken { get; }
			public int NumSteps { get; }
			public Action<int> ProgressCallback { get; }
		}
	}

}
