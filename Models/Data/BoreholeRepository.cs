using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Data
{
	public class BoreholeRepository : IBoreholeRepository
	{
		private ObservableCollection<IBorehole> _boreholes;
		public event NotifyCollectionChangedEventHandler CollectionChanged;
		public BoreholeRepository(ObservableCollection<IBorehole> boreholes)
		{
			_boreholes = boreholes;
			_boreholes.CollectionChanged += _boreholes_CollectionChanged;
		}

		private void _boreholes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			CollectionChanged?.Invoke(this, e);
		}

		public void Add(IBorehole borehole)
		{
			_boreholes.Add(borehole);
		}

		public IBorehole GetById(int id)
		{
			return _boreholes.FirstOrDefault(b => b.ID == id);
		}

		public ObservableCollection<IBorehole> GetAll()
		{
			ObservableCollection<IBorehole> list = new ObservableCollection<IBorehole>();
			foreach (var item in _boreholes)
			{
				list.Add(item);
			}
			return list;
		}

		public void Update(IBorehole borehole)
		{
			_boreholes[_boreholes.IndexOf(borehole)] = borehole;
		}

		public void Delete(int id)
		{
			_boreholes.RemoveAt(id);
		}
	}
}
