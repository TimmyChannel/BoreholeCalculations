using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Data
{
	public class BoreholeRepository : IBoreholeRepository
	{
		private List<IBorehole> _boreholes;

		public BoreholeRepository(List<IBorehole> boreholes)
		{
			_boreholes = boreholes;
		}

		public void Add(IBorehole borehole)
		{
			_boreholes.Add(borehole);
		}

		public IBorehole GetById(int id)
		{
			return _boreholes.FirstOrDefault(b => b.ID == id);
		}

		public List<IBorehole> GetAll()
		{
			List<IBorehole> list = new List<IBorehole>();
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
