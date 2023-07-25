using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Data
{
	public interface IBoreholeRepository
	{
		event NotifyCollectionChangedEventHandler CollectionChanged;
		void Add(IBorehole borehole);
		IBorehole GetById(int id);
		ObservableCollection<IBorehole> GetAll();
		void Update(IBorehole borehole);
		void Delete(int id);
	}
}
