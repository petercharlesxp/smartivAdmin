using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin.Reop
{
    public class BedRepo
    {
        private SmartivContext _context;

        public BedRepo(SmartivContext context)
        {
            _context = context;
        }

        public List<bed> GetAllBeds()
        {
            var query = from q in _context.beds
                        orderby q.deviceMacID
                        select q;

            return query.ToList();
        }
    }
}
