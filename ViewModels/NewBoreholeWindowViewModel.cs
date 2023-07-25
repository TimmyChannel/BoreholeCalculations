using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoreholeCalculations.Models;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace BoreholeCalculations.ViewModels
{
	public class NewBoreholeWindowViewModel : ObservableObject, ICloseWindow
	{
		private BoreholeService _service;
		public NewBoreholeWindowViewModel(BoreholeService service)
		{
			_service = service;
			AddNewBorehole = new RelayCommand(OnAddNewBorehole);
			_showWarning = false;
		}
		private string _boreholeTitle;
		public string BoreholeTitle { get => _boreholeTitle; set => SetProperty(ref _boreholeTitle, value); }
		private double _boreholeDepth;
		public double BoreholeDepth { get => _boreholeDepth; set => SetProperty(ref _boreholeDepth, value); }
		private double _boreholeCoordinatesX;
		public double BoreholeCoordinatesX { get => _boreholeCoordinatesX; set => SetProperty(ref _boreholeCoordinatesX, value); }
		private double _boreholeCoordinatesY;
		public double BoreholeCoordinatesY { get => _boreholeCoordinatesY; set => SetProperty(ref _boreholeCoordinatesY, value); }
		private double _boreholeAvgDensity;
		public double BoreholeAvgDensity { get => _boreholeAvgDensity; set => SetProperty(ref _boreholeAvgDensity, value); }
		private bool _showWarning;
		public bool ShowWarning { get => _showWarning; set => SetProperty(ref _showWarning, value); }

		public ICommand AddNewBorehole { get; private set; }
		public Action Close { get; set; }

		private void OnAddNewBorehole()
		{
			if (_boreholeTitle != null || _boreholeTitle == "")
			{
				_service.AddBorehole(new Borehole(_boreholeTitle, _service.GetBoreholeList().Count + 1,
					_boreholeDepth, new System.Windows.Point(_boreholeCoordinatesX, BoreholeCoordinatesY), _boreholeAvgDensity));
				Close?.Invoke();
			}
			else
			{
				ShowWarning = true;
			}
		}
	}
	public interface ICloseWindow
	{
		Action Close { get; set; }
	}
}
