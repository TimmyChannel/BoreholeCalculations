using BoreholeCalculations.Models;
using BoreholeCalculations.ViewModels;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations
{
	public class Locator
	{
		private readonly BoreholeService _service = new BoreholeService(1000);
		public BoreholeTableControlViewModel BoreholeTableControlViewModel { get; set; }
		public ChartsPanelControlViewModel ChartsPanelControlViewModel { get; set; }
		public CalculationControlViewModel CalculationControlViewModel { get; set; }
		public NewBoreholeWindowViewModel NewBoreholeWindowViewModel { get; set; }
		public Locator()
		{

			BoreholeTableControlViewModel = new BoreholeTableControlViewModel(_service);
			ChartsPanelControlViewModel = new ChartsPanelControlViewModel(_service);
			CalculationControlViewModel = new CalculationControlViewModel(_service);
			NewBoreholeWindowViewModel = new NewBoreholeWindowViewModel(_service);
		}
	}
}
