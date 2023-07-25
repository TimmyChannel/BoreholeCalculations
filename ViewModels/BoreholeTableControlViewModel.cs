using BoreholeCalculations.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using LiveChartsCore.Drawing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BoreholeCalculations.ViewModels
{
	public class BoreholeTableControlViewModel : ObservableObject
	{
		public ICommand SelectItems { get; private set; }
		public ICommand EditItem { get; private set; }

		BoreholeService _service;
		ObservableCollection<IBorehole> _boreholes;
		public ObservableCollection<IBorehole> Boreholes { get => _boreholes; set => SetProperty(ref _boreholes, value); }
		ObservableCollection<IBorehole> _items = new ObservableCollection<IBorehole>();
		public ObservableCollection<IBorehole> SelectedBoreholes { get => _items; set => SetProperty(ref _items, value); }
		Borehole _currentItem;
		public Borehole CurrentItem { get => _currentItem; set => SetProperty(ref _currentItem, value); }
		public BoreholeTableControlViewModel(BoreholeService service)
		{
			_service = service;
			_boreholes = _service.GetBoreholeList();
			SelectItems = new RelayCommand<object>(MainTable_SelectedCellsChanged);
			EditItem = new RelayCommand<object>(OnEditItem);
			_service.SubscribeToEvents(BoreholeChanged);
		}

	

	
		private void MainTable_SelectedCellsChanged(object sender)
		{
			SelectedBoreholes.Clear();
			System.Collections.IList list = (System.Collections.IList)sender;
			var collection = list.Cast<Borehole>();
			Debug.WriteLine($"Count: {collection.Count()}\n");
			foreach (var item in collection)
			{
				SelectedBoreholes.Add((Models.IBorehole)item);
				Debug.WriteLine($"Name: {((Models.IBorehole)item).Name}");
			}
			WeakReferenceMessenger.Default.Send(_items.ToList());
		}
		private void BoreholeChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Debug.WriteLine("Changed: "+((Borehole)sender).Name);
		}
		private void OnEditItem(object sender)
		{
			Debug.WriteLine(sender);
		}

	}
}
