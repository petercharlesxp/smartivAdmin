using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin.Reop
{
    public class PatientRepo
    {
        private SmartivContext _context;

        public PatientRepo(SmartivContext context)
        {
            _context = context;
        }

        public patientbasicinfo AddPatient(string firstNamein
            , string lastNamein
            , string middleNamein
            , string sexin
            , string deviceMacIDin)
        {
            var patin = new patientbasicinfo
            {
                firstName = firstNamein,
                lastName = lastNamein,
                middleName = middleNamein,
                sex = sexin,
                deviceMacID = deviceMacIDin
            };
            _context.patientbasicinfoes.Add(patin);
            _context.SaveChanges();

            return patin;
        }

        public List<patientbasicinfo> GetAllPatients()
        {
            try
            {
                var query = from q in _context.patientbasicinfoes
                            orderby q.firstName
                            select q;

                return query.ToList();
            }
            catch (Exception e)
            {
                
                throw e;
            }

        }
    }
}
