using BoreholeCalculations.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BoreholeCalculations.ViewModels
{
	public class BoreholeTableControlViewModel : ObservableObject
	{
		BoreholeService _service;
		ObservableCollection<IBorehole> _boreholes;
		public ObservableCollection<IBorehole> Boreholes => _boreholes;
		List<IBorehole> _items = new List<IBorehole>();
		Borehole _currentItem;
		public Borehole CurrentItem { get => _currentItem; set => SetProperty(ref _currentItem, value); }
		public BoreholeTableControlViewModel(BoreholeService service)
		{
			_service = service;
			_boreholes = new ObservableCollection<IBorehole>();
			foreach (var item in _service.GetBoreholeList())
			{
				_boreholes.Add(item);
			}
			PropertyChanged += BoreholeTableControlViewModel_PropertyChanged;
		}

		private void BoreholeTableControlViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{

			switch (e.PropertyName)
			{
				case nameof(CurrentItem):
					if (CurrentItem == null) return;
					if (_items.Count >= 5) _items.RemoveAt(0);
					_items.Add(CurrentItem);
					WeakReferenceMessenger.Default.Send(CurrentItem);
					WeakReferenceMessenger.Default.Send(_items);
					break;

				default:
					break;
			}
		}
	}
}
