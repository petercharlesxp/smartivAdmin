using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace smartivAdmin.Reop
{
    public class NurseRepo
    {
        private SmartivContext _context;

        public NurseRepo(SmartivContext context)
        {
            _context = context;
        }

        public List<nurse> GetAvaiableNurses()
        {
            var query = from d in _context.nurses
                        where d.currentShift == "True"
                        orderby d.firstName
                        select d;

            return query.ToList();
        }

        public List<nurse> GetAllNurses()
        {
            var query = from q in _context.nurses
                        orderby q.firstName
                        select q;

            return query.ToList();
        }

    }
}
