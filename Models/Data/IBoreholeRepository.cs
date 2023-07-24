using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoreholeCalculations.Models.Data
{
	public interface IBoreholeRepository
	{
		void Add(IBorehole borehole);
		IBorehole GetById(int id);
		List<IBorehole> GetAll();
		void Update(IBorehole borehole);
		void Delete(int id);
	}
}
