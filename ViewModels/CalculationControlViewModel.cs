using BoreholeCalculations.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BoreholeCalculations.ViewModels
{
	public class CalculationControlViewModel : ObservableObject
	{
		BoreholeService _service;
		private CancellationTokenSource _cancellationTokenSource;
		public CalculationControlViewModel(BoreholeService service)
		{
			_service = service;
			_progressValue = 0;
			StartCalculations = new RelayCommand(OnStartCalculations);
			CancelCalculations = new RelayCommand(OnCancelCalculations);
			_cancellationTokenSource = new CancellationTokenSource();
		}
		private int _numOfSteps;
		public int NumberOfSteps { get => _numOfSteps; set => SetProperty(ref _numOfSteps, value); }
		private int _progressValue;
		public int ProgressValue { get => _progressValue; set => SetProperty(ref _progressValue, value); }
		private bool _isBusy;
		public bool IsBusy { get => _isBusy; set => SetProperty(ref _isBusy, value); }
		public ICommand CancelCalculations { get; private set; }
		public ICommand StartCalculations { get; private set; }
		private void OnStartCalculations()
		{
			IsBusy = true;
			double maxValue = _service.GetBoreholeList().Count;
			double percentOne = 1.0 / maxValue;
			ProgressValue = 0;
			var thread = _service.CalculatePessureInAllBoreholes(_cancellationTokenSource.Token, _numOfSteps, (counter) =>
			{
				double normalizedValue = (double)counter / maxValue;
				ProgressValue = (int)(normalizedValue * 100);
			});
			var updateThread = new Thread(new ParameterizedThreadStart(OnUpdateParams));
			updateThread.Start(thread);


		}
		private void OnUpdateParams(object obj)
		{
			if (obj is Thread thread)
			{
				while (thread.IsAlive)
				{
				}
				_cancellationTokenSource = new CancellationTokenSource();
				IsBusy = false;
				ProgressValue = 0;
			}
		}
		private void OnCancelCalculations()
		{
			IsBusy = !IsBusy;
			_cancellationTokenSource.Cancel();
		}

	}
}
