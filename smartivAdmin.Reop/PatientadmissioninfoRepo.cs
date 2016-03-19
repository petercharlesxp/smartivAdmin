using smartivAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartivAdmin.Reop
{
    public class PatientadmissioninfoRepo
    {
        private SmartivContext _context;

        public PatientadmissioninfoRepo(SmartivContext context)
        {
            _context = context;
        }

        public patientadmissioninfo AddPatientadmissioninfo(int patientID,
           int nurseID,
            int bedID)
        {
            var patadm = new patientadmissioninfo();
            patadm.patientID = patientID;
            patadm.nurseID = nurseID;
            patadm.bedID = bedID;

            _context.patientadmissioninfoes.Add(patadm);
            _context.SaveChanges();

            return patadm;
        }

        public List<patientadmissioninfo> GetAllPatientadmissioninfos()
        {
            try
            {
                var query = from q in _context.patientadmissioninfoes
                            orderby q.patientID
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
